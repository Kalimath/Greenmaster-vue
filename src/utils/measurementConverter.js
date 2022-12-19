
/**
 * Converts value from centimeters to meters
 * @param {number}value
* */
export function fromCm(value) {
    if(value>=0){
        let result = value
        if(value>0) result = value/100
        return result
    }else {
        throw new RangeError(value+" can't be converted to meters")
    }
}

/**
 * Converts value from meters to centimeters
 * @param {number}value
 * */
export function toCm(value) {
    if(value>=0){
        let result = value
         if(value>0) result = value*100
        return result
    }else {
        throw new RangeError(value+" can't be converted to centimeters")
    }
}