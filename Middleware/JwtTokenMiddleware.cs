using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace dotnetMB.Middleware
{
    public class JwtTokenMiddleware
    {
    private readonly RequestDelegate _next;

    public JwtTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Cookies["AuthToken"]; // Recupera o token do cookie

        if (!string.IsNullOrEmpty(token))
        {
             var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Essa e a chave secreta do MvcMovie"); 
            
            try
            {
                // Configura os parâmetros de validação do token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };

                // Tenta validar o token
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // Se o token for válido, você pode inseri-lo no contexto da solicitação para que outras partes do aplicativo possam acessá-lo
                context.Items["AuthToken"] = token;
            }
            catch (SecurityTokenValidationException)
            {
                // Token inválido
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
            catch (Exception)
            {
                // Outro erro
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return;
            }
        }

        await _next(context);
    }
    }
}