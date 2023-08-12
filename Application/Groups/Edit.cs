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
            public GroupDTO EditedGroup;
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

                var ExistGroup = await _context.Groups
                    .Include(g => g.Company)
                    .Include(g => g.Members)
                    .FirstOrDefaultAsync(g => g.Id == group.Id);

                var ExistCompany = await _context.Companies
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == ExistGroup.Company.Id);

                var ExistMembers = new List<User>();

                User ExistLeader = null;

                foreach(var CompanyMember in ExistCompany.Members)
                {
                    // Check: Is GroupMember in CompanyMembers
                    foreach(var GroupMember in group.Members)
                    {
                        if(CompanyMember.Id == GroupMember.Id)
                            ExistMembers.Add(await _context.Users.FindAsync(GroupMember.Id));
                    }
                    // Check: Is Leader in CompanyMembers
                    if(CompanyMember.Id == group.Leader.Id)
                        ExistLeader = await _context.Users.FindAsync(group.Leader.Id);
                }

                if(ExistLeader != null)
                {
                    ExistGroup.Leader = ExistLeader;
                } else {
                    return Unit.Value;
                }
                ExistGroup.Name = group.Name;
                ExistGroup.Description = group.Description;
                ExistGroup.Members = ExistMembers;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}