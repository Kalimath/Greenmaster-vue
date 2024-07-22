import { defineStore } from 'pinia'
import floorplan from "@/assets/images/plattegrond_dummy.png";
import floorplan2 from "@/assets/images/plattegrond_dummy_2.png";

export const useDesignsStore = defineStore('designs',{
    state: () => ({
        designs: [
            {
                id: 1,
                description: "Demo design (domain 1)",
                domainId: 1,
                usableArea: [],
                obstructedArea: [],
                fullArea: null,
                outerDimensions: null,
                backgroundImage: floorplan
            },
            {
                id: 2,
                description: "Demo design (domain 2)",
                domainId: 2,
                usableArea: [],
                obstructedArea: [],
                fullArea: null,
                outerDimensions: null,
                backgroundImage: floorplan2
            },
            {
                id: 3,
                description: "Demo design (domain 3)",
                domainId: 3,
                usableArea: [],
                obstructedArea: [],
                fullArea: null,
                outerDimensions: null,
                backgroundImage: null  
            },
        ],
        currentDesignId: 1,
    }),
    mutations: {
        setDescription(state, designId, newDescription) {
            state.domains[designId].description = newDescription;
        }
    },

    actions: {
        getCurrentDesign: (domainId) => {
            //console.log("currentDesignId: ", this.currentDesignId)
            return this.designs.find(d => d.domainId === domainId && d.id === this.currentDesignId) || null;
        }
        },

    getters: {
        design: (state) => state.designs,
        getDesignByDomainId: (state) => {
            return (domainId) => state.designs.find((design) => design.domainId === domainId)
        }
    }
});