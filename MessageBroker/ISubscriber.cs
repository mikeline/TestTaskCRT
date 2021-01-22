namespace TestTaskCRT.MessageBroker
{
    public interface ISubscriber
    {
        void Receive(IMessage message);
    }
}
