using Net_IdentityNewSample.Models;
using Net_IdentityNewSample.Models.DTO;
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
        private readonly ApplicationUserStore _userStore;
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleStore _roleStore;
        private readonly ApplicationRoleManager _roleManager;

        public AccountController()
        {
            _userStore = new ApplicationUserStore(new ApplicationDbContext());
            _userManager = new ApplicationUserManager(_userStore);

            _roleStore = new ApplicationRoleStore(new ApplicationDbContext());
            _roleManager = new ApplicationRoleManager(_roleStore);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("addRole")]
        public async Task<HttpResponseMessage> AddRole([FromBody]NewRoleDTO data)
        {
            var result = await _roleManager.CreateAsync(new ApplicationRole
            {
                Name = data.RoleName
            });

            return Request.CreateResponse(result);
        }
    }
}
