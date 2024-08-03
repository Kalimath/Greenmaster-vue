<template>
  <div id="app">
    <header style="margin-bottom: 20px">
      <h1>Greenmaster [Beta]</h1>
    </header>
    <div class="container-fluid">
      <div class="row">
        <ListView class="col bg-light"></ListView>
        <EditorPane class="col-7 bg-light"></EditorPane>
        <PlantView class="col bg-light"></PlantView>
        <!--      <GardenForm class="col-6 bg-info" msg="Welcome to Your Vue.js App"/>-->
      </div>
    </div>
  </div>
</template>

<script>
/*
import GardenForm from './components/GardenForm.vue'
*/
import EditorPane from "@/components/EditorPane";
import ListView from "@/components/ListView.vue";
import PlantView from "@/components/PlantView.vue";

export default {
  name: 'App',
  components: {
    ListView,
    EditorPane,
    PlantView
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 20px;
}
</style>
