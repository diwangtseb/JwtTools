using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApplication1.Filter;
using WebApplication1.Models;
using WebApplication1.Models.Auth;

namespace WebApplication1.Controllers
{
    /**
     *1.通过过滤来控制访问
     *2.通过加密解密来取得token判断用户
     *3.将Userid存入identity.id中
     */
    public class UsersController : ApiController
    {
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                var Encode=JwtTools.Encode(new Dictionary<string, object>() {{"LoginName", loginView.Loginname}, {"Id",loginView.Id} }, "778");
                return Ok(Encode);
            }
            throw new Exception();
        }

        [Route("getInfo")]
        [Myauth]
        public string getInfo()
        {
            return ((UserIdentity)User.Identity).Id;
        }
    }
}
