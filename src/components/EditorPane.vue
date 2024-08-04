<template>
  
  <div id="editor-pane">
    <h2>{{ savedDomains === undefined ? "no active domain found" : getCurrentDomain.name }}</h2>
    <AlertMessageView :is-warning="warningMessage !== ''" :message="errorMessage||warningMessage" v-if="errorMessage||warningMessage"></AlertMessageView>
    <div id="canvas" class="w-full">
      <div id="svgZoomContainer" :width="width+100" :height="height+100" class="svgZoomContainer"  @click="RegisterPoint" @mousemove="UpdatePosition">
        
      </div>
    </div>
    <p v-if="cursorPosition != null">({{cursorPosition.x}},{{cursorPosition.y}})</p>
    <input type="button" class="btn btn-danger" @click="ResetEditorWithInitialBackground" value="Reset vertices">
    <input type="button" class="btn btn-danger" @click="resetPanZoom" value="Reset zoom">
    <input type="button" class="btn btn-danger" @click="logZoomFactor" value="Log zoom">
  </div>
</template>
<script>
import Vertex from "@/models/Vertex";
import {scaleVertex} from "@/utils/graphics";
import {SVG} from "@svgdotjs/svg.js";
import '@svgdotjs/svg.panzoom.js'
import * as Coordinates from "@/utils/CoordinateMethods";
import floorPlan from "C:/Users/mathi/WebstormProjects/Greenmaster-vue/src/assets/images/plattegrond_dummy.png";
import Artist from "@/utils/Artist";
import {useDomainsStore} from "@/stores/Domains";
import {useDesignsStore} from "@/stores/Designs";
import {storeToRefs} from "pinia";
import AlertMessageView from "@/components/AlertMessageView.vue";
// import {resetScale} from "svg-pan-zoom-container";

