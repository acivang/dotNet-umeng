using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace qiezi.service.message.pushmessage.iOS
{
    public class iOSNotification:Notification
    {
        private Message _message;

        protected string Type;

        public iOSNotification() : base()
        {
            this._message = new Message();
            this._message.appkey = PushConfig.APP_KEY_IOS;
            this.AppMasterSecret = PushConfig.APP_MASTER_SECRET_IOS;
        }

        public async Task<ResponseResult> Push(iOSMessage iosMessage)
        {
            this._message.payload = iosMessage;
            this._message.type = this.Type;
            this._message.description = iosMessage.aps.alert;
            var result = await this.Send(_message);
            return result;
        }
    }
}