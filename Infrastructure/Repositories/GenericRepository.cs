using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = true)
        {
            var query = _context.Set<T>().AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var tracked = await _context.Set<T>()
                .FirstAsync(e => e.Id == entity.Id);

            _context.Entry(tracked).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
