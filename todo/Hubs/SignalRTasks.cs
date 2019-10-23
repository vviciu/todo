using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace todo.Hubs
{
    public class TasksHub : Hub //RH: Standardowa konwencja w przypadku Hubów jest analogiczna do kontrolerów więc sugerowałbym TasksHub
    {
        public async Task SendMessageToRefreshTableWithTasks(string message) //RH: Polska zmienna? Nieładnie ;)
        {
            await Clients.All.SendAsync("ReceiveMessageToRefreshTableWithTasks", message);
        }
    }
}
