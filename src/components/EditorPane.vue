<template>
  <div>
    <h2>Domain</h2>
    <div id="canvas" class="w-full">
      <!--      <ErrorMessageDialog v-if="errorMessage"></ErrorMessageDialog>-->
      <div id="svgZoomContainer" data-zoom-on-wheel="zoom-amount: 0.01; min-scale: 0.3; max-scale: 20;" data-pan-on-drag
           :width="width+100" :height="height+100" class="svgZoomContainer">
        <svg id="svg" :width="width" :height="height" @click="RegisterPoint"></svg>
      </div>
    </div>
  </div>
</template>

<script>
import * as Snap from 'snapsvg-cjs'
import {scaleVertex} from "@/utils/graphics";
import {mapGetters} from "vuex";
import Vertex from "@/models/Vertex";

export default {
  name: "EditorPane",
  data() {
    return {
      errorMessage: '',
      width: 1000,
      height: 900,
      size: 3,
      formRackColor: "red",
      markingColor: "#0059B2",
      garden: null,
      snap: null,
      backgroundInstance: null,
      isFirstPoint: true,
      vertex: null,
      polygons: null,
      panZoomInstance: null,
    };
  },
  /**
   * Creates the svg instance and initialises the component
   */
  mounted: function () {
    this.snap = Snap('#svg')
    this.garden = this.snap.paper.group().attr({id: "garden"})
  },
  methods: {
    isMutable: undefined,
    Render() {
      this.garden.rect(0, 0, 100, 100)
    },
    RegisterVertex() {
      let scaledPoint = null

      scaledPoint = scaleVertex(this.vertex, 1 /*this.scaleFactor*/)
      console.log(scaledPoint.x, scaledPoint.y)
      let p1 = this.snap.paper.circle(scaledPoint.x, scaledPoint.y, this.size)
          .attr({fill: "red", id: "v1"});
      this.garden.append(p1)

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
            this.vertex = new Vertex(event.offsetX, event.offsetY);
            // this.vertex = scalePointToReal(vertex, this.scaleFactor)
          } catch (e) {
            console.log(e)
            this.errorMessage = e
          }
          this.RegisterVertex()
      }
    },
    /**
     * Registers a vertex with coordinates from DOM and stores it in real live scale
     *
     * @param{MouseEvent}event
     * @return {void}
     * */
    /*registerPoint(event) {
      if(event.ctrlKey){
        if (this.isMutable && (this.zoneFormActive || this.warehouseNotCreated)) {
          try {
            let vertex = new Vertex(event.offsetX, event.offsetY);

            if (this.warehouseNotCreated && !this.point1) {
              this.isFirstPoint = true
            }
            //reset second vertex
            store.state.form.point2 = null
            switch (this.isFirstPoint) {
              case true:
                store.commit("setPoint1", scalePointToReal(vertex, this.scaleFactor));
                break
              case false:
                let pointA = scaleVertex(new Vertex(this.point1.x, this.point1.y), this.scaleFactor)
                arrangePoints(pointA, vertex);
                if (!pointA.equalsTo(this.point1)) {
                  store.commit("setPoint1", scalePointToReal(pointA, this.scaleFactor))
                }
                store.commit("setPoint2", scalePointToReal(vertex, this.scaleFactor))
                break
            }
          } catch (e) {
            console.log(e)
            this.errorMessage = e
          }
          this.renderShapes()
          this.isFirstPoint = !this.isFirstPoint;
        } else if (!this.isMutable) {
          this.errorMessage = "Unable to define points when they are immutable or confirmed"
        }
      }
    }*/
  },
  computed: {
    ...mapGetters(["scaleFactor"])
  }
}
</script>

<style scoped>

</style>