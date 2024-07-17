import { defineStore } from 'pinia'
import Vertex from "@/models/Vertex";

export const useDomainsStore = defineStore('domains',{
    state: () => ({
        domains: [
            {
                id: 1,
                name: "Stationsstraat 27",
                vertices: [new Vertex(1, 100)]
            },
            {
                id: 2,
                name: "Peulisbaan 124F",
                vertices: [new Vertex(1, 100)]
            },
            {
                id: 3,
                name: "Azalealaan 16",
                vertices: [new Vertex(1, 100)]
            }
        ],
        currentDomainId: 1,
    }),
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
        currentDomain: (state) => {
            console.log(state.domains)
            return state.domains.find(d => d.id === state.currentDomainId) || null;
        }
    }
});


