using Auth.JWT.Application.Interfaces;
using Auth.JWT.Domain.Interfaces.Services;
using Auth.JWT.Domain.Models.Base;
using Auth.JWT.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Application.Services
{
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly IBaseService<TEntity> _service;

        public BaseAppService(IBaseService<TEntity> service)
        {
            _service = service;
        }

        public async Task Adicionar(TEntity entity)
        {
            await _service.Adicionar(entity);
        }

        public async Task Atualizar(TEntity entity)
        {
            await _service.Atualizar(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _service.Buscar(predicate);
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _service.ObterPorId(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _service.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _service.Remover(id);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
