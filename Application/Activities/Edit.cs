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
            public ActivityDto Activity;
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

                Activity existActivity = await _context.Activities
                    .Include(a => a.Author)
                    .Include(a => a.Group)
                    .Include(a => a.Company)
                    .Include(a => a.Members)
                    .FirstOrDefaultAsync(x => x.Id == activity.Id, cancellationToken);

                Company existCompany = await _context.Companies
                    .Include(c => c.Leader)
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == existActivity.Company.Id, cancellationToken);

                List<Group> companyGroups = await _context.Groups
                    .Include(g => g.Company)
                    .Include(g => g.Leader)
                    .Where(g => g.Company.Id == existCompany.Id)
                    .ToListAsync(cancellationToken);

                Group existGroup = null;

                List<User> existMembers = new();

                User existAuthor = null;

                // CHECK: IS GROUP IN COMPANY
                foreach (var companyGroup in companyGroups)
                {
                    if (companyGroup.Id == activity.Group.Id)
                        existGroup = await _context.Groups
                        .Include(g => g.Members)
                        .Include(g => g.Leader)
                        .FirstOrDefaultAsync(g => g.Id == activity.Group.Id, cancellationToken);
                }

                // CHECK ARE MEMBERS IN GROUP
                foreach (var groupMember in existGroup.Members)
                {
                    foreach (var activityMember in activity.Members)
                    {
                        if (groupMember.Id == activityMember.Id)
                            existMembers.Add(await _context.Users.FindAsync(activityMember.Id));
                    }
                    if (groupMember.Id == activity.Author.Id) // CHECK IS AUTHOR IN GROUP
                        existAuthor = await _context.Users.FindAsync(groupMember.Id);
                }


                if(existAuthor != null)
                {
                    existActivity.Author = existAuthor;
                } else {
                    return Unit.Value;
                }
                
                existActivity.Title = activity.Title;
                existActivity.DateStart = activity.DateStart;
                existActivity.DateEnd = activity.DateEnd;
                existActivity.Description = activity.Description;
                existActivity.Members = existMembers;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}