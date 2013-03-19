using System;
using System.Collections.Concurrent;

using Microsoft.AspNet.SignalR.Hubs;

namespace SwissKnife.SignalR
{
    public class RateLimitingModule : HubPipelineModule
    {
        public RateLimitingModule()
        {
            Interval = 1000;
        }

        public int Interval { get; set; }

        private readonly ConcurrentDictionary<string, DateTime> _connections = new ConcurrentDictionary<string, DateTime>();

        protected override void OnAfterDisconnect(IHub hub)
        {
            DateTime lastDateTime;

            _connections.TryRemove(hub.Context.ConnectionId, out lastDateTime);
        }

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            var now = DateTime.Now;
            var connectionId = context.Hub.Context.ConnectionId;

            DateTime lastDateTime;

            if (_connections.TryGetValue(connectionId, out lastDateTime))
            {
                var span = now - lastDateTime;

                if (span.TotalMilliseconds < Interval)
                {
                    return false;
                }
            }

            _connections.AddOrUpdate(connectionId, now, (_, __) => now);

            return true;
        }

    }
}
