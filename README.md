# Sample project to show C++/CLI AppDomain init error

This shows a bug in C++/CLI runtime if a .net executable loads a .net library in another AppDomain (like nunit does with unit tests), and that library loads a C++/CLI library, that uses another C# library.

If `SimpleTestRunner` is started a runtime exception occurs:
````
The type initializer for '<Module>' threw an exception.'
````

More info here: https://developercommunity.visualstudio.com/content/problem/169359/ccli-dll-is-initialized-in-wrong-appdomain.html

*This bug is still present in 2020, Visual Studio 2019.*
