const reverse1 = (str) => {

    let split = str.split("");
    let reversed = split.reverse();
    return reversed;
    
}

const reverse2 = (str) => {

    let arr = Array.from(str).reverse();
    return arr;

}

const reverse3 = (str) => {
    
    let reversed = "";
    for (let char of str) {
         reversed = char + reversed;
    }
    return reversed;

}
const reverse4 = (str) => {

    let reversed = "";
    for (let i = str.length - 1; i >= 0; i--) {
        reversed += str[i];
    }
    return reversed;
    
}


console.log(reverse1("elif"));
console.log(reverse2("elif"));
console.log(reverse3("elif"));
console.log(reverse4("elif"));
