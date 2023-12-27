using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class Detail
    {
        public class Query : IRequest<CompanyDto>
        {
            public readonly int UserId;
            public Query(int id)
            {
                UserId = id;
            }
        }

        public class Handler : IRequestHandler<Query, CompanyDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CompanyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Companies
                    .Include(x => x.Leader)
                    .Include(x => x.Members)
                    .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
                
                var resultDto = _mapper.Map<Company,CompanyDto>(result);

                return resultDto;
            }
        }
    }
}