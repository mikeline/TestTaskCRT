namespace TestTaskCRT
{
    public sealed class MessageBroker
    {
        private delegate void MessageHandler(IMessage message);


        private event MessageHandler MessagePosted;
        
        
        public void Post(IMessage message)
        {
            MessagePosted?.Invoke(message);
        }


        public void Subscribe(ISubscriber subscriber)
        {
            MessagePosted += subscriber.Receive;
        }
        
        
        public void Unsubscribe(ISubscriber subscriber)
        {
            MessagePosted -= subscriber.Receive;
        }

    }
}
