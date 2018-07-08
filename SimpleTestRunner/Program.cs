using System;
using System.IO;
using System.Reflection;

namespace SimpleTestRunner
{
	static class Program
	{
		static void Main(string[] args)
		{
			var runner = new AppDomainTestRunner();
			runner.RunTest(
				"..\\Debug",
				"UnitTestLibrary",
				"UnitTestLibrary.UnitTestClass",
				"Test1"
			);
		}
	}

	class AppDomainTestRunner : MarshalByRefObject
	{
		public void RunTest(string testDirectory, string testAssembly, string testClass, string testMethod)
		{
			var domain = AppDomain.CreateDomain("TestDomain", null, Path.GetFullPath(testDirectory), null, false);
			var testRunnerHandle = domain.CreateInstanceFrom(typeof(TestRunner).Assembly.Location, typeof(TestRunner).FullName);
			var testRunner = (TestRunner)testRunnerHandle.Unwrap(); ;
			testRunner.RunTest(testAssembly, testClass, testMethod);
		}

		private Assembly DomainOnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			if (args.Name == this.GetType().Assembly.FullName)
			{
				return this.GetType().Assembly;
			}

			return null;
		}
	}

	class TestRunner : MarshalByRefObject
	{
		public void RunTest(string testAssembly, string testClass, string testMethod)
		{
			var assembly = Assembly.Load(testAssembly);
			var type = assembly.GetType(testClass);
			var instance = Activator.CreateInstance(type);
			var method = type.GetMethod(testMethod);
			method.Invoke(instance, new object[0]);
		}
	}
}
