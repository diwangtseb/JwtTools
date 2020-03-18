using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplication1.Models.Auth
{
    public class UserIdentity:IIdentity
    {

        public UserIdentity(string id,string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public string Id { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
    }

    public class AppcationUser:IPrincipal
    {
        public AppcationUser(string id,string name)
        {
            Identity = new UserIdentity(id,name);
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; }
    }
}