using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApplication1.Models.Auth;

namespace WebApplication1.Filter
{
    public class MyauthAttribute : Attribute,IAuthorizationFilter
    {
        private IEnumerable<string> headers;

        public bool AllowMultiple
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {

            if (actionContext.Request.Headers.TryGetValues("token", out headers))
            {
                //取得了headers的token
                var LoginName = JwtTools.Decode(headers.First())["LoginName"].ToString();
                var id=JwtTools.Decode(headers.First())["Id"].ToString();
                ((ApiController) actionContext.ControllerContext.Controller).User = new AppcationUser(id, LoginName);

                return await continuation();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
            
        }
    }
}