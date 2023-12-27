using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class Edit
    {
        public class Command : IRequest
        {
            public GroupDto EditedGroup;
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
                Group group = _mapper.Map<Group>(request.EditedGroup);

                var existGroup = await _context.Groups
                    .Include(g => g.Company)
                    .Include(g => g.Members)
                    .FirstOrDefaultAsync(g => g.Id == group.Id);

                var existCompany = await _context.Companies
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == existGroup.Company.Id);

                var existMembers = new List<User>();

                User existLeader = null;

                foreach(var companyMember in existCompany.Members)
                {
                    // Check: Is GroupMember in CompanyMembers
                    foreach(var groupMember in group.Members)
                    {
                        if(companyMember.Id == groupMember.Id)
                            existMembers.Add(await _context.Users.FindAsync(groupMember.Id));
                    }
                    // Check: Is Leader in CompanyMembers
                    if(companyMember.Id == group.Leader.Id)
                        existLeader = await _context.Users.FindAsync(group.Leader.Id);
                }

                if(existLeader != null)
                {
                    existGroup.Leader = existLeader;
                } else {
                    return Unit.Value;
                }
                existGroup.Name = group.Name;
                existGroup.Description = group.Description;
                existGroup.Members = existMembers;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}