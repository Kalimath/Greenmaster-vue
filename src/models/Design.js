import {WorkArea} from "@/models/WorkArea";

export class Design {
    id = 0;
    description = 'new design';
    version = 1;
    domainId = 0;
    usableArea = [];
    obstructedArea = [];
    fullArea = WorkArea;
    outerDimensions = null;
    backgroundImage = null;
}