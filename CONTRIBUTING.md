# Contributing

- Follow the naming convention `LeetCode{Id}_{ShortName}` for problem classes.
- Keep implementations small and add a `Run()` example wrapper for the console runner.
- Add unit tests under `tests/Problems.Tests` using NUnit. Prefer parameterized tests when possible.
- Update ProblemRegistry only if you need custom discovery; otherwise the reflection-based discovery will find classes named `LeetCode*`.

Thank you for contributing!