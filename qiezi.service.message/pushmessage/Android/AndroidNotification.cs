
using System.Threading.Tasks;

namespace qiezi.service.message.pushmessage.Android
{
    public class AndroidNotification:Notification
    {
        private readonly Message _message;

        protected string Type { get; set; }

        public AndroidNotification() : base()
        {
            base.AppMasterSecret = PushConfig.APP_MASTER_SECRET_ANDROID;
            this._message = new Message {appkey = PushConfig.APP_KEY_ANDROID};
        }

        protected async Task<ResponseResult> Push(AndroidMessage androidMessage)
        {
            androidMessage.body = androidMessage.body ?? new AndroidMessageBody();
            androidMessage.display_type = "notification";
            androidMessage.body.ticker = androidMessage.body.ticker ?? androidMessage.body.title;
            androidMessage.body.text = androidMessage.body.text ?? androidMessage.body.title;
            this._message.type = this.Type;
            this._message.payload = androidMessage;
            this._message.description = androidMessage.body.title;
            var result = await this.Send(_message);
            return result;
        }
    }
}