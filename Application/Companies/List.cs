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
        public class Query : IRequest<List<CompanyDto>>
        {

        }

        public class Handler : IRequestHandler<Query, List<CompanyDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<CompanyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var companiesDto = await _context.Companies
                    .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                
                return companiesDto;
            }
        }
    }
}
