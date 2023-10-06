using Domain;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API.Services.AuthorizationServices
{
    public class GroupLeaderRequirement : IAuthorizationRequirement
    {
    }

    public class GroupLeaderAuthorization : AuthorizationHandler<GroupLeaderRequirement, Group>
    {
        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, GroupLeaderRequirement requirement, Group resource)
        {
            var UserIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
            int UserId = Convert.ToInt32(UserIdClaim.Value);

            if (UserIdClaim != null && resource != null)
            {
                if (UserId == resource.Leader.Id)
                {
                    context.Succeed(requirement);
                }

            }

            return Task.CompletedTask;
        }
    }
}
