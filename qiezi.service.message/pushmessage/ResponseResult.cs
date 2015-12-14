using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qiezi.service.message.pushmessage
{
    public class ResponseResult
    {
        public string ret { get; set; }
        public ResultData data { get; set; }
    }

    public class ResultData
    {
        public string error_code { get; set; }
        public string task_id { get; set; }
    }
}