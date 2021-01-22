using System;


namespace TestTaskCRT
{
    public sealed class CustomSubscriber : ISubscriber
    {
        public string Name { get; set; }


        public CustomSubscriber(string name)
        {
            Name = name;
        }


        void ISubscriber.Receive(IMessage message)
        {
            Console.WriteLine(String.Format("{0}\n\t{1}", Name, message.Content()));
        }
    }
}
