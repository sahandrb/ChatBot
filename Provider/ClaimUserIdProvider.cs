using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ChatBot.Provider
{
    public class ClaimUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            throw new NotImplementedException();
        }

        public string GetUserIdHub(HubCallerContext context)
        {
            var userId = context.User?.FindFirst("Id")?.Value;
            return userId ?? string.Empty;
        }
    }
}
