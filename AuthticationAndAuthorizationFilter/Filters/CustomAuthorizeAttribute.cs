using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AuthticationAndAuthorizationFilter.Models;

namespace AuthticationAndAuthorizationFilter.Filters
{
    public class CustomAuthorizeAttribute :AuthorizeAttribute
    {
        private readonly string[] allowedRole;

        public CustomAuthorizeAttribute(params string[] role)
        {
            this.allowedRole = role;

        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if(!String.IsNullOrEmpty(userId))
            {
                using (var context =  new  ApplicationContext() )
                {
                    var userRole = (from u in context.Users
                                    join r in context.Roles on
                                    u.RoleId equals r.Id
                                    where
               u.UserId == userId
                                    select new
                                    {
                                        r.Name

                                    }).FirstOrDefault(); ;

                    foreach (var role in allowedRole)
                    {
                        if (role == userRole.Name) return true;

                }
                }

                
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary {
                        {"controller","Home"},
                        {"action","UnAuthorized" }
                     }
                     );
        }
    }
}