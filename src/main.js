import * as Vue from 'vue'
import App from '@/App.vue'
import store from "store";
import Vuex from 'vuex'
import VueSelect from "vue-select";

Vue.createApp(App)
    .use(store)
    .use(Vuex)
    .component("v-select", VueSelect)
    .mount('#app')
