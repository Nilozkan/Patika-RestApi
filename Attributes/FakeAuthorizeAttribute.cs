
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestApi.Attributes
{
    public class FakeAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            if (!headers.ContainsKey("Fake-Token") || headers["Fake-Token"] != "12345")
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}