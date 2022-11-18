var num1 = 1;
var num2 = 2;

var sum = num1 + num2;

var boolTrue = true;
var boolFalse = false;

console.log("Num1", num1);
console.log("num1 == boolTrue", num1 == boolTrue);
console.log("num1 === boolTrue", num1 === boolTrue);

var string1 = "this is string";
var string2 = "this is string";
var string3 = `this is ${num1} string`;

console.log("string1", string1);
console.log("string2", string2);
console.log("string3", string3);

var date = new Date();
console.log(date);
console.log(date.toString());
console.log(date.toLocaleString());
console.log(date.toLocaleDateString());
console.log(date.toLocaleTimeString());
console.log(date.toUTCString());
console.log(new Date().getTime());
console.log(new Date().valueOf());
console.log(+new Date());

var nullValue = null;

console.log(nullValue);
console.log(nullValue == num1);
console.log(nullValue == 0);
console.log(nullValue == "");
console.log(nullValue == null);
console.log(nullValue == new Date());
console.log(nullValue === undefined);

var re;
console.log(re);

var obj = {
  a: 1,
  b: "a",
  c: {
    a: 1,
  },
};

console.log(obj.a);
console.log(obj.c.a);

function sumofNumbers(array) {
  var sum = 0;

  for (var index = 0; index < array.length; index++) {
    sum += array[index];
  }

  console.log('Index', index);

  return sum;
}
console.log(sumofNumbers([1, 2, 3, 4, 5]));

var tempArray = [1, -2, 4, -4];
var onlyPositiveNumbers = tempArray.filter((x) => x > 0);
console.log(onlyPositiveNumbers);

var sumN = tempArray.reduce((prev, current) => prev + current);
console.log(sumN);

var pow2 = tempArray.map((x) => x * x);
console.log(pow2);

const constant = 1;
// constant = 2; Error

{
    var glovalScope = 1;
    let localScope = 2;
}

console.log(glovalScope);
console.log(localScope);
