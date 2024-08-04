<script setup>

</script>

<template>
<div>
  <h3>Change domain info</h3>
  <form @submit.prevent="updateDomainInfo">
    <input type="text" v-model="domainName" placeholder="Enter domain name" />
    <button type="submit">Add domain</button>
  </form>
</div>
</template>

<style scoped>
h3 {
  padding-top: 20px;
}
</style>