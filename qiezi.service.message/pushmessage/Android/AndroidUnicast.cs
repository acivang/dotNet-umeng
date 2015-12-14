using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace qiezi.service.message.pushmessage.Android
{
    public class AndroidUnicast:AndroidNotification
    {
        public string DeviceTokens;
        public AndroidMessage Message;

        public AndroidUnicast()
        {
            base.Type = "unicast";
            this.Message = new AndroidMessage {body = new AndroidMessageBody()};
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