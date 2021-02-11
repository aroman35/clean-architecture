using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Stsutsul.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Stsutsul.Application
{
    public interface ISemenDbContext : IDisposable, IAsyncDisposable
    {
        DbSet<Book> Books { get; }
        DbSet<Semen> Semens { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}