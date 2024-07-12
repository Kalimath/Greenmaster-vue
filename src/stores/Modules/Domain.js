/* eslint-disable no-unused-vars */
import Vertex from "@/models/Vertex";



const state = ({
        vertices: [new Vertex(100, 200)],
        plan: null,
        scaleFactor: 1,
        domainName: "Stationstraat 27",
})

const mutations = {
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
}
const actions = {}
const getters = {
    vertices: state => state.vertices,
    plan: state => state.plan,
    scaleFactor(state) {
        return state.scaleFactor
    },
    domainName: state => state.domainName
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}