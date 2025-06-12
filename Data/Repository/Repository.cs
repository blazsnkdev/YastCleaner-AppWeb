using Microsoft.EntityFrameworkCore;
using YAST_CLENAER_WEB.Data.Interfaces;

namespace YAST_CLENAER_WEB.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
