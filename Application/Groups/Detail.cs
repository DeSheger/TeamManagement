using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class Detail
    {
        public class Query : IRequest<GroupDTO>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, GroupDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GroupDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Groups
                    .FindAsync(request.UserId);

                var resultDTO = _mapper.Map<GroupDTO>(result);

                return resultDTO;
            }
        }
    }
}