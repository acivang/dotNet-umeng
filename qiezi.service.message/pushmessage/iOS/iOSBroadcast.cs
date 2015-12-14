using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qiezi.service.message.pushmessage.iOS
{
    public class iOSBroadcast:iOSNotification
    {
        public iOSMessage Message;

        public iOSBroadcast():base()
        {
            base.Type = "broadcast";
            this.Message = new iOSMessage { aps = new iOSMessageBody() };
        }

        public async Task<ResponseResult> Push()
        {
            return await base.Push(this.Message);
        }
    }
}