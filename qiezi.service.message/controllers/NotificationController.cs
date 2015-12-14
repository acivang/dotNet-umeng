using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using qiezi.service.message.dto;
using qiezi.service.message.pushmessage;
using qiezi.service.message.service;

namespace qiezi.service.message.controllers
{
    public class NotificationController : ApiController
    {
        private PushService pushService;
        public NotificationController(PushService pushService)
        {
            this.pushService = pushService;
        }

        public async Task<ResponseResult> Post(PushMessageDTO dto)
        {
            var result = await this.pushService.Push(dto);
            return result;
        }
    }
}
