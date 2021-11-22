using Auth.JWT.Data.Context;
using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Data.Respositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {            
            await _entity.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _entity.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            _entity.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
