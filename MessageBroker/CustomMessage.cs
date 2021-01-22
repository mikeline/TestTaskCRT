using System;


namespace TestTaskCRT.MessageBroker
{
    public sealed class CustomMessage : IMessage
    {
        public string Header { get; set; }


        public string Body { get; set; }


        public CustomMessage(string header, string body)
        {
            Header = header;
            Body = body;
        }


        string IMessage.Content()
        {
            return String.Format("{0}: {1}", Header, Body);
        }
    }
}
