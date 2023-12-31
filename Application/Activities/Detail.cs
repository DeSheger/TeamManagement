using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Detail
    {
        public class Query : IRequest<ActivityDto>
        {
            public readonly int ActivityId;
            public Query(int id)
            {
                ActivityId = id;
            }
        }

        public class Handler : IRequestHandler<Query, ActivityDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ActivityDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities
                    .Include(x => x.Author)
                    .Include(x => x.Company)
                    .Include(x => x.Group)
                    .Include(x => x.Members)
                    .FirstOrDefaultAsync(x => x.Id == request.ActivityId, cancellationToken);
                
                var resultDto = _mapper.Map<ActivityDto>(result);

                return resultDto;
            }
        }
    }
}