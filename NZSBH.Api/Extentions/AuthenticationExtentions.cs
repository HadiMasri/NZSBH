using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Api.Extentions
{
    public static class AuthenticationExtentions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(
                    JwtBearerDefaults.AuthenticationScheme
                ).AddJwtBearer(options => {
                    var sKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWt:ServerSecret"]));
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = sKey,
                        ValidIssuer = config["JWT:Issuer"],
                         ValidAudience = config["JWT:Issuer"]
                    };
                });
        }
    }
}
