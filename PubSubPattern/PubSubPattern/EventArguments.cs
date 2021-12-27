using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubPattern
{
    public class EventArguments : EventArgs
    {
        public string Message { get; set; }

        public EventArguments(string message)
        {
            this.Message = message;
        }
    }
}
