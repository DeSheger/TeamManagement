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
            public readonly int GroupId;
            public Query(int Id)
            {
                GroupId = Id;
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
                    .Include(x => x.Leader)
                    .Include(x => x.Company)
                    .Include(x => x.Members)
                    .FirstOrDefaultAsync(x => x.Id == request.GroupId);

                var resultDTO = _mapper.Map<GroupDTO>(result);

                return resultDTO;
            }
        }
    }
}