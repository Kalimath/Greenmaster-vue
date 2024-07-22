export function round(unroundedValue, precision = 5) {
    let roundedValue = unroundedValue;
    if (typeof unroundedValue !== "number") throw new TypeError("Input value must be a number")
    if (precision <= 0) throw new RangeError("Precision must be a positive integer")
    if (precision <= 0) throw new RangeError("Cannot round to a precision less than or equal to 0")

    const rest = unroundedValue % precision;
    const restPercentage = (rest / precision) * 100;
    restPercentage >= 50
        ? roundedValue += precision - rest
        : roundedValue -= rest
    return roundedValue;

}