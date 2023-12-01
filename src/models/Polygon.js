export default class Polygon{
    vertices = [];

    /**
     * Create polygon with given vertices
     *
     * @param {Vertex[]} vertices
     * */
    constructor(vertices) {
        this.vertices = vertices;
    }
}