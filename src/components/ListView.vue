
<template>
  <div id="list-view">
    <div v-for="domain in savedDomains" :key="domain.id" style="text-align: left">
      <div class="btn btn-light listItem">{{ domain.name }}</div>
    </div>
  </div>
</template>


<script>
import {useDomainsStore} from "@/stores";

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
    }
  }
}
</script>

<style scoped>
#list-view{
  padding: 17px;
}
.listItem {
  padding-bottom: 8px;
}
</style>