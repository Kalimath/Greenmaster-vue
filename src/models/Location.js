export default class Location {
    x = 0
    y = 0
    Z = 0

    /**
     * Create location with x,y and z coordinates
     *
     * @param {number}x
     * @param {number}y
     * @param {number}z
     * */
    constructor(x, y, z) {
        this.setX(x)
        this.setY(y)
        this.setZ(z)
    }

    /**
     * Sets x of location
     *
     * @param {number}value
     * */
    setX(value) {
        if (value < 0) throw new RangeError("location could not be set: coordinates are invalid")
        this.x = value;
    }

    /**
     * Sets y of location
     *
     * @param {number}value
     * */
    setY(value) {
        if (value < 0) throw new RangeError("location could not be set: coordinates are invalid")
        this.y = value;
    }

    /**
     * Sets z of location
     *
     * @param {number}value
     * */
    setZ(value) {
        if (value < 0) throw new RangeError("location could not be set: coordinates are invalid")
        this.z = value;
    }
}