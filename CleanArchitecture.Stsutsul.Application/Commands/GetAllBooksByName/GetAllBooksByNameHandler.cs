using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Stsutsul.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Stsutsul.Application.Commands.GetAllBooksByName
{
    public class GetAllBooksByNameHandler : IRequestHandler<GetAllBooksByNameQuery, ICollection<BookModel>>
    {
        private readonly ISemenDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllBooksByNameHandler> _logger;

        public GetAllBooksByNameHandler(ISemenDbContext dbContext, ILogger<GetAllBooksByNameHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ICollection<BookModel>> Handle(GetAllBooksByNameQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Semens
                .Include(x => x.Books)
                .Where(x => x.Name.Equals(request.SemenName))
                .Select(x => x.Books)
                .ToArrayAsync(cancellationToken);

            return _mapper.Map<List<BookModel>>(books);
        }
    }
}