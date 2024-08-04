import {domainStates} from "@/assets/constants/domainStates";

/**
 * Object that represents a real estate domain 
 * 
 * @property {number} id
 * @property {string} name
 * @property {Array<Design>} designs
 * @property {User} owner
 * @property geoLocation
 * @property {domainStates} domainState - default is domainStates.Empty
 *  */
export default class Domain {
    id = 0;
    name = '';
    designs = [];
    owner = null;
    geoLocation = null;
    domainState = domainStates.Empty;
    
    Domain(id, name, designs, owner, geoLocation, domainState = domainStates.Empty) {
        this.id = id;
        this.name = name;
        this.designs = designs;
        this.owner = owner;
        this.geoLocation = geoLocation;
        this.domainState = domainState;
    }
}

