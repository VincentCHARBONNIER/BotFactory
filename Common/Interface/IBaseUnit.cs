using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        Coordinates CurrentPos { get; set; }
        string Name { get; set; }
        double Speed { get; set; }

        Task<bool> Move(Coordinates beginPos, Coordinates endPos);
    }
}