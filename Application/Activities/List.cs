
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<List<ActivityDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities
                    .ProjectTo<ActivityDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();


            return result;
            } 
        }
    }
}