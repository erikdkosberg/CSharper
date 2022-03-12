using System;

class MyClass
{
	public string MyString {get; set;}
	public int MyInt {get; set;}

	public static MyClass MyClassDoMethod()
	{
		return new MyClass(); // we don't use these
	}
}
class MyClassMethods
{
	public void AddOne(MyClass mc)
	{
		// here we do something with the object mc
		mc.MyInt = mc.MyInt + 1;
		Console.WriteLine("AddOne: " + mc.MyString + " " + mc.MyInt);
	}
	public void DoubleIt(MyClass mc)
	{
		mc.MyInt = mc.MyInt * 2;
		Console.WriteLine("DoubleIt: " + mc.MyString + " " + mc.MyInt);
	}
	public void AppendString(MyClass mc)
	{
		mc.MyString = mc.MyString + " appending string now ";
		Console.WriteLine("AppendString: " + mc.MyString + " " + mc.MyInt);
	}
}
class MyClassProcessor
{
	public int MyAmount {get; set;}
	public delegate void MyClassMethodHandler(MyClass myclass);

	public void Process(MyClassMethodHandler methodHandler)
	{	// methodHandler is a delegate
		// instantiate with object initialization syntax
		var myclass = new MyClass {MyString = "In Process method ", MyInt = 1};
		methodHandler(myclass);
		// we do not define the methods we want to run here because
		// we are going to let the consumer define that
	}
}
class Program
{
	static void Main(string[] args)
	{
		var myclassprocessor = new MyClassProcessor();
		var myclassmethods = new MyClassMethods();
		MyClassProcessor.MyClassMethodHandler methodHandler = myclassmethods.AddOne;
		// MyClassMethodHandler is a delegate (multicast)
		// methodHandler is pointer to a group of functions (delegate)
		methodHandler += myclassmethods.DoubleIt;
		methodHandler += FromConsumerMinusThree;
		methodHandler += myclassmethods.AppendString;

		// Process() takes a delegate
		myclassprocessor.Process(methodHandler);
	}
	static void FromConsumerMinusThree(MyClass myC)
	{
		myC.MyInt = myC.MyInt - 3;
		Console.WriteLine("FromConsumerMinusThree: " + myC.MyString + myC.MyInt);
	}
}
