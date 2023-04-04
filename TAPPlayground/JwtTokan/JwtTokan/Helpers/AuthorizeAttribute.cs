
using JwtTokan.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JwtTokan.Helpers
{


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]


    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {

        public string Roles{get; set;}
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            var userRoles =(List<string>)context.HttpContext.Items["userRoles"];
            
            bool status = false;
            
            if (this.Roles!=null){
                var requiredRoles=this.Roles.Split(',').ToList();

            foreach (var role in requiredRoles){
                if(userRoles.Contains(role))
                {status=true;}              
            }
            
            }
            
            
            if (user == null || status==false) 
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

            }


        }
    }


}