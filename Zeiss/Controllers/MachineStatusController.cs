using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeiss.Helper;
using Zeiss.Models;

namespace Zeiss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineStatusController : ControllerBase
    {
        private readonly string _webSocketUrl;

        private readonly ICacheHelper _cacheHelper;

        public MachineStatusController(IConfiguration configuration, ICacheHelper cacheHelper)
        {
            _webSocketUrl = configuration.GetSection("WebSocket").Get<WebSocketSettings>().Url;
            _cacheHelper = cacheHelper;
        }

        [HttpPost]
        public async Task Set()
        {
            try
            {
                HubConnection connection = new HubConnectionBuilder().WithUrl(_webSocketUrl).Build();
                await connection.StartAsync();
                await connection.InvokeAsync("ReportMachineStatus", new ReponseMessage()
                {
                    Topic = "events",
                    Payload = new Payload() { 
                        MachineId = Guid.NewGuid(),
                        Id = Guid.NewGuid(),
                        Timestamp = DateTime.Now,
                        Status = Status.Running,
                    },
                    Event = "new",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ReponseMessage> Get()
        {
            ReponseMessage response = null;

            try
            {
                response = (ReponseMessage)_cacheHelper.GetCacheValue("machine_status");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(response);
        }
    }
}
