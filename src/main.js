import * as Vue from 'vue'
import App from '@/App.vue'
import store from "store";
import Vuex from 'vuex'
import VueSelect from "vue-select";
import { SVG, SVGextend, SVGElement } from '@svgdotjs/svg.js'

Vue.createApp(App)
    .use(store)
    .use(Vuex)
    .use(SVG)
    .use(SVGextend)
    .use(SVGElement)
    .component("v-select", VueSelect)
    .mount('#app')
