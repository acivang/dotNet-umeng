using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qiezi.service.message.pushmessage;

namespace qiezi.service.message.dto
{
    public class PushMessageDTO
    {
        public PushType pushType;
        public string title;
        public string text;
        public string deviceTokens;
        public AfterOpen go;
        public string goValue;
    }
}