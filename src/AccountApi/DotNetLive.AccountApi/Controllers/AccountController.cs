﻿using DotNetLive.AccountApi.Models;
using DotNetLive.AccountApi.Models.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetLive.AccountApi.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [Authorize()]
    [ProducesResponseType(typeof(LoginResult), 200)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
    public class AccountController : Controller
    {
        //     /account/login[POST] data:{username:string,passwordHash:string[48]
        //}
        //header:[[token:string[64]]]
        [HttpGet, Route("login"), AllowAnonymous]
        public LoginResult Login([FromQuery]string username, [FromQuery]string passwordHash, [FromHeader]string token)
        {
            return new LoginResult()
            {
                UserName = username,
                PasswordHash = passwordHash,
                Token = Guid.NewGuid().ToString()
            };
        }
    }
}
