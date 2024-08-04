<template>
  <div class="modal" tabindex="-1" role="dialog"  v-if="isVisible">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" :class="getTitleClass">{{title}}</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <p>{{message}}</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" :onclick="hideModal">{{buttonText}}</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PopupView',
  data() {
    return {
      isVisible: true
    }
  },
  props: {
    isError: Boolean,
    title: String,
    message: String,
    buttonText: String,
  },
  methods: {
    getTitleClass() {
      return this.isError ? 'alert-danger' : 'alert-info'
    },
    hideModal() {
      this.isVisible = false
    }
  }
}
</script>


<style scoped>

</style>