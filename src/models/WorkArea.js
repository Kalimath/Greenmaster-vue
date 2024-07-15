export class WorkArea {
    length = 0
    width = 0

    /**
     * Create dimensions object with length and width
     *
     * @param {number}length
     * @param {number}width
     * */
    constructor(length,width) {
        this.setLength(length)
        this.setWidth(width)
    }
    getArea() {
        return this.length * this.width;
    }
    getPerimeter() {
        return 2 * (this.length + this.width);
    }
    
    setWidth(width) {
        this.width = width;
    }
    setLength(length) {
        this.length = length;
    }
}