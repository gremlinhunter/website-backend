using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using W3ChampionsStatisticService.Ports;

namespace W3ChampionsStatisticService.Chats
{
    public class ChatHub : Hub
    {
        private readonly IBlizzardAuthenticationService _blizzardAuthenticationService;

        public ChatHub(IBlizzardAuthenticationService blizzardAuthenticationService)
        {
            _blizzardAuthenticationService = blizzardAuthenticationService;
        }

        public async Task SendMessage(string message, string bearer)
        {
            var res = await _blizzardAuthenticationService.GetUser(bearer);
            if (res != null)
            {
                await Clients.All.SendAsync("ReceiveMessage", res.battletag, message);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserLeft", "egal");
        }

        public async Task LoginAs(string bearer)
        {
            var res = await _blizzardAuthenticationService.GetUser(bearer);
            if (res != null)
            {
                var connectedUser = new ChatUser(res.battletag, res.battletag.Split("#")[0]);

                await Clients.Caller.SendAsync("StartChat", new List<ChatUser> { connectedUser });
                await Clients.All.SendAsync("UserEntered", connectedUser.Name, connectedUser.BattleTag);
            }
        }
    }
}