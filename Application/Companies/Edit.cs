using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class Edit
    {
        public class Command : IRequest
        {
            public CompanyDto EditedCompany;
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
                Company updatedCompany = _mapper.Map<Company>(request.EditedCompany);

                var existCompany = await _context.Companies
               .Include(c => c.Members)
               .FirstOrDefaultAsync(c => c.Id == updatedCompany.Id, cancellationToken);

                if (existCompany == null)
                {
                    return Unit.Value;
                }

                var existLeader = await _context.Users.FindAsync(updatedCompany.Leader.Id);
                var existMembers = new List<User>() { };

                foreach (var member in updatedCompany.Members)
                {
                    existMembers.Add(await _context.Users.FindAsync(member.Id));
                }

                existCompany.Name = updatedCompany.Name;
                existCompany.Description = updatedCompany.Description;
                existCompany.Leader = existLeader;
                existCompany.Members = existMembers;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}