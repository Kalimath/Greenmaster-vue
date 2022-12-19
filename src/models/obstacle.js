
export class Obstacle {
    name = '';
    points = [];

    /**
     * Create obstacle object with name and array of points
     *
     * @param {string}name
     * @param {Point[]}points
     * */
    constructor(name, points) {
        this.setName(name)
        this.setPoints(points);
    }

    /**
     * Sets name of the obstacle
     *
     * @param {string}name
     * */
    setName(name) {
        if(!name||name.trim().length === 0) throw new TypeError("name of obstacle could not be set: empty")
        this.name = name;
    }
    /**
     * Sets points of the obstacle
     *
     * @param {Point[]}points
     * */
    setPoints(points) {
        if(!points||points[0] === null) throw new TypeError("points of obstacle could not be set: empty")
        this.points = points;
    }
}