import Vuex from 'vuex';
import Vertex from "@/models/Vertex";


const store = new Vuex.Store({
    state: {
        vertices: [new Vertex(100, 200)],
        plan: null,
        scaleFactor: 1,
        domains: [
            {
                id: 1,
                name: "Stationstraat 27",
                vertices: []
            },
            {
                id: 2,
                name: "Peulisbaan 124F",
                vertices: []
            },
            {
                id: 3,
                name: "Azalealaan 16",
                vertices: []
            }
        ],
        currentDomainId: 1,
    },
    mutations: {
        addVertex(state, vertex) {
            state.vertices.push(vertex)
        },
        setPlan(state, plan) {
            state.plan = plan
        },
        setScaleFactor(state, scaleFactor) {
            state.scaleFactor = scaleFactor
        },
        setDomainName(state, domainName) {
            state.domainName = domainName;
        }
    },

    actions: {},

    getters: {
        vertices: state => state.vertices,
        plan: state => state.plan,
        scaleFactor: state => state.scaleFactor,
        currentDomain: state => state.domains.find(d => d.id === state.currentDomainId) || null,
        domains: state => state.domains
    }
});


export default store;

