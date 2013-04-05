using System.Collections.Concurrent;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR;

namespace SwissKnife.SignalR
{
    public abstract class CountingHub : Hub
    {
        private static readonly ConcurrentDictionary<string, bool> _connections = new ConcurrentDictionary<string, bool>();

        public int Count
        {
            get { return _connections.Count; }
        }

        public override Task OnConnected()
        {
            _connections.TryAdd(Context.ConnectionId, true);

            return Task.FromResult<object>(null);
        }

        public override Task OnDisconnected()
        {
            bool value;

            _connections.TryRemove(Context.ConnectionId, out value);

            return Task.FromResult<object>(null);
        }

        public override Task OnReconnected()
        {
            _connections.TryAdd(Context.ConnectionId, true);

            return Task.FromResult<object>(null);
        }
    }
}
