using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Mvc4SampleProject.App_Start.Startup))]

namespace Mvc4SampleProject.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseKentorOwinCookieSaver();

            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "oidc",
                SignInAsAuthenticationType = "Cookies",

                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,
                RedirectUri = "http://localhost:2603/signin-oidc",

                ClientId = "mvc",
                ClientSecret = "secret",
                //ResponseType = OpenIdConnectResponseType.CodeIdTokenToken,

                //Scope = "openid profile api1 offline_access",

                //Notifications = new OpenIdConnectAuthenticationNotifications
                //{
                //    SecurityTokenValidated = notification =>
                //    {
                //        notification.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", notification.ProtocolMessage.IdToken));
                //        notification.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", notification.ProtocolMessage.AccessToken));

                //        return Task.FromResult(0);
                //    },

                //    RedirectToIdentityProvider = notification =>
                //    {
                //        return Task.FromResult(0);
                //    }
                //}
            });
        }
        }
}
