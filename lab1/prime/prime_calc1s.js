/*
student version with NO assertion tests or refactoring implemented
*/
const max = 1000;   // Set upper bounds
const min = 0;      // Set lower bounds
let check4prime;    // global object
let primeBucket;    // global object

class Check4Prime {

    /*
    Calculates prime numbers and put true or false in an array
    */
    primeCheck(num) {
        // Initialize array to hold prime numbers
        if (primeBucket == null) {
            primeBucket = new Array(max + 1);

            // Initialize all elements to true, non-primes will be set to false later
            for (let i = 2; i <= max; i++) {
                primeBucket[i] = true;
            }

            // Do all multiples of 2 first
            let j = 2;
            for (let i = j+j; i <= max; i = i+j) { // start with 2j as 2 is prime
                primeBucket[i] = false; // set all multiples of 2 to false
            }

            for (j = 3; j <= Math.sqrt(max); j = j+2) { // begin from 3 up to max
                if (primeBucket[j] === true) { // only do if primeBucket[j] is still a prime (not a multiple of 3, 5, 7, ...)
                    for (let i = j+j; i <= max; i = i+j) { // start with 2j as j is a prime
                        primeBucket[i] = false; // set all multiples of the prime to false
                    }
                }
            }
        }

        // Check input against prime array
        return primeBucket[num] === true;
    }


    /*
    Method to validate input
    */
    checkArgs() {
        // Check arguments for correct number of parameters if not throw new Error();
        if (arguments.length !== 1) {
            throw new Error(`ValueError: Expected 1 input got: ${arguments.length}`)
        }
        else 
        {
            for (let i = 0; i < arguments.length; i++) {
                let v = arguments[i];
                if (v === undefined) throw new TypeError(`Input Variable ${i} had an undefined value type!`)
                if (v.empty() || v === 0) throw new SyntaxError(`Input Variable ${i} was found to be either empty or 0`)
                if (typeof v != "number") throw new TypeError(`Input Variable ${i} was found to not of expected type 'number'`)

                v = arguments[i][0]
                if (typeof v != "number") throw new TypeError(`Input Variable ${i} was found to not of expected type 'number'`)
                if (v < min) throw new Error(`OutOfBoundsException: Value ${v} for variable ${i} was outside of the expected lower-bounds`)
                if (v > max) throw new Error(`OutOfBoundsException: Value ${v} for variable ${i} was outside of the expected lower-bounds`)
            }
        }
    }
}


/*
do the automated tests cases when developer performs test
*/
function checkTest(num) {
    check4prime = new Check4Prime();
    // run various automated tests
    test_Check4Prime_primeCheck_known_true();
    test_Check4Prime_primeCheck_known_false();
    test_Check4Prime_checkArgs_neg_input(-1);
    test_Check4Prime_checkArgs_above_upper_bound(10001);
    test_Check4Prime_checkArgs_char_input("r");
    test_Check4Prime_checkArgs_2_inputs(5, 99);
    test_Check4Prime_checkArgs_zero_input();
    test_Check4Prime_checkArgs_undefined_input(undefined);
    test_Check4Prime_checkArgs_non_integer_input(17.5);
}

/*
do the check for prime when ordinary user is running solution, you can merge this function with checkTest() if you want
*/
function check(num) {
    check4prime = new Check4Prime();
    try {
        check4prime.checkArgs(parseInt(num));
        assert(check4prime.primeCheck(num), description)
    }
    catch (err) {
        let description = `Input/number: ${num}. Error in checkArgs()`;
        assert(check4prime.primeCheck(num), description);
    }
}


/*
append test result in list on web page 
*/
function assert(outcome, description) {
    let output = document.querySelector('#output'); 
    let li = document.createElement('li'); 
    li.className = outcome ? 'pass' : 'fail'; 
    li.appendChild(document.createTextNode(description)); 
    output.appendChild(li); 
}

/*
Test methods, recommended naming convention
(Test)_MethodToTest_ScenarioWeTest_ExpectedBehaviour
In test method the pattern we use is "triple A"
Arrange, Act and Assert
*/


// Test case 1, check known true primes
function test_Check4Prime_primeCheck_known_true() {
    let known_prime = [997, 29, 17, 3]
    while(known_prime.length > 0) {
        let i = known_prime.pop()
        if (check4prime.primeCheck(i)) {
            assert(true, `Test for known true primes with: ${i}`)
        } else {
            assert(false, `Test for known true primes with: ${i}`)
        }
    }
}

// Test case 2, check known false primes
function test_Check4Prime_primeCheck_known_false() {
    let known_not_prime = [49, 27, 4, 0]
    while(known_not_prime.length > 0) {
        let i = known_not_prime.pop()
        if (!check4prime.primeCheck(i)) {
            assert(true, `Test for known false primes with: ${i}`)
        } else {
            assert(false, `Test for known false primes with: ${i}`)
        }
    }
}

// Test case 3, check negative input
function test_Check4Prime_checkArgs_neg_input() {
    if (parseInt(arguments[0]) <= 0) {
        assert(true, `Test for negative input: ${arguments[0]}`)
    } else {
        assert(false, `Test for negative input: ${arguments[0]}`)
    }
}

// Test case 4, check for upper bound limit
function test_Check4Prime_checkArgs_above_upper_bound() {
    if (parseInt(arguments[0]) > max) {
        assert(true, `Test for upper bound limit: ${arguments[0]}`)
    } else {
        assert(false, `Test for upper bound limit: ${arguments[0]}`)
    }
}

// Test case 5, check for char input
function test_Check4Prime_checkArgs_char_input() {
    let arg = arguments[0]
    if (typeof(arg) == 'string' && arg.length === 1 && arg.match(/[a-z]/i)) {
        assert(true, `Test for char input: ${arguments[0]}`)
    } else {
        assert(false, `Test for char input: ${arguments[0]}`)
    }

}

function getArgumentString(args) {
    let s = ""
    for (let arg in args) {
        s += String(args[arg])
        s += ", "
    }
    return s
}

// Test case 6, check for more than one input
function test_Check4Prime_checkArgs_2_inputs() {
    let s = getArgumentString(arguments)
    if (arguments.length > 1) {
        assert(true, `Test for more than one input: ${s}`)
    } else {
        assert(false, `Test for more than one input: ${s}`)
    }
}

// Test case 7, check for zero/empty input
function test_Check4Prime_checkArgs_zero_input() {
    let s = getArgumentString(arguments)
    if (arguments.length === 0) {
        assert(true, `Test for zero/empty input: ${s}`)
    } else {
        assert(false, `Test for zero/empty input: ${s}`)
    }
}

// Test case 8, check for undefined input
function test_Check4Prime_checkArgs_undefined_input() {
    if (arguments[0] === undefined) {
        assert(true, `Test for undefined input: ${arguments[0]}`)
    } else {
        assert(false, `Test for undefined input: ${arguments[0]}`)
    }
}

// Test case 9, check for non-integer input
function test_Check4Prime_checkArgs_non_integer_input() {
    if (!Number.isInteger(arguments[0])) {
        assert(true, `Test for non-integer input: ${arguments[0]}`)
    } else {
        assert(false, `Test for non-integer input: ${arguments[0]}`)
    }
}