
<template>
  <div id="list-view">
    <div v-for="domain in domains" :key="domain.id" style="text-align: left">
      <div class="btn btn-light listItem">{{ domain.name }}</div>
    </div>
  </div>
</template>

<script>
import {mapState} from "vuex";

export default {
  name: 'ListView',
  data () {
    return {
    }
  },
  methods: {
  },
  components: {
  },
  computed: {
    ...mapState({domains: state => state.domains})
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