using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace OutreachFeedback.Web.BusinessLogic
{
    public class LoginBL : ILoginBL
    {
        private IOutreachFeedbackDbContext _context;

        private readonly AppSettings _appSettings;

        public LoginBL(IOutreachFeedbackDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// The Business Logic  for Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Users Authenticate(int username,string Password)
        {
            var user = _context.Users.SingleOrDefault(m => m.UserId == Convert.ToInt32(username) && m.Password == Password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
