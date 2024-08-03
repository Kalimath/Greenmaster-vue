<script setup>

</script>

<template>
<div id="plant-view">
  <h3 class="text-lg-start">Plants</h3>
  <table class="table table-striped table-hover">
    <caption>work in progress</caption>
    <thead class="thead-dark">
      <tr>
        <th>Name</th>
        <th>Type</th>
        <th>Height</th>
        <th>Visual</th>
      </tr>
    </thead>
    <tbody v-for="plant in plants" v-bind:id="plant.id" :key="plant.id">
      <tr class="d-md-table-row">
        <td>{{plant.name}}</td>
        <td>{{plant.type}}</td>
        <td>{{plant.height}}</td>
        <td>/<!--<img src="{{getPlantImageBase64}}" alt="">--></td>
      </tr>
    </tbody>
  </table>
</div>
</template>

<script>
import Plant from "@/models/Plant";
import ImageConverter from "@/utils/imageConverter";
import plantImage from "C:/Users/mathi/WebstormProjects/Greenmaster-vue/src/assets/TopViewPlant-V2_014.png";

export default {
  name: "PlantView",
  data() {
    return {
      plants: [new Plant(1, "Plant 1", "Bush", 0.65)]
    };
  },
  methods: {
    getPlantImageBase64() {
      return ImageConverter.getBase64Image(plantImage);
    }
  }
}
</script>

<style scoped>
#plant-view {
  margin: 10px;
}
h3 {
  padding-left: 10px;
}

</style>