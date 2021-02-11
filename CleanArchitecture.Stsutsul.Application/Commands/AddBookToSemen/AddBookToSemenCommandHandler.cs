using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Stsutsul.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Stsutsul.Application.Commands.AddBookToSemen
{
    public class AddBookToSemenCommandHandler : IRequestHandler<AddBookToSemenCommand>
    {
        private readonly ISemenDbContext _dbContext;

        public AddBookToSemenCommandHandler(ISemenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddBookToSemenCommand request, CancellationToken cancellationToken)
        {
            var semen = await _dbContext.Semens
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Name == request.SemenName, cancellationToken);

            if (semen is null) throw new ApplicationException($"Semen with name {request.SemenName} not found");

            if (semen.Books.Any(x => x.Name == request.BookName)) return Unit.Value;

            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Name.Equals(request.BookName), cancellationToken) ?? new Book
            {
                Name = request.BookName,
                Semen = semen
            };

            semen.Books.Add(book);
            _dbContext.Semens.Update(semen);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}