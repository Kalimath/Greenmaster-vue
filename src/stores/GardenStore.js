import VuexPersistence from 'vuex-persist'
import {createStore} from "vuex";
import Point from "@/models/Point";

const vuexLocal = new VuexPersistence({
    storage: window.localStorage
})
const store = createStore({
    state(){
        return{
            domain: {
                obstacles: [],
                plan: null
            }
        }
    },
    mutations:{

    },
    actions: {},
    getters: {},
    plugins: [vuexLocal.plugin]
});

export default store;