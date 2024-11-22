using Teste.Branef.Domain.Entity;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;

namespace Teste.Branef.Services
{
    public class ClienteService(IBaseRepository<Cliente> baseRepository,
                                IClienteRepository clienteRepository) : BaseService<Cliente>(baseRepository), IClienteService
    {
        private readonly IClienteRepository clienteRepository = clienteRepository;
    }
}
