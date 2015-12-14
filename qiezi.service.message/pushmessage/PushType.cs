using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qiezi.service.message.pushmessage
{
    public enum PushType
    {
        broadcast,//广播
        unicast,//单播
        listcast,//列播(要求不超过500个device_token)
    }
}