using System.Linq.Expressions;

namespace Teste.Branef.Domain.Interfaces.Services
{
    public interface IBaseService<TEntidade> where TEntidade : class
    {
        Task<bool> Adicionar(TEntidade obj);

        Task<bool> Atualizar(TEntidade obj);

        Task<bool> Remover(TEntidade id);

        Task<TEntidade> ObterPorId(int id);

        Task<IEnumerable<TEntidade>> ObterTodos();

        Task<IEnumerable<TEntidade>> Pesquisar(Expression<Func<TEntidade, bool>> predicate);

        void Dispose();
    }
}
