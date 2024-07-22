<template>
  <div id="editor-pane">
    <h2>{{ savedDomains === undefined ? "no active domain found" : getCurrentDomain.name }}</h2>
    <div id="canvas" class="w-full">
      <p v-if="errorMessage" class="alert-danger">{{errorMessage}}</p>
      <div id="svgZoomContainer" data-zoom-on-wheel="zoom-amount: 0.01; min-scale: 0.3; max-scale: 20;" data-pan-on-drag
           :width="width+100" :height="height+100" class="svgZoomContainer" viewBox="0 0 100 100"  @click="RegisterPoint" @mousemove="UpdatePosition"> 
      </div>
    </div>
    <p v-if="cursorPosition != null">({{cursorPosition.x}},{{cursorPosition.y}})</p>
    <input type="button" class="btn btn-danger" @click="ResetEditor" value="Reset vertices">
  </div>
</template>

<script>
import Vertex from "@/models/Vertex";
import {scaleVertex} from "@/utils/graphics";
import {SVG} from "@svgdotjs/svg.js";
import * as Coordinates from "@/utils/CoordinateMethods";
import floorPlan from "C:/Users/mathi/WebstormProjects/Greenmaster-vue/src/assets/images/plattegrond_dummy.png";
import Artist from "@/utils/Artist";
import {useDomainsStore} from "@/stores/Domains";
import {useDesignsStore} from "@/stores/Designs";
import {storeToRefs} from "pinia";

export default {
  name: "EditorPane",
  data() {
    return {
      domain: undefined,
      errorMessage: '',
      width: 1000,
      height: 900,
      size: 5,
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
      lockDistance: 2,
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
        console.log("no background to loaded")
        console.log(e)
      }
      // return imageSvg;
    },
    
    UpdatePosition(event) {
      try {
        this.cursorPosition = this.FromOffsetCoordsOfEvent(event)
      }catch (e) {
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
      const vertex = this.FromOffsetCoordsOfEvent(event);
      if (event.ctrlKey) {

        try {

          this.vertices.push(vertex);
          var vertexIndex = this.vertices.indexOf(vertex);
          
          // this.vertex = scalePointToReal(vertex, this.scaleFactor)
        } catch (e) {
          console.log(e)
          this.errorMessage = e
        }
        this.RegisterVertex(vertex)
        if (this.EditorMode && !this.isFirstPoint) {
          this.ConnectPointToPrevious(vertexIndex-1, vertexIndex)
        }
        this.isFirstPoint = false;
        this.ResetErrorMessage();
      }
    },
    RegisterVertex(vertex) {
      let scaledPoint = null
      scaledPoint = scaleVertex(vertex, 1 /* * this.scaleFactor*/)
      const vertexInfo = `(${scaledPoint.x},${scaledPoint.y})`;
      console.log(vertexInfo);
      Artist.DrawPoint(this.domain, scaledPoint, vertexInfo, this.DrawingColor, vertexInfo);
    },
    ConnectPointToPrevious(trailingVertexIndex, newVertexIndex) {
      const trailingVertex = this.vertices[trailingVertexIndex];
      const newVertex = this.vertices[newVertexIndex];

      Artist.DrawLine(this.domain, trailingVertex, newVertex, this.DrawingColor);
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
      this.svgObject = SVG().addTo('#svgZoomContainer').size(this.width, this.height);
      this.svgObject.attr({id: "svg"});
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
    ResetErrorMessage() {
      this.errorMessage = ''
    },
    FromOffsetCoordsOfEvent(event) {
      return new Vertex(
          Coordinates.InRange(event.offsetX, 0, this.width),
          Coordinates.InRange(event.offsetY, 0, this.height))
    }
  },
  computed: {
    savedDomains(){
      return this.domainStore.domains
    },
    getCurrentDomain(){
      return this.domainStore.currentDomain
    },
    getCurrentDesignOfCurrentDomain(){
      const currentDesignId = this.designStore.currentDesignId;
      return this.designStore.designs.find(design => design.domainId === this.getCurrentDomain.id && design.id === currentDesignId)
    },
    getCurrentDesign(){
      return this.designStore.getDesignByDomainId(this.domainStore.currentDomainId)
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
  background-color: antiquewhite;
}
</style>