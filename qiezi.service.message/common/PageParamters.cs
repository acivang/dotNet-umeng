using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qiezi.service.content.common
{
    public class PageParamters
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string order { get; set; }        
        public string criterias { get; set; }

    }
}