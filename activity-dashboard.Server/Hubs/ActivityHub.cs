using Microsoft.AspNetCore.SignalR;

namespace activity_dashboard.Server.Hubs
{
    public class ActivityHub : Hub
    {
        public async Task RefreshGrid()
        {
            await Clients.All.SendAsync("RefreshGrid");
        }
    }
}
