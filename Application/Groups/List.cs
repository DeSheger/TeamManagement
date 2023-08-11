using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class List
    {
        public class Query : IRequest<List<GroupDTO>>
        {

        }

        public class Handler : IRequestHandler<Query, List<GroupDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<GroupDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Groups
                    .ProjectTo<GroupDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                    
                return result;
            }
        }
    }
}