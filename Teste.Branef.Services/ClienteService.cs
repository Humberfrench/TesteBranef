using Dietcode.Core.DomainValidator;
using System.Net;
using Teste.Branef.Domain.Entity;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;

namespace Teste.Branef.Services
{
    public class ClienteService(IBaseRepository<Cliente> baseRepository,
                                    IClienteRepository clienteRepository) : BaseService<Cliente>(baseRepository), IClienteService
    {
        private readonly IClienteRepository clienteRepository = clienteRepository;

        public async Task<ValidationResult> Gravar(Cliente cliente)
        {
            var retono = new ValidationResult();
            cliente.Validate();
            if (!cliente.Valid)
            {
                retono.GetErros(cliente.Erros);
                return retono;
            }

            if (cliente.IsNew())
            {
                await Adicionar(cliente);
            }
            else
            {
                var clienteExistente = await ObterPorId(cliente.ClienteId);
                if(clienteExistente == null)
                {
                    retono.Add("Cliente não encontrado");
                    retono.StatusCode = HttpStatusCode.NotFound;
                    return retono;
                }
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Porte = cliente.Porte;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Telefone = cliente.Telefone;
                await Atualizar(cliente);
            }
            return retono;
        }

        public async Task<ValidationResult<Cliente>> Obter(int id)
        {
            var retorno = new ValidationResult<Cliente>();

            var cliente = await ObterPorId(id);
            retorno.Retorno = cliente;

            if((cliente == null) || (cliente.ClienteId ==0))
            {
                retorno.StatusCode = HttpStatusCode.NotFound;
            }

            return retorno;
        }

        public async Task<ValidationResult<List<Cliente>>> Obter()
        {
            var retorno = new ValidationResult<List<Cliente>>();

            var clientes = await ObterTodos();
            retorno.Retorno = clientes.ToList();

            if ((clientes == null) || (clientes.Count() == 0))
            {
                retorno.StatusCode = HttpStatusCode.NotFound;
            }

            return retorno;
        }

        public async Task<ValidationResult<bool>> Excluir(int id)
        {
            var retorno = new ValidationResult<bool>();

            var cliente = await ObterPorId(id);
            if ((cliente == null) || (cliente.ClienteId == 0))
            {
                retorno.Add("Cliente não encontrado");
                retorno.Retorno = false;
                retorno.StatusCode = HttpStatusCode.NotFound;
                return retorno;
            }

            await Remover(cliente);
            retorno.Retorno = true;

            return retorno;

        }

    }
}
