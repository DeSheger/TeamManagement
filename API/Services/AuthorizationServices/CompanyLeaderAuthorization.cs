using Domain;
using Microsoft.AspNetCore.Authorization;
using Persistence;
using System.Security.Claims;

namespace API.Services
{
    public class CompanyLeaderRequirement : IAuthorizationRequirement
    {
      
    }

    public class CompanyLeaderAuthorizationHandler : AuthorizationHandler<CompanyLeaderRequirement, Company>
    {
        private readonly DataContext _dbcontext;

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            CompanyLeaderRequirement requirement,
            Company resource)
        {


            var UserIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            int UserId = Convert.ToInt32(UserIdClaim.Value);

            if (UserIdClaim != null && resource != null)
            {
                if(UserId == resource.Leader.Id)
                {
                    context.Succeed(requirement);
                }
                
            }

            return Task.CompletedTask;
        }
    }

}