using Domain;
using Microsoft.AspNetCore.Authorization;
using Persistence;

namespace API.Services
{
    public class CompanyLeaderAuthorization : IAuthorizationRequirement
    {
        public readonly int _companyId;
        public readonly int _userId;
        public CompanyLeaderAuthorization(int userId, int companyId)
        {
            _userId = userId;
            _companyId = companyId;

        }
    }

    public class CompanyLeaderAuthorizationHandler : AuthorizationHandler<CompanyLeaderAuthorization>
    {
        private readonly DataContext _context;
        
        public CompanyLeaderAuthorizationHandler(DataContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,CompanyLeaderAuthorization User)
        {
            User Leader =  _context.Users.Find(User._userId);
            Company Company =  _context.Companies.Find(User._companyId);

            bool isUserALeader = Company.Id == Leader.Id ? true : false;

            if(isUserALeader)
            {
                context.Succeed(User);
            }

            return Task.CompletedTask;
        }
    }

}