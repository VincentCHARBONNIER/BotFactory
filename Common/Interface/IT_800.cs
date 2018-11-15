using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IT_800
    {
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}