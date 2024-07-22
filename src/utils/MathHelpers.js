export function round(unroundedValue, precision = 5) {
    let roundedValue = unroundedValue;
    console.log(`Rounding x: ${this.x} and y: ${this.y} with precision of ${precision}`)
    if (precision <= 0) throw new RangeError("Cannot round to a precision less than or equal to 0")

    const rest = unroundedValue % precision;
    const restPercentage = (rest / precision) * 100;
    console.log(`Rest: ${rest}, restPercentage: ${restPercentage}`)
    restPercentage >= 50
        ? roundedValue += precision - rest
        : roundedValue -= rest
    return roundedValue;

}