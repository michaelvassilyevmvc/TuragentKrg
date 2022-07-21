using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Application.Core;
using Persistence;
using System.Threading;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Companies
{
    public class List
    {
        public class Query : IRequest<Result<List<Company>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Company>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Company>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Company>>.Success(await _context.Companies.ToListAsync(cancellationToken));
            }
        }
    }
}