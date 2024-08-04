import { defineStore } from 'pinia'
import Vertex from "@/models/Vertex";
import {domainStates} from "@/assets/constants/domainStates";

export const useDomainsStore = defineStore('domains',{
    state: () => ({
        domains: [
            {
                id: 1,
                name: "Stationsstraat 27",
                vertices: [new Vertex(1, 100)],
                domainState: domainStates.SetupRequired
            },
            {
                id: 2,
                name: "Peulisbaan 124F",
                vertices: [new Vertex(1, 100)],
                domainState: domainStates.SetupRequired
            },
            {
                id: 3,
                name: "Azalealaan 16",
                vertices: [new Vertex(1, 100)],
                domainState: domainStates.SetupRequired
            }
        ],
        currentDomainId: 1,
    }),
    mutations: {
    },

    actions: {
        setCurrentDomainId(domainId) {
            console.log('currentDomainId changed to ', domainId);
            this.currentDomainId = domainId;
        },
        addNewDomain(){
            const defaultNamePrefix = `New Domain`;
            const defaultNameSuffix = this.domains.filter((domain) => domain.name.startsWith(defaultNamePrefix)).length + 1;
            
            this.domains.push({
                id: this.domains.length + 1,
                name: `${defaultNamePrefix} ${defaultNameSuffix}`,
                vertices: [],
                domainState: domainStates.Empty
            })
        },
        setDomainName(domainName) {
            this.domains.find(d => d.id === this.currentDomainId).domainName = domainName;
        }
    },

    getters: {
        currentDomain: (state) => {
            return state.domains.find(d => d.id === state.currentDomainId) || null;
        }
    }
});