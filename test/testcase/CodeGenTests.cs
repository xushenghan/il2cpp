﻿
using System;

namespace testcase
{
	class CodeGenAttribute : Attribute
	{
	}

	[CodeGen]
	static class HelloWorld
	{
		public static int Entry()
		{
			return 42;
		}
	}
	
	static class Fibonacci
	{
		static long Fib(int n)
		{
			if (n < 2)
				return n;
			else
				return Fib(n - 1) + Fib(n - 2);
		}

		public static long Entry()
		{
			return Fib(50);
		}
	}
}
