using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using qiezi.service.message.dto;
using qiezi.service.message.pushmessage;
using qiezi.service.message.pushmessage.Android;
using qiezi.service.message.pushmessage.iOS;

namespace qiezi.service.message.service
{
    /// <summary>
    /// 推送服务
    /// </summary>
    public class PushService
    {
        public static async Task<ResponseResult> AndriodBroadcast()
        {
            var andBroadcast = new AndroidBroadcast();
            andBroadcast.Message.body.title = "Aci测试推送！";
            var result = await andBroadcast.Push();
            return result;
        }

        public async Task<ResponseResult> Push(PushMessageDTO dto)
        {
            if (dto.pushType == PushType.broadcast)
            {
                return await Broadcast(dto);
            }
            else
            {
                return await Unicast(dto);
            }
        } 
        private async Task<ResponseResult> Broadcast(PushMessageDTO dto)
        {
            var iosBroadcast = new iOSBroadcast();
            iosBroadcast.Message.aps.alert = dto.title;
            iosBroadcast.Message.go = Enum.GetName(typeof(AfterOpen),dto.go);
            iosBroadcast.Message.goValue = dto.goValue;
            var result = await iosBroadcast.Push();

            if (result.ret == "SUCCESS")
            {
                var androidBroadcast = new AndroidBroadcast();
                androidBroadcast.Message.body.after_open = Enum.GetName(typeof(AfterOpen), dto.go);
                switch (dto.go)
                {
                      case AfterOpen.go_activity:
                        androidBroadcast.Message.body.activity = dto.goValue;
                        break;  
                      case AfterOpen.go_app:
                        break;
                      case AfterOpen.go_url:
                        androidBroadcast.Message.body.url = dto.goValue;
                        break;
                      case AfterOpen.go_custom:
                        androidBroadcast.Message.body.custom = dto.goValue;
                        break;
                }
                androidBroadcast.Message.body.title = dto.title;

                result = await androidBroadcast.Push();
            }

            return result;
        }
        
        private async Task<ResponseResult> Unicast(PushMessageDTO dto)
        {
            if (string.IsNullOrEmpty(dto.deviceTokens))
            {
                throw new ArgumentNullException(dto.deviceTokens);
            }
            if (dto.deviceTokens.Length == 44)
            {
                var androidUnicast = new AndroidUnicast {DeviceTokens = dto.deviceTokens};
                androidUnicast.Message.body.title = dto.title;
                return await androidUnicast.Push();
            }
            else
            {
                var iosUnicast = new iOSUnicast() { DeviceTokens = dto.deviceTokens };
                iosUnicast.Message.aps.alert = dto.title;
                return await iosUnicast.Push();
            }
        }
    }
}