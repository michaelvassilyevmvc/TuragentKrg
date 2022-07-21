using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Companies
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Company Company { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {

            public CommandValidator()
            {
                RuleFor(x => x.Company).SetValidator(new CompanyValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.FindAsync(request.Company.Id);
                _mapper.Map(request.Company, company);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Ошибка при обновлении организации");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}