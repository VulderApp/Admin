using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}