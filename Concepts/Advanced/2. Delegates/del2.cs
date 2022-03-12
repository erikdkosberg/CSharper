using System;

namespace ReturnValues
{
	// Declare a delegate with a return value
	delegate int MyDel();
	class MyClass
	{
		private int IntValue = 5;
		public int Add2() {IntValue += 2; return IntValue;}
		public int Add3() {IntValue += 3; return IntValue;}
	}
	class Program
	{
		static void Main()
		{
			MyClass mc = new MyClass();
			MyDel mDel = mc.Add2; // Create initial delegate
			mDel += mc.Add3; // Add a method
			mDel += mc.Add2;
			Console.WriteLine($"Value: { mDel() }");
		}
	}
}
