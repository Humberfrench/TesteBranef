using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;
using System.Net;
using Teste.Branef.Domain.Entity;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.Domain.Interfaces.Services;
using Teste.Branef.ViewModel;
using Teste.Branef.ViewModel.Interfaces;

namespace Teste.Branef.App
{
    public class ClienteApp(IUnitOfWork unitOfWork, IClienteService clienteService) : BaseApp(unitOfWork), IClienteApp
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IClienteService clienteService = clienteService;

        public async Task<MethodResult> Excluir(int id)
        {
            var clienteExcluir = await clienteService.Excluir(id);

            if (clienteExcluir.Valid)
            {
                await Commit();
                if (baseValidationResult.Invalid)
                {
                    var erros = string.Join(",", baseValidationResult.Erros);
                    return BadRequest(erros);
                }
            }
            else
            {
                if (clienteExcluir.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Cliente não encontrado");
                }
                var erros = string.Join(",", clienteExcluir.Erros);
                return BadRequest(erros);
            }

            return Ok();
        }

        public async Task<MethodResult> Gravar(ClienteViewModel cliente)
        {
            var dados = cliente.ConvertObjects<Cliente>();

            var clienteGravar = await clienteService.Gravar(dados);

            if (clienteGravar.Valid)
            {
                await Commit();
                if (baseValidationResult.Invalid)
                {
                    var erros = string.Join(",", baseValidationResult.Erros);
                    return BadRequest(erros);
                }
            }
            else
            {
                if(clienteGravar.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Cliente não encontrado");
                }
                var erros = string.Join(",", clienteGravar.Erros);
                return BadRequest(erros);
            }

            return Ok();

        }

        public async Task<MethodResult> Obter()
        {
            var retorno = new List<ClienteViewModel>();
            var clientes = await clienteService.Obter();

            if (clientes.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound("Cliente não encontrado");
            }

            retorno = clientes.ConvertObjects<List<ClienteViewModel>>();

            return Ok(retorno);
        }

        public async Task<MethodResult> Obter(int id)
        {
            var retorno = new ClienteViewModel();
            var clientes = await clienteService.Obter(id);

            if (clientes.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound("Cliente não encontrado");
            }
            retorno = clientes.ConvertObjects<ClienteViewModel>();

            return Ok(retorno);
        }
    }
}
