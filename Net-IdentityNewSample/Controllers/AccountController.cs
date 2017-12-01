using Net_IdentityNewSample.Models;
using Net_IdentityNewSample.Models.DTO;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Net_IdentityNewSample.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        private readonly ApplicationUserStore _store;
        private readonly ApplicationUserManager _userManager;

        public AccountController()
        {
            _store = new ApplicationUserStore(new ApplicationDbContext());
            _userManager = new ApplicationUserManager(_store);
        }

        [HttpGet]
        [Route("getUserInfo")]
        public HttpResponseMessage GetUserInfo()
        {
            return Request.CreateResponse("Got it");
        }

        [HttpPost]
        [Route("register")]
        public async Task<HttpResponseMessage> RegisterAsync([FromBody] RegisterUserDTO userDTO)
        {
            //If TKey is string, Guid will be generated automatically when ApplicationUser is initialized.
            ApplicationUser user = new ApplicationUser
            {
                UserName = userDTO.userName,
            };

            var result = await _userManager.CreateAsync(user, userDTO.userPassword);

            if (!result.Succeeded)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, result.Errors.First());
            }

            //return Request.CreateResponse($"UserName: {userDTO.userName}, UserPassword: {userDTO.userPassword}");
            return Request.CreateResponse(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login([FromBody] LoginUserDTO data)
        {
            var result = await _userManager.FindAsync(data.userName, data.userPassword);

            return Request.CreateResponse(result);
        }
    }
}
