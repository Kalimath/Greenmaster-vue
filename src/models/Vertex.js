export default class Vertex {
    x = 0
    y = 0

    /**
     * Create vertex with x and y coordinates
     *
     * @param {number}x
     * @param {number}y
     * */
    constructor(x,y) {
        this.setX(x)
        this.setY(y)
    }

    /**
     * Checks if this with selected coordinate (x or y) is higher than corresponding of otherPoint
     *
     * @param {boolean}isX
     * @param {Vertex}otherPoint
     * */
    givenCoordinateIsHigherThan(isX,otherPoint){
        if(isX){
            return this.x > otherPoint.x
        }else {
            return this.y > otherPoint.y
        }
    }

    /**
     * Sets x coordinate of current vertex
     *
     * @param {number}value
     * */
    setX(value) {
        if(value<0) throw new TypeError("vertex could not be set: coordinates are invalid")
        this.x = value;
    }

    /**
     * Sets y coordinate of current vertex
     *
     * @param {number}value
     * */
    setY(value) {
        if(value<0) throw new TypeError("vertex could not be set: coordinates are invalid")
        this.y = value;
    }

    /**
     * Returns true if coordinates of current are equal to given vertex
     *
     * @param otherPoint
     * */
    equalsTo(otherPoint){
        return this.x === otherPoint.x && this.y === otherPoint.y
    }
}