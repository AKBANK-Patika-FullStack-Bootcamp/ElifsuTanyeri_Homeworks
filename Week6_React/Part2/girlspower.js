const girlsPowerSum = (n) =>
{
    return n/2 + 3;
}

const girlsPower = (array) => {

    return array.map((item) => girlsPowerSum(item));
}


console.log(girlsPower([2,3,4]));
console.log(girlsPower([7, 4, 9]))