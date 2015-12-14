using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace qiezi.service.message.pushmessage.iOS
{
    public class iOSUnicast:iOSNotification
    {
        public string DeviceTokens;
        public iOSMessage Message;

        public iOSUnicast()
        {
            base.Type = "unicast";
            this.Message = new iOSMessage { aps = new iOSMessageBody() };
        }

        public async Task<ResponseResult> Push()
        {
            if (string.IsNullOrEmpty(DeviceTokens))
            {
                throw new ArgumentNullException(DeviceTokens);
            }
            return await base.Push(this.Message);
        }
    }
}