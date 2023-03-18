using System;
using System.IdentityModel.Tokens.Jwt;
using MediatR;

namespace ConcentraVHM.Application.Features.User.Commands
{
	public class LoginCommand:IRequest<JwtSecurityToken>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

