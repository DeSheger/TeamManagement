using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class List
    {
        public class Query : IRequest<List<CompanyDTO>>
        {

        }

        public class Handler : IRequestHandler<Query, List<CompanyDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<CompanyDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var CompaniesDTO = await _context.Companies
                    .ProjectTo<CompanyDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                
                return CompaniesDTO;
            }
        }
    }
}
