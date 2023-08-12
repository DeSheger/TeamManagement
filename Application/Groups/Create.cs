using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using AutoMapper;

namespace Application.Groups
{
    public class Create
    {
        public class Command : IRequest
        {
            public GroupDTO Group;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Group group = _mapper.Map<Group>(request.Group);

                User existLeader = new ();
                Company existCompany = await _context.Companies
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == group.Company.Id);

                var existMembers = new List<User>() { };

                // Check: Is Group Member is in Comapny?
                foreach (var CompanyMember in existCompany.Members)
                {
                    foreach(var GroupMember in group.Members)
                    {
                        if(GroupMember.Id == CompanyMember.Id)
                            existMembers.Add(await _context.Users.FindAsync(GroupMember.Id));
                    }
                    if(CompanyMember.Id == group.Leader.Id) //CHECK: IS LEADER IN COMPANY MEMBERS?
                        existLeader = await _context.Users.FindAsync(CompanyMember.Id);
                }

                var result = new Group()
                {
                    Name = group.Name,
                    Description = group.Description,
                    Company = existCompany,
                    Leader = existLeader,
                    Members = existMembers
                };

                _context.Groups.Add(result);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}