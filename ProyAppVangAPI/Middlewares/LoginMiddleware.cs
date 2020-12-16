using Microsoft.AspNetCore.Http;
using ProyAppVangAPI.Core.Entities;
using ProyAppVangAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProyAppVangAPI.Middlewares
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public LoginMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isValidRequest = context.Request.Headers.ContainsKey("#login");
            if (isValidRequest)
            {
                var loginInfo = context.Request.Headers["#login"].ToString().Split(":");
                var user = new User
                {
                    Password = loginInfo[1],
                    Username = loginInfo[0]
                };
                if (_userService.Check(user).Result)
                {
                    await _next(context);
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid Request");
            }
        }
    }
}
