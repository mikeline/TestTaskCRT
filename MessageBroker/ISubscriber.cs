namespace TestTaskCRT
{
    public interface ISubscriber
    {
        void Receive(IMessage message);
    }
}
