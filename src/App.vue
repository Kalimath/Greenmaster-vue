<template>
  <div class="container">
    <div class="row">
      <EditorPane class="col-lg-6 bg-light"></EditorPane>
      <GardenForm class="col-6 bg-info" msg="Welcome to Your Vue.js App"/>
    </div>
  </div>
</template>

<script>
import GardenForm from './components/GardenForm.vue'
import EditorPane from "@/components/EditorPane";

export default {
  name: 'App',
  components: {
    EditorPane,
    GardenForm
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
