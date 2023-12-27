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
        public class Query : IRequest<List<GroupDto>>
        {
            public readonly int CompanyId;
            public Query(int id)
            {
                CompanyId = id;
            }
        }

        public class Handler : IRequestHandler<Query, List<GroupDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<GroupDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _context.Groups
                    .Include(g => g.Company)
                    .Where(g => g.Company.Id == request.CompanyId)
                    .ProjectTo<GroupDto>(_mapper.ConfigurationProvider)
                    .ToList();
                
                return result;
            }
        }
    }
}