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
        public class Query : IRequest<List<GroupDto>>
        {

        }

        public class Handler : IRequestHandler<Query, List<GroupDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<GroupDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Groups
                    .ProjectTo<GroupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                    
                return result;
            }
        }
    }
}