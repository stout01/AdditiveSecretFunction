# Additive Secret Function
You are given a function 'secret()' that accepts a single integer parameter and returns an integer. In C#, write a command-line program that takes one command-line argument (a number) and determines if the secret() function is additive [secret(x+y) = secret(x) + secret(y)], for all combinations x and y, where x and y are all prime numbers less than the number passed via the command-line argument.  Describe how to run your examples. Please generate the list of primes without using built-in functionality.
## Usage
`AdditiveSecretFunction.exe -l 100000`
### Command Line Arguments
```
-l, --limit    (Default: 1000) Integer to determine the maximum prime number

-h, --help     Display this help screen.
```