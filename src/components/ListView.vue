
<template>
  <div id="list-view">
    <h3 class="text-lg-start">Domains</h3>
   <div class="overflow-scroll">
     <div v-for="domain in savedDomains" :key="domain.id">
       <input type="button" class="btn btn-sm editButton" value="✎"/><input type="button" class="btn btn-light listItem" @click="this.domainStore.setCurrentDomainId(domain.id)" :value="domain.name">
     </div>
     <input type="button" class="btn listItem" @click="addNewDomain" value="+">
   </div>
  </div>
</template>


<script>
import {useDomainsStore} from "@/stores/Domains";
import {mapActions} from "pinia";

export default {
  name: 'ListView',
  data () {
    return {
    }
  },
  setup() {
    const domainStore = useDomainsStore();
    return {domainStore};
  },
  methods: {
    addNewDomain() {
      this.domainStore.addNewDomain();
    }
  },
  components: {
  },
  computed: {
    savedDomains(){
      return this.domainStore.domains
    },
    ...mapActions(useDomainsStore, ['setCurrentDomainId', 'addNewDomain']),
  }
}
</script>

<style scoped>
#list-view{
  margin: 10px;
  text-align: left
}
.listItem {
  padding-bottom: 8px;
}
.editButton:hover {
  color: green;
}
h3 {
  padding-left: 10px;
}
</style>