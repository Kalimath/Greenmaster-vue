import VuexPersistence from 'vuex-persist'
import {createStore} from "vuex";
import Vertex from "@/models/Vertex";

const vuexLocal = new VuexPersistence({
    storage: window.localStorage
})
const store = createStore({
    state(){
        return{
            domain: {
                obstacles: [new Vertex(100,200)],
                plan: null,
                scaleFactor: 1,
            }
        }
    },
    mutations:{

    },
    actions: {},
    getters: {
        obstacles: state => state.domain.obstacles,
        plan: state => state.domain.plan,
        scaleFactor: state => state.domain.scaleFactor
    },
    plugins: [vuexLocal.plugin]
});

export default store;