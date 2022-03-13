using System;
using System.Collections.Generic;

namespace test {

public class Item
{
	public string Name {get; set;} // a property
}

public class ItemEventArgs : EventArgs
{
	public Item Item {get; set;}
}
public class ItemProcessor
{
	//public delgate void ItemProcessedEventHandler(object source, ItemEventArgs args);
	public event EventHandler<ItemEventArgs> ItemProcessed;
	
	public void ProcessItem(Item item)
	{
		Console.WriteLine("Processing Item...");
		System.Threading.Thread.Sleep(1500); // delay 1.5 seconds
		OnItemProcessed(item);
	}
	protected virtual void OnItemProcessed(Item item)
	{
		ItemProcessed?.Invoke(this, new ItemEventArgs() {Item = item});
		// if (ItemProcessed != null)
		//ItemProcessed(this, new ItemEventArgs() {Item = item});
	}
}
public class SubscriberOne
{
	public void OnItemProcessed(object source, ItemEventArgs args)
	{
		Console.WriteLine("SubscriberOne: " + args.Item.Name);
	}
}
public class SubscriberTwo
{
	public void OnItemProcessed(object source, ItemEventArgs args)
	{
		Console.WriteLine("SubscriberTwo: " + args.Item.Name);
	}
}
class Program
{
	static void Main(string[] args)
	{
		var item = new Item() {Name = "Item 1 name"};
		var itemProcessor = new ItemProcessor(); // Publisher
		var subscriberOne = new SubscriberOne(); // Subscriber
		var subscriberTwo = new SubscriberTwo(); // Subscriber

		Console.WriteLine("Beginning program EventsExample...");

		// itemProcessed is a list of pointers to methods
		itemProcessor.ItemProcessed += subscriberOne.OnItemProcessed;
		itemProcessor.ItemProcessed += subscriberTwo.OnItemProcessed;

		itemProcessor.ProcessItem(item);
	}
}
}
