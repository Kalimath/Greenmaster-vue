import * as Vue from 'vue'
import App from '@/App.vue'
import store from './stores';
import Vuex from 'vuex'
import VueSelect from "vue-select";
import { SVG } from '@svgdotjs/svg.js'

Vue.createApp(App)
    .use(store)
    .use(Vuex)
    .use(SVG)
    .component("v-select", VueSelect)
    .mount('#app')
