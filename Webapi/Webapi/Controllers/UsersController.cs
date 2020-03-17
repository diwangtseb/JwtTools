using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Webapi.Models;
using JwtTools;

namespace Webapi.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class UsersController : ApiController
    {
        public string Login2(Users users)
        {
            return "登录成功";
        }

        public IHttpActionResult Getmessage()
        {
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public string Login(Users users)
        { 
            if (users != null)
            {
                Dictionary<string, object> userDictionary = new Dictionary<string, object>()
                {
                    {"username", users.Username}
                };
                var encoder = Verify.JwtEncoder(userDictionary,Verify.secret);
                return encoder;
            }
            throw new Exception("账号密码错误");
        }



        [HttpGet]
        [Route("getInfo")]
        public string GetUserInfo()
        {
            
            return  "用户资料";
        }
    }
}
