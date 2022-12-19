

export default class Dimensions{
    l = 0
    width = 0
    height = 0

    /**
     * Create dimensions object with l, width and height
     *
     * @param {number}length
     * @param {number}width
     * @param {number}height
     * */
    constructor(length,width,height) {
        this.setL(length)
        this.setWidth(width)
        this.setHeight(height)
    }

    /**
     * Sets l (precision= 2)
     *
     * @param {number}value
     * */
    setL(value) {
        if(!value||value<=0) throw new TypeError("dimensions could not be set: invalid")
        this.l = value;
    }

    /**
     * Sets width (precision= 2)
     *
     * @param {number}value
     * */
    setWidth(value) {
        if(!value||value<=0) throw new TypeError("dimensions could not be set: invalid")
        this.width = value;
    }

    /**
     * Sets height (precision= 2)
     *
     * @param {number}value
     * */
    setHeight(value) {
        if(value<0) throw new TypeError("dimensions could not be set: invalid")
        this.height = value;
    }

}