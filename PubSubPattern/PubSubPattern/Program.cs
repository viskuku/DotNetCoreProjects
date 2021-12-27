using System;
//This is observer pattern
namespace PubSubPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Publisher pub1 = new Publisher();
            pub1.Name = "Pub1";

            Subscriber sub1 = new Subscriber();
            sub1.Subscribe(pub1);

            pub1.Notify("Called by Pub1");

            Console.ReadLine();
        }
    }
}
