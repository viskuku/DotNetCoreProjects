using System;

namespace PubSubPattern
{
    public class Subscriber
    {
        public void Subscribe(Publisher publisher)
        {
            publisher.myEvent += update;
        }

        public void UnSubscribe(Publisher publisher)
        {
            publisher.myEvent -= update;
        }

        public void update(object sender, EventArguments args)
        {
            var pub = (Publisher)sender;

            Console.WriteLine($"{pub.Name} sent a message: {args.Message}");
        }

    }
}
