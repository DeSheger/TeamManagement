using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class CompanyGroups
    {
        public class Query : IRequest<List<GroupDTO>>
        {
            public readonly int CompanyId;
            public Query(int id)
            {
                CompanyId = id;
            }
        }

        public class Handler : IRequestHandler<Query, List<GroupDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<GroupDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _context.Groups
                    .Include(g => g.Company)
                    .Where(g => g.Company.Id == request.CompanyId)
                    .ProjectTo<GroupDTO>(_mapper.ConfigurationProvider)
                    .ToList();
                
                return result;
            }
        }
    }
}