using Microsoft.AspNetCore.SignalR;
using System.IO;
using System.Threading.Tasks;
using Zeiss.Helper;
using Zeiss.Models;

namespace Zeiss.Hubs
{
    /// <summary>
    /// 接线器
    /// </summary>
    public class ServiceHub : DynamicHub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public void ReportMachineStatus(ReponseMessage reponseMessage)
        {
            MemoryCacheHelper.SetChacheValue("machine_status", reponseMessage);
        }
    }
}
