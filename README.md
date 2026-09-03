# FaangPrep - LeetCode Practice

This folder contains a LeetCode practice solution. Structure:

- src/Problems: class library containing problem implementations. Each problem uses the filename/class `LeetCode{Id}_{ShortName}`.
- LeetCode: console runner project that provides an interactive menu to run problems.
- tests/Problems.Tests: NUnit tests for problems.

How to add a problem:
1. Create a new class in src/Problems named `LeetCode{Id}_{ShortName}.cs`.
2. Implement problem logic as a public method (e.g., `int[] TwoSum(int[] nums, int target)`).
3. Add a public `string Run()` method (instance or static) that executes an example and returns a string; ProblemRegistry will use this for the console runner.
4. Add tests in tests/Problems.Tests.

How to run locally:
- Open the solution in Visual Studio or run `dotnet build` from repo root.
- Launch the `LeetCode` console project to use the interactive menu.
- Run `dotnet test` to execute tests.
