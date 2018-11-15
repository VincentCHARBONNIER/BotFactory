namespace BotFactory.Common.Interface
{
    public interface IUnitFactory
    {
        int QueueCapacity { get; set; }
        int StorageCapacity { get; set; }
    }
}