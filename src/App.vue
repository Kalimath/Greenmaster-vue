<template>
  <div class="container">
    <header style="padding-bottom: 20px">
      <h1>Greenmaster [Beta]</h1>
    </header>
    <div class="row">
      <ListView class="col-lg-3 bg-light"></ListView>
      <EditorPane class="col-lg-9 bg-light"></EditorPane>
<!--      <GardenForm class="col-6 bg-info" msg="Welcome to Your Vue.js App"/>-->
    </div>
  </div>
</template>

<script>
/*
import GardenForm from './components/GardenForm.vue'
*/
import EditorPane from "@/components/EditorPane";
import ListView from "@/components/ListView.vue";

export default {
  name: 'App',
  components: {
    ListView,
    EditorPane
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
  margin-top: 60px;
}
</style>
