using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace todo.Hubs
{
    public class SignalRTasks : Hub
    {
        public async Task SendMessageToRefreshTableWithTasks(string komunikat)
        {
            await Clients.All.SendAsync("ReceiveMessageToRefreshTableWithTasks", komunikat);
        }
    }
}