export default {
  name: "EditorPane",
  components: {AlertMessageView},
  data() {
    return {
      domain: undefined,
      errorMessage: '',
      warningMessage: "",
      width: 900,
      height: 900,
      lineSize: 5,
      HighlightColor: "red",
      DrawingColor: "#0059B2",
      svgObject: null,
      backgroundInstance: null,
      isFirstPoint: true,
      EditorMode: true,
      vertices: [],
      SelectedVertex: null,
      polygons: [],
      panZoomInstance: null,
      lockDistance: 5,
      cursorPosition: null
    };
  },
  setup() {
    const domainStore = useDomainsStore();
    const designStore = useDesignsStore(); 
    const {currentDomainId} = storeToRefs(domainStore)
    const {designs} = storeToRefs(designStore);
    return {domainStore, designStore, currentDomainId, designs};
  },
  /**
   * Creates the svg instance and initialises the component
   */
  mounted() {
    // eslint-disable-next-line no-undef
    this.InitialiseSvgObject()
    this.updateBackground(this.getCurrentDesign.backgroundImage);
  },
  //TODO: only show crosshair when left ctrl key is pressed
  methods: {
    /**
     * Updates the svg's background image.
     */
    updateBackground(imageUrl = floorPlan) {
      // let imageSvg = null
      try {
        if (document.getElementById("background")) {
          document.getElementById("background").remove()
        }
        Artist.DrawImage(this.domain, imageUrl, this.width, this.height, "background")
      } catch (e) {
        this.errorMessage = e
        console.log(e);
      }
      // return imageSvg;
    },
    
    UpdatePosition(event) {
      try {
        this.cursorPosition = this.FromOffsetCoordsOfEvent(event)
      }catch (e) {
        this.errorMessage = e
        console.log((event.offsetX+ ", " + event.offsetY))
        this.cursorPosition = null
      }
    },  
    /**
     * Registers a point with coordinates from DOM and stores it in real live scale
     *
     * @param{MouseEvent}event
     * @return {void}
     * */
    RegisterPoint(event) {
      let vertex = this.FromOffsetCoordsOfEvent(event);
      if (event.ctrlKey) {

        try {
          //vertex = scalePointToReal(vertex, this.zoomFactor)
          this.vertices.push(vertex);
          var vertexIndex = this.vertices.indexOf(vertex);
        } catch (e) {
          console.log(e)
          this.errorMessage = e
        }
        this.RegisterVertex(vertex)
        if (this.EditorMode && !this.isFirstPoint) {
          Artist.DrawLineBetweenTwoPoints(this.domain, this.vertices[vertexIndex-1], this.vertices[vertexIndex], this.lineSize, this.HighlightColor)
        }
        this.isFirstPoint = false;
        this.ResetErrorMessage();
      }
    },
    RegisterVertex(vertex) {
      let scaledPoint = null
      scaledPoint = scaleVertex(vertex, 1 /* * this.scaleFactor*/)
      vertex.round(this.lockDistance)
      const vertexInfo = `(${scaledPoint.x},${scaledPoint.y})`;
      console.log(vertexInfo);
      Artist.DrawPoint(this.domain, scaledPoint, this.lineSize, this.DrawingColor, vertexInfo);
    },
    SetVertices() {
      this.vertices = [];
      this.svgObject = 
      this.isFirstPoint = true;
    },
    ResetSvg() {
      this.svgObject = null;
      this.domain = null;
      this.garden = null;
      document.getElementById("svgZoomContainer").innerHTML = "";
    },
    InitialiseSvgObject() {
      const svgWidth = document.getElementById("svgZoomContainer").offsetWidth;
      console.log("SVG object width: " + svgWidth + "px")
      this.svgObject = SVG()
          .addTo('#svgZoomContainer')
          .size(svgWidth, this.height)
      /*.viewbox('0 0 1000 1000')
      .panZoom({zoomMin: 0.5, zoomMax: 20, zoomFactor: 0.01 })
      .zoom(1)*/
          /*.on('mousemove', this.UpdatePosition)
          .on('click', this.RegisterPoint)*/
           //doc: https://github.com/svgdotjs/svg.panzoom.js
      this.svgObject.attr({id: "svg",   });
      this.CreateDomainSvgGroup()
      this.CreateGardenSvgNesting()
    },
    CreateDomainSvgGroup(){
      this.domain = this.svgObject.group()
      this.domain.rect(0, 0, this.width/3, this.height/3).attr({id: "/3", fill: "blue"})
    },
    CreateGardenSvgNesting() {
      this.garden = this.domain.nested()
      this.garden.rect(0, 25, this.width/4, this.height/4).attr({id: "/3", fill: "green"})
    },
    ResetEditor() {
      this.SetVertices()
      this.ResetSvg()
      this.InitialiseSvgObject()
    },
    ResetEditorWithInitialBackground() {
      this.SetVertices()
      this.ResetSvg()
      this.InitialiseSvgObject()
      this.updateBackground(this.getCurrentDesign.backgroundImage);
    },
    ResetErrorMessage() {
      this.errorMessage = ''
    },
    FromOffsetCoordsOfEvent(event) {
      return new Vertex(
          Coordinates.InRange(event.offsetX, 0, this.width),
          Coordinates.InRange(event.offsetY, 0, this.height))
    },
    /**
     * Resets zoom and panning of the svg element
     */
    resetPanZoom(){
      this.svgObject.zoom(1)
    },
    logZoomFactor(){
      console.log("Zoom factor: ", this.zoomFactor)
    }
  },
  computed: {
    savedDomains(){
      return this.domainStore.domains
    },
    getCurrentDomain(){
      return this.domainStore.currentDomain
    },
    getCurrentDesign(){
      return this.designStore.getDesignByDomainId(this.domainStore.currentDomainId)
    },
    zoomFactor(){
      return this.svgObject.zoom()
    }
        
  },
  watch: {
    currentDomainId(newDomainId) {
      //TODO: update domain and garden from the svgObject
      console.log("new domainId: ", newDomainId)
      console.log(this.getCurrentDesign)
      
      this.updateBackground(this.getCurrentDesign.backgroundImage);
  
    }
  }
}
</script>

<style scoped>
#editor-pane {
  padding: 0;
}
svg {
  cursor: crosshair;
  background-size: cover;
  background-position: center;
}
svg:active{
  cursor: grab;
}
.svgZoomContainer{
  overflow: hidden;
  margin: 10px;
  border: 1px solid lightslategray;
  background-color: white;
}
</style>