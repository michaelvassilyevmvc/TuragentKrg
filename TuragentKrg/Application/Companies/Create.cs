using System.Threading.Tasks;
using FluentValidation;
using Application.Core;
using MediatR;
using Domain;
using System.Threading;
using Persistence;

namespace Application.Companies
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Company Company { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Company).SetValidator(new CompanyValidator());
                }
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Companies.Add(request.Company);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Ошибка при создании организации");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}