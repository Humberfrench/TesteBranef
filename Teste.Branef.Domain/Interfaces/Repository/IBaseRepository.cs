using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Branef.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntidade> : IDisposable where TEntidade : class
    {
        Task<bool> Adicionar(TEntidade obj);

        Task<bool> Atualizar(TEntidade obj);

        Task<bool> Remover(TEntidade obj);

        Task<TEntidade> ObterPorId(int id);

        Task<IEnumerable<TEntidade>> ObterTodos();

        Task<IEnumerable<TEntidade>> Pesquisar(Expression<Func<TEntidade, bool>> predicate);
    }
}
