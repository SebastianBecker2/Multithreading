# Multithreading

[![Build status](https://ci.appveyor.com/api/projects/status/jnlmxljyearwsxr8/branch/master?svg=true)](https://ci.appveyor.com/project/SebastianBecker2/multithreading/branch/master)

Demo apps to show multithreading issues

It contains a Notes.txt file with some links and buzzwords regarding multithreading.
And a power point presentation on how multiple cores can be used for data processing.
As well as four projects, which try to visualize issues that come up when implementing multithread.

IntegerIncrement:
Shows how a simple operation like incrementing an integer in C++ is not an atomic operation by default.

ConcurrentConsoleOutput:
Shows how accessing a shared resource from multiple threads can cause issues. And how those can be solved with locking.

AsyncOperations:
[Not to be confused with C#'s async-await feature] Shows how longer operations can be made asynchronious using a separate thread.
Well... kinda. It just shows that it's possible. It's obviously not best practice to do it that way.

DataProcessing:
Shows how multiple cores can be utilized for complex data processing.
