/**
 * Returns distance between two vertices
 *
 * @param {Vertex}vertexA
 * @param {Vertex}vertexB
 * @return {number}
 * */


import Vertex from "@/models/Vertex";

export function pythagoras(vertexA, vertexB) {
    let a = vertexA.x - vertexB.x;
    let b = vertexA.y - vertexB.y;

    return Math.sqrt((a*a)+(b*b));
}

/**
 * Calculates distance between first and second coordinate.
 * Can be used to get the distance between x or y coordinates of vertex A and b
 *
 * @param {number}first
 * @param {number}second
 * @return {number}
 * */
export function getDistanceBetweenTwoCoordinates(first, second) {
    let delta = 0
    try {
        if(second>first){
            delta = Math.abs(second-first);
        }else{
            delta = Math.abs(first-second);
        }
    } catch (error) {
        throw new EvalError(`distance between coordinates is invalid: (${first}, ${second}))`)
    }

    if(delta===0) throw new RangeError("distance between coordinates is zero")
    return delta
}
/**
 * Converts scaled points to correct arrangement
 *
 *  - firstPoint will represent lower-left corner
 *  - secondPoint will represent upper-right corner
 *
 * @param {Vertex}firstPoint
 * @param {Vertex}secondPoint
 * */
export function arrangePoints(firstPoint, secondPoint) {
    // if true mirror over x axes
    if(firstPoint.givenCoordinateIsHigherThan(true, secondPoint)){
        const firstX = firstPoint.x
        firstPoint.x = secondPoint.x
        secondPoint.x = firstX
    }
    // if true mirror over y axes
    if(secondPoint.givenCoordinateIsHigherThan(false, firstPoint)){
        const firstY = firstPoint.y
        firstPoint.y = secondPoint.y
        secondPoint.y = firstY
    }
}

/**
 * Converts scaled value to real (2 digit precision)
 *
 * @param {number}value
 * @param {number}scaleFactor
 * @return {number}
 * */
export function fromScaled(value, scaleFactor) {
    validateScaleFactor(scaleFactor)
    return parseFloat((value/scaleFactor).toFixed(2));
}

/**
 * Converts real to scaled value (2 digit precision)
 *
 * @param {number}value
 * @param {number}scaleFactor
 * @return {number}
 * */
export function toScaled(value, scaleFactor) {
    validateScaleFactor(scaleFactor)
    return parseFloat((value*scaleFactor).toFixed(2));
}

/**
 * Converts real to scaled vertex coordinates (2 digit precision)
 *
 * @param {Vertex}vertex
 * @param {number}scaleFactor
 * @return {Vertex}
 * */
export function scaleVertex(vertex, scaleFactor) {
    if(!vertex) throw new TypeError("vertex coordinates can't be scaled: given vertex is empty/invalid")
    validateScaleFactor(scaleFactor)
    return new Vertex(toScaled(vertex.x,scaleFactor),toScaled(vertex.y,scaleFactor))
}

/**
 * Converts scaled to real vertex coordinates (2 digit precision)
 *
 * @param {Vertex}point
 * @param {number}scaleFactor
 * @return {Vertex}
 * */
export function scalePointToReal(point, scaleFactor) {
    if(!point) throw new TypeError("scaled vertex coordinates: given vertex is empty/invalid")
    validateScaleFactor(scaleFactor)
    return new Vertex(fromScaled(point.x,scaleFactor),fromScaled(point.y,scaleFactor))
}

/**
 * throws exception when scaleFactor is not greater than zero
 *
 * @param {number}scaleFactor
 * @throws RangeError
 * */
export function validateScaleFactor(scaleFactor) {
    if(scaleFactor<=0) throw new RangeError("scaleFactor must be greater than zero")
}

/**
 * Converts svg to cartesian vertex coordinates (2 digit precision)
 *
 * @param {Vertex}svgPoint
 * @param {number}svgHeight
 * @return {Vertex}
 * @throws RangeError
 * */
export function svgToCartesian(svgPoint, svgHeight) {
    if(svgPoint){
        return new Vertex(svgPoint.x, svgHeight-svgPoint.y)
    }else{
        throw new RangeError("svgPoint is null invalid/empty")
    }
}

/**
 * Converts cartesian to svg vertex coordinates (2 digit precision)
 *
 * @param {Vertex}cartesianPoint
 * @param {number}svgHeight
 * @return {Vertex}
 * @throws RangeError
 * */
/*
export function cartesianToSvg(cartesianPoint, svgHeight) {
    if(svgPoint){
        return new Vertex(cartesianPoint.x, svgHeight-cartesianPoint.y)
    }else{
        throw new RangeError("cartesianPoint is null invalid/empty")
    }
}*/
