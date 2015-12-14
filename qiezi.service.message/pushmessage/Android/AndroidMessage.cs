using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace qiezi.service.message.pushmessage.Android
{
    /// <summary>
    /// 安卓消息模型
    /// 参考资料：
    /// </summary>
    public class AndroidMessage:IPayload
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string display_type { get; set; }
        public AndroidMessageBody body { get; set; }
    }

    public class AndroidMessageBody
    {
        /// <summary>
        /// [必填]通知栏提示文字
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ticker { get; set; }
        /// <summary>
        /// [必填]通知标题
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        /// <summary>
        /// [必填]通知文字描述
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string text { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string icon { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string largeIcon { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string img { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sound { get; set; }
        /// <summary>
        /// 通知样式，需要在SDK里面实现自定义样式
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public short builder_id { get; set; }
        /// <summary>
        /// 是否震动，默认true
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string play_vibrate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string play_lights { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string play_sound { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string after_open { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string activity { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string custom { get; set; }

    }
}