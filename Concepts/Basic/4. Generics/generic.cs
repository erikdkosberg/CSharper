using System;
using System.Collections.Generic;

/*

Generics express reusability with a "template" that contains placeholder types;
	-inheritance does this with a base type

*/

namespace Generics
{
	public class Customer
	{
		public int Id {get;set;}
		public string Name {get;set;}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Customer> myCustomers = new List<Customer>(); //empty
			myCustomers.Add(new Customer() {Id=1, Name="Jack"});
			myCustomers.Add(new Customer() {Id=2, Name="Jill"});
			foreach (Customer cust in myCustomers) {
				Console.WriteLine(cust.Name);
			}
		}
	}
}
