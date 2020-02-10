using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPortal.Attributes
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var customerID = context.HttpContext.Session.GetString("admin");
            if (string.IsNullOrEmpty(customerID))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
