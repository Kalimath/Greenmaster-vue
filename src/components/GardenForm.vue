<template>
  <div>
    <form @submit="onSubmit" @reset="onReset" v-if="show">
      <div class="form-group col-sm-4">
        <label>Country*</label>
        <div>
          <v-select id="country-name" :options="getCountries" :selected="getCountries[0]"
                    v-model="form.country"></v-select>
        </div>
      </div>
      <div class="form-group col-sm-4">
        <label for="lineLength">Length of defined line (metric)*</label>
        <input class="form-control" id="lineLength" type="number" placeholder="0.5" min="0.5" step=".01"
               v-model="form.lineLength" required>
      </div>
      <div class="form-group col-sm-4">
        <label for="budget">Budget</label>
        <input class="form-control" id="budget" type="text" placeholder="-"
               v-model="form.delimiter" min="0">
      </div>

    </form>
    <input type="submit" class="btn-primary">
  </div>
</template>

<script>
import {COUNTRYLIST} from "@/assets/constants/countries";

export default {
  data() {
    return {
      errorMessage: null,
      form: {
        country: '',
        lineLength: 0,
        budget: 0,
      },
      show: true
    }
  },
  computed: {
    getCountries() {
      return COUNTRYLIST
    },
    methods: {
      onSubmit(event) {
        event.preventDefault()
        alert(JSON.stringify(this.form))
      },
      onReset(event) {
        event.preventDefault()
        // Reset our form values
        this.form.country = ''
        this.form.lineLength = 0
        this.form.budget = 0
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      }
    }
  }
}
</script>
<style>
@import "vue-select/dist/vue-select.css";
</style>