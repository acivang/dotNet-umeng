
using System.Threading.Tasks;

namespace qiezi.service.message.pushmessage.Android
{
    public class AndroidBroadcast: AndroidNotification
    {
        public AndroidMessage Message;

        public AndroidBroadcast():base()
        {
            base.Type = "broadcast";
            this.Message = new AndroidMessage {body = new AndroidMessageBody()};
        }

        public async Task<ResponseResult> Push()
        {
            return await base.Push(this.Message);
        }
    }
}