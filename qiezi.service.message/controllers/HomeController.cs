using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using qiezi.service.message.service;

namespace qiezi.service.content.controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        public async Task<OkNegotiatedContentResult<string>> Get()
        {
            return Ok("茄子云消息服务");
        }
    }
}
