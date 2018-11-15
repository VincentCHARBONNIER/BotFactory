using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IWall_E
    {
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}