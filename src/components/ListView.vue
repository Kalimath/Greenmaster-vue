
<template>
  <div id="list-view">
    <div v-for="domain in domains" :key="domain" style="text-align: left">
      <div class="btn btn-light listItem">{{ domain }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ListView',
  data () {
    return {
      domains: [
        "Stationsstraat 27", 
        "Peulisbaan 124F", 
        "Azalealaan 16"
      ]
    }
  },
  methods: {
  },
  components: {
  },
  computed: {
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