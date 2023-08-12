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
        public class Query : IRequest<ActivityDTO>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, ActivityDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ActivityDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities
                    .FindAsync(request.UserId);
                
                var resultDTO = _mapper.Map<ActivityDTO>(result);

                return resultDTO;
            }
        }
    }
}