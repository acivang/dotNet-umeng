using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qiezi.service.content.common
{
    public class PageResult<T>
    {
        public IEnumerable<T> list;
        public int totalPage;
        public int totalItemCount;
    }
}