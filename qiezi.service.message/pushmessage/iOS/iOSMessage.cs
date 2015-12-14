using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace qiezi.service.message.pushmessage.iOS
{
    public class iOSMessage:IPayload
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string go { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string goValue { get; set; }
        public iOSMessageBody aps { get; set; }
    }

    public class iOSMessageBody
    {
        /// <summary>
        /// 通知文本
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string alert { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public short badge { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sound { get; set; }
    }
}