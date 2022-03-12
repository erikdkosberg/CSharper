/*
A delegate is an object that 'holds one or more methods.
It is a reference to a function or ordered list of functions
weith a specific signature.

You can 'execute' a delegate and it will execute the method
or methods that it 'contains'.

A delegate is a user-defined reference type, like a class.

You can create your own delegate or use the generic ones,
Func<> and Action<>

*/
using System;

class Program
{
	delegate int Multiplier(int x); // type declaration
	static void Main()
	{
		Multiplier t = Cube; // Create delegate instance
		// by assigning a method to a delegate variable
		int res = t(2); // Invoke delegate: t(3)
		Console.WriteLine(res); // 8
	}
	static int Cube(int x) => x * x * x;
}



