using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubPattern
{
    public class Publisher
    {
        public string Name { get; set; }

        public event EventHandler<EventArguments> myEvent;

        public void Notify(string message)
        {
            EventArguments args = new EventArguments(message);

            if (myEvent != null)
            {
                myEvent(this, args);
            }

        }
    }
}
