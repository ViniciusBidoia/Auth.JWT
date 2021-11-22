using Auth.JWT.Domain.Interfaces.Repositories;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : BaseEntity, new
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(TEntity entity)
        {
            await _repository.Adicionar(entity);
        }

        public async Task Atualizar(TEntity entity)
        {
            await _repository.Atualizar(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Buscar(predicate);
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _repository.Remover(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
