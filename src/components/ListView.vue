
<template>
  <div>
    <div v-for="domain in domains" :key="domain">
      <div class="btn btn-light">{{ domain }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ListView',
  data () {
    return {
      domains: [
        "domain 1", 
        "domain 2", 
        "domain 3"
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

</style>