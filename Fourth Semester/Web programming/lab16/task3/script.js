function convert10to2(number) {
    var input = document.getElementById("input").value;
    input = input.replace(/\s+/g, '');

    let num = input;
    let bin = (num % 2).toString();
    for (; num > 1;) {
        num = parseInt(num / 2);
        bin = (num % 2) + (bin);
    }
    document.getElementById("input").value = bin;
}
function convert2to10() {
    var input = document.getElementById("input").value;
    input = input.replace(/\s+/g, '');
    document.getElementById("input").value = parseInt(input, 2);
}

function factorial(number) {
    return (number !== 1) ? number * factorial(number - 1) : 1;
}
function calculateFactorial() {
    var input = document.getElementById("input").value;
    input = input.replace(/\s+/g, '');
    document.getElementById("input").value = factorial(input);
}
function clearInput() {
    document.getElementById("input").value = '';
}
function calculate() {
    var input = document.getElementById("input").value;

    input = input.replace(/\s+/g, '');

    try {
        document.getElementById("input").value = eval(input);
    } catch (error) {
        document.getElementById("input").value = error.message;
    }
}
