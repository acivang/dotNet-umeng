using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace qiezi.service.message.pushmessage
{
    public class Message
    {
        /// <summary>
        /// [必填]
        /// </summary>
        public string appkey { get; set; }
        /// <summary>
        /// [必填]
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// [必填]
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// [选填]
        /// [必填]type为unicast，单个设备； 
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string device_tokens { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IPayload payload { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string production_mode { get; set; }
        /// <summary>
        /// 发送消息描述
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
    }
}