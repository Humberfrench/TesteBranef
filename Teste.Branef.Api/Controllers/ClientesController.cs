using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Dietcode.Api.Core;
using Teste.Branef.Api.Model;
using Teste.Branef.ViewModel;
using Teste.Branef.ViewModel.Interfaces;
using Dietcode.Api.Core.Results;
using Dietcode.Core.Lib;

//https://localhost:32769/swagger/index.html

namespace Teste.Branef.Api.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Clientes - Cadastro e Manutenção")]
    [ApiController]
    public class ClientesController(IClienteApp clienteApp) : ApiControllerBase
    {
        private readonly IClienteApp clienteApp = clienteApp;

        [ProducesResponseType(typeof(RetunValue), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Excluir Cliente")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var retorno = await clienteApp.Excluir(id);
            if (retorno.Status != ResultStatusCode.OK)
            {
                return TrataStatus(retorno);
            }
            var dadoRetorno = new RetunValue { Sucesso = true, Mensagem = "Registro excluído com sucesso" };
            return Completed<RetunValue>(retorno);

        }

        [ProducesResponseType(typeof(RetunValue), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Adicionar um  Cliente")]
        [HttpPost("")]
        public async Task<IActionResult> Gravar(ClienteViewModel cliente)
        {
            var retorno = await clienteApp.Gravar(cliente);
            if (retorno.Status != ResultStatusCode.OK)
            {
                return TrataStatus(retorno);
            }

            var dadoRetorno = new RetunValue { Sucesso = true, Mensagem = "Registro gravado com sucesso" };
            return Completed<RetunValue>(retorno);

        }

        [ProducesResponseType(typeof(List<ClienteViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter Todos os Clientes")]
        [HttpGet("")]
        public async Task<IActionResult> Obter()
        {
            var retorno = await clienteApp.Obter();
            if (retorno.Status != ResultStatusCode.OK)
            {
                return TrataStatus(retorno);
            }

            return Completed<List<ClienteViewModel>>(retorno);

        }

        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter Cliente por Id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var retorno = await clienteApp.Obter(id);
            if (retorno.Status != ResultStatusCode.OK)
            {
                return TrataStatus(retorno);
            }

            return Completed<ClienteViewModel>(retorno);

        }

        IActionResult TrataStatus(MethodResult retorno)
        {
            var retornoProblem = new ProblemDetails
            {
                Status = retorno.Status.Int(),
            };
            if (retorno.Status == ResultStatusCode.NotFound)
            {
                retornoProblem.Title = "404 - Não encontrado";
                retornoProblem.Detail = "Registro não encontrado";
                return NotFound(retornoProblem);
            }
            retornoProblem.Title = "400 - Erro";
            retornoProblem.Detail = "Registro não encontrado";
            return NotFound(retorno);
        }
    }
}
