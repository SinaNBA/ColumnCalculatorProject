# Column Calculator Project

The Column Calculator Project is a C# console application that can read a CSV or TXT file with two columns of numbers and perform an operation of add, subtract, multiply, divide, exponent or round on each pair of numbers in the columns. The results are printed to the console. 

## Prerequisites

- Microsoft Visual Studio or an equivalent IDE
- .NET Framework

## Usage

The program source code consists of one class: `Program`. 

### Program Class

This class is responsible for handling the user input, file reading, and calculation operations. The methods of this class are described below:

#### Main Method

The `Main` method is the entry point of this console application and starts the program execution. This method includes a while loop that allows the program to continue executing until the user enters a key other than 'c'. Within the loop, the user is prompted to enter the file path and desired operator. The `CalculateColumns` method is called and passed these inputs.

#### CalculateColumns Method

The `CalculateColumns` method reads the CSV or TXT file and performs the desired calculation on each pair of numbers in the columns. The method then returns a list of calculated results. The value of `filePathWithOperatorInput`, which is passed from `Main`, is split into `filePath` and `operatorInput`. The validity of the file path and operator input are verified using the `IsValidExtension` and `IsValidOperator` methods, respectively. The pairs of values within the columns are saved to a `pairs` list, and the specified operation is performed on each using the appropriate method. The contents of the `results` list are printed to the console.

##### Addition Method

The `Addition` method adds the two numbers in each column.

##### Subtraction Method

The `Subtraction` method subtracts the second number in each column from the first.

##### Multiplication Method

The `Multiplication` method multiplies the two numbers in each column.

##### Division Method

The `Division` method divides the first number in each column by the second.

##### Round Method

The `Round` method rounds the sum of the two numbers in each column to the nearest integer.

##### Exponent Method

The `Exponent` method calculates the first number in each column to the power of the second.

#### IsValidExtension Method

The `IsValidExtension` method is responsible for verifying the validity of the file extension. If the file extension is valid, the method returns `true`, otherwise `false`.

#### IsValidOperator Method

The `IsValidOperator` method verifies the validity of the operator input. If the operator input is valid, the method returns `true`, otherwise `false`.

## Authors

This project was created by [Your Name].

## Acknowledgments

[TBD]