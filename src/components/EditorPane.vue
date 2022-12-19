<template>
  <div>
    <h2>Plan</h2>
    <div id="canvas" class="w-full">
      <ErrorMessageDialog v-if="errorMessage"></ErrorMessageDialog>
      <div id="svgZoomContainer" data-zoom-on-wheel="zoom-amount: 0.01; min-scale: 0.3; max-scale: 20;" data-pan-on-drag :width="width+100" :height="height+100" class="svgZoomContainer" >
        <svg id="svg" :width="width" :height="height" @click="registerPoint" >
        </svg>
      </div>
    </div>
  </div>
</template>

<script>
import {SVG} from "@svgdotjs/svg.js";

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
      garden: SVG(),
      backgroundInstance: null,
      isFirstPoint: true,
      rackGroup: null,
      panZoomInstance: null,
    };
  },
  /**
   * Creates the svg instance and initialises the component
   */
  mounted: function () {
    SVG().addTo('svgZoomContainer').size(this.data().width, this.data().height)
  },
  methods:{
    isMutable: undefined,
    /**
     * Registers a point with coordinates from DOM and stores it in real live scale
     *
     * @param{MouseEvent}event
     * @return {void}
     * */
    /*registerPoint(event) {
      if(event.ctrlKey){
        if (this.isMutable && (this.zoneFormActive || this.warehouseNotCreated)) {
          try {
            let point = new Point(event.offsetX, event.offsetY);

            if (this.warehouseNotCreated && !this.point1) {
              this.isFirstPoint = true
            }
            //reset second point
            store.state.form.point2 = null
            switch (this.isFirstPoint) {
              case true:
                store.commit("setPoint1", scalePointToReal(point, this.scaleFactor));
                break
              case false:
                let pointA = scalePoint(new Point(this.point1.x, this.point1.y), this.scaleFactor)
                arrangePoints(pointA, point);
                if (!pointA.equalsTo(this.point1)) {
                  store.commit("setPoint1", scalePointToReal(pointA, this.scaleFactor))
                }
                store.commit("setPoint2", scalePointToReal(point, this.scaleFactor))
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
  }
}
</script>

<style scoped>

</style>