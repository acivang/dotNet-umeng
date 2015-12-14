using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace qiezi.service.message.pushmessage
{
    public class PushConfig
    {
        public static string APP_HOST = ConfigurationManager.AppSettings.Get("api-host");
        public static string APP_URL = ConfigurationManager.AppSettings.Get("api-url");
        public static string APP_KEY_IOS = ConfigurationManager.AppSettings.Get("umeng-appkey-ios");
        public static string APP_MASTER_SECRET_IOS = ConfigurationManager.AppSettings.Get("umeng-appmastersecret-ios");
        public static string APP_KEY_ANDROID = ConfigurationManager.AppSettings.Get("umeng-appkey-android");
        public static string APP_MASTER_SECRET_ANDROID = ConfigurationManager.AppSettings.Get("umeng-appmastersecret-android");
        public static string PRODUCTION_MODE = ConfigurationManager.AppSettings.Get("production-mode");
    }
}