using System.Net.Http;
using System.Web.Http;

namespace Net_IdentityNewSample.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("getUserInfo")]
        public HttpResponseMessage GetUserInfo()
        {
            return Request.CreateResponse("Got it");
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register()
        {
            return Request.CreateResponse("Got it");
        }
    }
}
