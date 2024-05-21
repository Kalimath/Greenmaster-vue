import Vuex, {createLogger} from "vuex";
import VuexPersistence from 'vuex-persist'
import domain from "@/stores/Modules/Domain";

const vuexLocal = new VuexPersistence({storage: window.localStorage})

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
    modules: {
        domain
    },
    strict: debug,
    plugins: debug ? [createLogger(), vuexLocal.plugin] : []
})

