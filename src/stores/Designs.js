import { defineStore } from 'pinia'

export const useDesignsStore = defineStore('designs',{
    state: () => ({
        designs: [
            {
                id: 1,
                description: "demo design",
                domainId: 1,
                usableArea: [],
                obstructedArea: [],
                fullArea: null,
                outerDimensions: null,
            }
        ],
        currentDesignId: 1,
    }),
    mutations: {
        setDescription(state, designId, newDescription) {
            state.domains[designId].description = newDescription;
        }
    },

    actions: {},

    getters: {
        currentDesign: (state) => {
            console.log(state.designs)
            return state.designs.find(d => d.id === state.currentDesignId) || null;
        }
    }
});