using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IHAL
    {
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}