using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.BusinessLogic;

namespace OutreachFeedback.Web.Rest.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBL _loginBL;

        //The Constructor
        public LoginController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]        
        [Route("Authenticate")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Authenticate([FromBody]Users userParam)
        {
            var user = _loginBL.Authenticate(userParam.UserId
                , userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}