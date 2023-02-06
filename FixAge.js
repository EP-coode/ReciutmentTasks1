function fixage(arr) {
    const result = arr.filter(item => item <= 60 && item >= 18).join(',');
    if (result.length > 0) return result;
    return "NA"
}