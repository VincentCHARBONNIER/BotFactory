using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IR2D2
    {
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}