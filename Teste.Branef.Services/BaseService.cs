using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;

namespace Teste.Branef.Services
{
    public class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository = repository;

        public async virtual Task<bool> Adicionar(TEntity obj)
        {
            return await repository.Adicionar(obj);
        }

        public async virtual Task<bool> Atualizar(TEntity obj)
        {
            return await repository.Atualizar(obj);
        }

        public async virtual Task<bool> Remover(TEntity obj)
        {
            return await repository.Remover(obj);
        }

        public async virtual Task<TEntity> ObterPorId(int id)
        {
            return await repository.ObterPorId(id);
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await repository.ObterTodos();
        }

        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async virtual Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.Pesquisar(predicate);
        }
    }
}
