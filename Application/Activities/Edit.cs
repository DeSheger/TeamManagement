using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ActivityDTO Activity;
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

                Activity activity = _mapper.Map<Activity>(request.Activity);

                Activity ExistActivity = await _context.Activities
                    .Include(a => a.Author)
                    .Include(a => a.Group)
                    .Include(a => a.Company)
                    .Include(a => a.Members)
                    .FirstOrDefaultAsync(x => x.Id == activity.Id);

                Company ExistCompany = await _context.Companies
                    .Include(c => c.Leader)
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == ExistActivity.Company.Id);

                List<Group> CompanyGroups = await _context.Groups
                    .Include(g => g.Company)
                    .Include(g => g.Leader)
                    .Where(g => g.Company.Id == ExistCompany.Id)
                    .ToListAsync();

                Group ExistGroup = null;

                List<User> ExistMembers = new();

                User ExistAuthor = null;

                // CHECK: IS GROUP IN COMPANY
                foreach (var CompanyGroup in CompanyGroups)
                {
                    if (CompanyGroup.Id == activity.Group.Id)
                        ExistGroup = await _context.Groups
                        .Include(g => g.Members)
                        .Include(g => g.Leader)
                        .FirstOrDefaultAsync(g => g.Id == activity.Group.Id);
                }

                // CHECK ARE MEMBERS IN GROUP
                foreach (var GroupMember in ExistGroup.Members)
                {
                    foreach (var ActivityMember in activity.Members)
                    {
                        if (GroupMember.Id == ActivityMember.Id)
                            ExistMembers.Add(await _context.Users.FindAsync(ActivityMember.Id));
                    }
                    if (GroupMember.Id == activity.Author.Id) // CHECK IS AUTHOR IN GROUP
                        ExistAuthor = await _context.Users.FindAsync(GroupMember.Id);
                }


                if(ExistAuthor != null)
                {
                    ExistActivity.Author = ExistAuthor;
                } else {
                    return Unit.Value;
                }
                
                ExistActivity.Title = activity.Title;
                ExistActivity.DateStart = activity.DateStart;
                ExistActivity.DateEnd = activity.DateEnd;
                ExistActivity.Description = activity.Description;
                ExistActivity.Members = ExistMembers;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}