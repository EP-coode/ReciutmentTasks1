function optionalPow(a, b) {
    const userConfirms = confirm("Do you like cats?")
    if (userConfirms) {
        return Math.pow(a, b)
    }
    else {
        return Math.pow(b, a)
    }
}