using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Common.Interface
{
    public interface IWorkingUnit
    {
        bool IsWorking { get; set; }
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }

        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}