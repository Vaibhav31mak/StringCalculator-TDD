# String Calculator - TDD Kata (.NET 8)

This repository contains a complete, test-driven implementation of the String Calculator Kata as part of the Incubyte Careers Assessment. It is built using .NET 8, C#, and xUnit with 20+ clean and meaningful commits following the Red → Green → Refactor TDD cycle.

## Problem Statement

Create a method with the signature:
```csharp
int Add(string numbers)
```

It should return the sum of numbers in the input string. The method evolves over time to support various features.

## Features Implemented (Steps)

1. Return 0 for an empty string
2. Return the number itself if only one number is passed
3. Add two comma-separated numbers
4. Add multiple comma-separated numbers
5. Support newline `\n` as a delimiter
6. Support custom single-character delimiters using `//<delimiter>\n`
7. Throw exception for negative numbers, listing all negatives
8. Ignore numbers greater than 1000
9. Support delimiters of any length using `//[***]\n`
10. Support multiple delimiters like `//[*][%]\n`
11. Support multiple delimiters of any length like `//[***][%%]\n`

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Vaibhav31mak/StringCalculator-TDD.git
cd StringCalculator-TDD
```

### 2. Run the Tests

```bash
dotnet test
```

All tests should pass.

## Tech Stack

* .NET 8
* C#
* xUnit (unit testing)
* Test-Driven Development (TDD)

## Project Structure

```
StringCalculator-TDD/
├── StringCalculator/         # Core logic
│   └── Calculator.cs
├── StringCalculator.Tests/   # Unit tests
│   └── CalculatorTests.cs
├── StringCalculator.sln      # Solution file
└── README.md                 # This file
```

## Sample Test Cases

```csharp
Add("") => 0
Add("1") => 1
Add("1,5") => 6
Add("1\n2,3") => 6
Add("//;\n1;2") => 3
Add("-1,2,-4") => Exception "negative numbers not allowed -1,-4"
Add("2,1001") => 2
Add("//[***]\n1***2***3") => 6
Add("//[*][%]\n1*2%3") => 6
Add("//[***][%%]\n1***2%%3") => 6
```

## TDD Cycle

Each feature was added using the TDD approach:

* **Red**: Write a failing test
* **Green**: Make the test pass
* **Refactor**: Clean up code and improve design
* Commit after each step with meaningful messages

## About Incubyte Assessment

This project was developed as part of the **Incubyte Technical Assessment** for software engineering positions. The assessment evaluates candidates on:

* **Test-Driven Development** practices
* **Clean Code** principles
* **Git workflow** and meaningful commit messages
* **Problem-solving** approach with incremental feature development
* **Code quality** and maintainability

## Key Highlights

**100% Test Coverage** - Every feature is backed by comprehensive unit tests  
**Clean Architecture** - Separation of concerns between logic and tests  
**Incremental Development** - Features built step-by-step following TDD  
**Meaningful Commits** - Each commit represents a complete TDD cycle  
**Exception Handling** - Proper error handling with descriptive messages  
**Edge Cases Covered** - Handles empty strings, single numbers, and complex delimiters  

This project was completed as part of the Incubyte technical assessment, which provided an excellent opportunity to practice true Test-Driven Development in a structured environment. Through this exercise, I gained deeper insights into writing clean, maintainable code and learned how incremental development with proper testing can lead to robust software solutions.
