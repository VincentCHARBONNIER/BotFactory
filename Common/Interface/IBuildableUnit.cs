namespace BotFactory.Common.Interface
{
    public interface IBuildableUnit
    {
        double BuildTime { get; set; }

        string Model { get; set; }
    }
}