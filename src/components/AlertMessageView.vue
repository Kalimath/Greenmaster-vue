

<template>
  <div class="alert fade show" :class="alertClass">
    <div v-if="isWarning"><strong>Warning:  </strong>{{message}}</div>
    <div v-if="!isWarning"><strong>Error: </strong>{{message}}</div>
  </div>
</template>
<script>
export default {
  name : 'AlertMessageView',
  props: {
    message: {
      type: String,
      required: true
    },
    isWarning: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    alertClass() {
      const string = this.isWarning ? 'alert-warning' : 'alert-danger';
      console.log(string)
      return string
    }
  }
}
</script>
<style scoped>
.alert{
  margin: 0 10px 0 10px;
}
</style>