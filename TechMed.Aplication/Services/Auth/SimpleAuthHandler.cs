using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TechMed.Aplication.Auth
{
    public class SimpleAuthHandler
    {
        
        private readonly RequestDelegate _next;
        public SimpleAuthHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                //context.Response.Headers.Add("WWW-Authenticate", "Basic");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization header is missing");
                return;
            }
            //verrificar se o valor da chave Authoriztion é "Basic username:password" -> "Basic admin:admin"
            var header = context.Request.Headers["Authorization"].ToString();
            var encodedUsernamePassword = header.Substring("Basic ".Length).Trim();
            var usernamePassword = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
            var username = usernamePassword.Split(':')[0];
            var encodedPassword = usernamePassword.Split(':')[1];
            if(username != "admin" || encodedPassword != "admin")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid username or password");
                return;
            }

            await _next(context);

        }
    }
}