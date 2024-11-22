using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teste.Branef.Domain.Entity;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Repository.Base;
using Teste.Branef.Repository.Interfaces;

namespace Teste.Branef.Repository
{
    public class ClienteRepository(IContextManager contextManager) : BaseRepository<Cliente>(contextManager), IClienteRepository
    {

    }
}
