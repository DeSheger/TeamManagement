using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Create
    {
        public class Command : IRequest
        {
            public CompanyDto CompanyDto;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Company company = _mapper.Map<Company>(request.CompanyDto);
                
                User leader = await _context.Users.FindAsync(company.Leader.Id);

                var existMembers = new List<User>() { };

                foreach (var member in company.Members)
                {
                    existMembers.Add(_context.Users.Find(member.Id));
                }

                var result = new Company()
                {
                    Name = company.Name,
                    Description = company.Description,
                    Leader = leader,
                    Members = existMembers
                };
                
                _context.Companies.Add(result);
                await _context.SaveChangesAsync();
                
                return Unit.Value;
            }
        }
    }
}