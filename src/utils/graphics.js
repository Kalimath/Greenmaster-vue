/**
 * Returns distance between two points
 *
 * @param {Point}pointA
 * @param {Point}pointB
 * @return {number}
 * */
import Point from "@/model/Point";

export function pythagoras(pointA, pointB) {
    let a = pointA.x - pointB.x;
    let b = pointA.y - pointB.y;

    return Math.sqrt((a*a)+(b*b));
}

/**
 * Calculates distance between first and second coordinate.
 * Can be used to get the distance between x or y coordinates of point A and b
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
 * @param {Point}firstPoint
 * @param {Point}secondPoint
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
 * Converts real to scaled point coordinates (2 digit precision)
 *
 * @param {Point}point
 * @param {number}scaleFactor
 * @return {Point}
 * */
export function scalePoint(point, scaleFactor) {
    if(!point) throw new TypeError("point coordinates can't be scaled: given point is empty/invalid")
    validateScaleFactor(scaleFactor)
    return new Point(toScaled(point.x,scaleFactor),toScaled(point.y,scaleFactor))
}

/**
 * Converts scaled to real point coordinates (2 digit precision)
 *
 * @param {Point}point
 * @param {number}scaleFactor
 * @return {Point}
 * */
export function scalePointToReal(point, scaleFactor) {
    if(!point) throw new TypeError("scaled point coordinates: given point is empty/invalid")
    validateScaleFactor(scaleFactor)
    return new Point(fromScaled(point.x,scaleFactor),fromScaled(point.y,scaleFactor))
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
 * Converts svg to cartesian point coordinates (2 digit precision)
 *
 * @param {Point}svgPoint
 * @param {number}svgHeight
 * @return {Point}
 * @throws RangeError
 * */
export function svgToCartesian(svgPoint, svgHeight) {
    if(svgPoint){
        return new Point(svgPoint.x, svgHeight-svgPoint.y)
    }else{
        throw new RangeError("svgPoint is null invalid/empty")
    }
}

/**
 * Converts cartesian to svg point coordinates (2 digit precision)
 *
 * @param {Point}cartesianPoint
 * @param {number}svgHeight
 * @return {Point}
 * @throws RangeError
 * */
/*
export function cartesianToSvg(cartesianPoint, svgHeight) {
    if(svgPoint){
        return new Point(cartesianPoint.x, svgHeight-cartesianPoint.y)
    }else{
        throw new RangeError("cartesianPoint is null invalid/empty")
    }
}*/
