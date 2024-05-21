
    export function MinIfLower (value, min) {
        if (value < min) {
            return min
        }
        return value
    }
    export function MaxIfHigher (value, max) {
        if (value > max) {
            return max
        }
        return value
    }
    
    /**
     * Value is set to min when too low, to max when too high
     * @param {number}value
     * @param {number}min
     * @param {number}max
     **/
    export function InRange (value, min, max) {
       return MaxIfHigher(MinIfLower(value, min), max)
    }
