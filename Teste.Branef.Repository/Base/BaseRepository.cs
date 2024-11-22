using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Repository.Context;
using Teste.Branef.Repository.Interfaces;
namespace Teste.Branef.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected DbSet<TEntity> DbSet;
        protected readonly TesteBranefContext Context;
        protected readonly string connectionString;
        private readonly IContextManager contextManager;

        public BaseRepository(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            Context = contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
            connectionString = contextManager.GetConnectionString;
        }

        //for dapper
        public IDbConnection Connection => new SqlConnection(contextManager.GetConnectionString);

        public async virtual Task<bool> Adicionar(TEntity obj)
        {
            var entry = Context.Entry(obj);
            await DbSet.AddAsync(obj);
            entry.State = EntityState.Added;

            return true;
        }

        public async virtual Task<bool> Atualizar(TEntity obj)
        {
            var entry = Context.Entry(obj);
            await Task.Run(() => DbSet.Attach(obj));
            entry.State = EntityState.Modified;
            return true;
        }

        public async virtual Task<bool> Remover(TEntity obj)
        {
            var entry = Context.Entry(obj);
            await Task.Run(() => DbSet.Remove(obj));
            //DbSet.Remove(obj);
            entry.State = EntityState.Deleted;

            return true;
        }

        public async virtual Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id) ?? new TEntity();
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await Task.Run(() => DbSet.ToList());
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodosPaginado(int pagina, int registros)
        {
            return await Task.Run(() => DbSet.Take(pagina).Skip(registros));
        }

        public async virtual Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => DbSet.Where(predicate));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}