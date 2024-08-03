
<template>
  <div id="list-view">
    <h3 class="text-lg-start">Domains</h3>
    <div v-for="domain in savedDomains" :key="domain.id" style="text-align: left">
      <input type="button" class="btn btn-light listItem" @click="this.domainStore.setCurrentDomainId(domain.id)" :value="domain.name">
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
    
  },
  components: {
  },
  computed: {
    savedDomains(){
      return this.domainStore.domains
    },
    ...mapActions(useDomainsStore, ['setCurrentDomainId']),
  }
}
</script>

<style scoped>
#list-view{
  margin: 10px;
}
.listItem {
  padding-bottom: 8px;
}
h3 {
  padding-left: 10px;
}
</style>