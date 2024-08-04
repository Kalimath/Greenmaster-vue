<template>
  <div id="app">
    <header style="margin-bottom: 20px">
      <h1>Greenmaster [Beta]</h1>
    </header>
    <div class="container-fluid">
      <div class="row">
        <div class="col bg-light">
          <div class="row">
            <ListView></ListView>
            <DomainForm v-if="domainSetupRequired"/>
            <BackgroundForm v-if="domainBackgroundRequired"/>
<!--            domain form or background form or GardenBoundaries form or ...-->
          </div>
        </div>
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
import {useDomainsStore} from "@/stores/Domains";
import {storeToRefs} from "pinia";
import {useDesignsStore} from "@/stores/Designs";
import DomainForm from "@/components/DomainForm.vue";
import {domainStates} from "@/assets/constants/domainStates";
import BackgroundForm from "@/components/BackgroundForm.vue";

export default {
  name: 'App',
  components: {
    BackgroundForm,
    DomainForm,
    ListView,
    EditorPane,
    PlantView
  },
  setup() {
    const domainStore = useDomainsStore();
    const designStore = useDesignsStore();
    const {currentDomainId} = storeToRefs(domainStore)
    const {designs} = storeToRefs(designStore);
    return {domainStore, designStore, currentDomainId, designs};
  },
  computed: {
    getCurrentDomainIdElse0() {
      if (this.currentDomainId === undefined) {
        return 0;
      }else {
        return this.currentDomainId;
      }
    },
    getCurrentDomain(){
      return this.domainStore.currentDomain
    },
    getCurrentDesign(){
      return this.designStore.getDesignByDomainId(this.domainStore.currentDomainId)
    },
    domainSetupRequired() {
      console.log("DomainState: "+this.getCurrentDomain.domainState)
      return this.getCurrentDomainIdElse0 !== 0 && this.getCurrentDomain.domainState === domainStates.SetupRequired;
    },
    domainBackgroundRequired() {
      return this.getCurrentDomainIdElse0!== 0 && this.getCurrentDomain.domainState === domainStates.DomainSet;
    }
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
