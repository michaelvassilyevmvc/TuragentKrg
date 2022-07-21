using System.Threading.Tasks;
using Domain;
using Application.Core;
using MediatR;
using Persistence;
using System.Threading;

namespace Application.Companies
{
    public class Details
    {
        public class Query : IRequest<Result<Company>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Company>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
                var company = await _context.Companies.FindAsync(request.Id);
                return Result<Company>.Success(company);
            }
        }
    }
}