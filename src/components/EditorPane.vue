<template>
  <div id="editor-pane">
    <h2>Stationsstraat 27</h2>
    <div id="canvas" class="w-full">
      <p v-if="errorMessage" class="alert-danger">{{errorMessage}}</p>
      <div id="svgZoomContainer" data-zoom-on-wheel="zoom-amount: 0.01; min-scale: 0.3; max-scale: 20;" data-pan-on-drag
           :width="width+100" :height="height+100" class="svgZoomContainer">
        <svg id="svg" :width="width" :height="height" @click="RegisterPoint" @mousemove="UpdatePosition" class="border border-dark"></svg>
      </div>
    </div>
    <p v-if="cursorPosition != null">({{cursorPosition.x}},{{cursorPosition.y}})</p>
    <input type="button" class="btn btn-danger" @click="ResetEditor" value="Reset vertices">
  </div>
</template>

<script>
import Vertex from "@/models/Vertex";
import {mapGetters} from "vuex";
import {scaleVertex} from "@/utils/graphics";
import {SVG} from "@svgdotjs/svg.js";
import * as Coordinates from "@/utils/CoordinateMethods";
import floorPlan from "@/assets/images/plattegrond_dummy.png";
import Artist from "@/utils/Artist";

export default {
  name: "EditorPane",
  data() {
    return {
      errorMessage: '',
      width: 1000,
      height: 900,
      size: 5,
      HighlightColor: "red",
      DrawingColor: "#0059B2",
      domain: null,
      garden: null,
      svgObject: null,
      backgroundInstance: null,
      isFirstPoint: true,
      EditorMode: true,
      vertices: [],
      SelectedVertex: null,
      polygons: [],
      panZoomInstance: null,
      lockDistance: 2,
      cursorPosition: null,
    };
  },
  /**
   * Creates the svg instance and initialises the component
   */
  mounted: function () {
    // eslint-disable-next-line no-undef
    this.InitialiseSvgObject()
    this.updateBackground()
  },
  methods: {
    /**
     * Updates the svg's background image.
     */
    updateBackground() {
      // let imageSvg = null
      try {
        if (document.getElementById("background")) {
          document.getElementById("background").remove()
        }
        Artist.DrawImage(this.domain, floorPlan, this.width, this.height, "floorplan")
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
      if (event.ctrlKey) {

        try {
          var vertex = this.FromOffsetCoordsOfEvent(event);
          
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
    ResetVertices() {
      this.vertices = [];
      this.svgObject = 
      this.isFirstPoint = true;
    },
    ResetSvg() {
      this.svgObject = null;
      this.domain = null;
      this.garden = null;
      document.getElementById("svg").innerHTML = "";
    },
    InitialiseSvgObject() {
      
      this.svgObject = SVG().addTo('#svg').size(this.width, this.height);
      this.domain = this.svgObject.group()
      this.domain.rect(0, 0, this.width/3, this.height/3).attr({id: "/3", fill: "blue"})
      this.garden = this.domain.nested()
      this.garden.rect(0, 25, this.width/4, this.height/4).attr({id: "/3", fill: "green"})
    },
    ResetEditor() {
      this.ResetVertices()
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
    getScaleFactor () {
      return this.$store.getters.scaleFactor
    },
    ...mapGetters(["scaleFactor", "domainName" ])
  }
}
</script>

<style scoped>
#editor-pane {
  padding: 0px;
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
  background-color: lightsteelblue;
}
</style>