using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Persistence;
using System.Security.Claims;

namespace API.Services
{
    public class CompanyLeaderRequirement : IAuthorizationRequirement
    {
      
    }

    public class CompanyLeaderAuthorizationHandler : AuthorizationHandler<CompanyLeaderRequirement, CompanyDTO>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            CompanyLeaderRequirement requirement,
            CompanyDTO resource)
        {
            if(context.User.Identity?.Name == resource.Leader.Name)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}