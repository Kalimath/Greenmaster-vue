export default class Point{
    x = 0
    y = 0

    /**
     * Create point with x and y coordinates
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
     * @param {Point}otherPoint
     * */
    givenCoordinateIsHigherThan(isX,otherPoint){
        if(isX){
            return this.x > otherPoint.x
        }else {
            return this.y > otherPoint.y
        }
    }

    /**
     * Sets x coordinate of current point
     *
     * @param {number}value
     * */
    setX(value) {
        if(value<0) throw new TypeError("point could not be set: coordinates are invalid")
        this.x = value;
    }

    /**
     * Sets y coordinate of current point
     *
     * @param {number}value
     * */
    setY(value) {
        if(value<0) throw new TypeError("point could not be set: coordinates are invalid")
        this.y = value;
    }

    /**
     * Returns true if coordinates of current are equal to given point
     *
     * @param otherPoint
     * */
    equalsTo(otherPoint){
        return this.x === otherPoint.x && this.y === otherPoint.y
    }
}