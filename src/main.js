import * as Vue from 'vue'
import App from '@/App.vue'
import store from './stores';
import VueSelect from "vue-select";
import { SVG } from '@svgdotjs/svg.js'
import {createPinia} from "pinia";

const pinia = createPinia()

Vue.createApp(App)
    .use(store)
    .use(pinia)
    .use(SVG)
    .component("v-select", VueSelect)
    .mount('#app')
