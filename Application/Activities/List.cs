
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.DTOs;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<ActivityDTO>>
        {

        }

        public class Handler : IRequestHandler<Query, List<ActivityDTO>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<List<ActivityDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities
                    .Include(x => x.Author)
                    .Include(x => x.Company)
                    .Include(x => x.Group)
                    .Include(x => x.Members).ToListAsync();

                var Activities = new List<ActivityDTO>();
                /*
                foreach (var activity in result)
                {
                    var activityDTO = new ActivityDTO
                    {
                        Id = activity.Id,
                        Title = activity.Title,
                        DateStart = activity.DateStart,
                        DateEnd = activity.DateEnd,
                        Description = activity.Description,
                        AuthorId = new UserDTO{Name = activity.Author.Name, Surrname = activity.Author.Surrname},
                        CompanyId = activity.Company,
                        GroupId = activity.Group,
                        MembersId = new List<UserDTO>()
                        
                    };
                    foreach(var member in activity.Members)
                    {
                        var memberDTO = new UserDTO
                        {
                            Name = member.Name,
                            Surrname = member.Surrname
                        };

                        activityDTO.MembersId.Add(memberDTO);
                    }

                    Activities.Add(activityDTO);
                } */

            return Activities;
            } 
        }
    }
}