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
        public class Query : IRequest<CompanyDTO>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, CompanyDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CompanyDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Companies
                    .FindAsync(request.UserId);
                
                var resultDTO = _mapper.Map<CompanyDTO>(result);

                return resultDTO;
            }
        }
    }
}