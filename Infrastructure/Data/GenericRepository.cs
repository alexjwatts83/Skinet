using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context
                .Set<T>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context
                .Set<T>()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<T> GetByIdWithSpecificationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync()
                                                          .ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> ListAllWithSpecificationAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync()
                                                          .ConfigureAwait(false);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
