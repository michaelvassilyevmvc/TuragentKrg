using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.FindAsync(request.Id);
                _context.Remove(company);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Ошибка при удалении организации");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}