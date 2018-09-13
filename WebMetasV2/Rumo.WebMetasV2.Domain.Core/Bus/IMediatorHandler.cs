using Rumo.WebMetasV2.Domain.Core.Commands;
using Rumo.WebMetasV2.Domain.Core.Events;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
