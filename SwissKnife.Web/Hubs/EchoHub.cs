using System;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SwissKnife.Web.Hubs
{
    [HubName("echo")]
    public class EchoHub : Hub
    {
        public void Send()
        {
            Clients.All.Receive(DateTime.Now + ": " + Context.ConnectionId);
        }
    }
}