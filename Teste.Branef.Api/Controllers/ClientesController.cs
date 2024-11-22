using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Teste.Branef.Api.Model;
using Teste.Branef.ViewModel;
using Teste.Branef.ViewModel.Interfaces;

//https://localhost:32769/swagger/index.html

namespace Teste.Branef.Api.Controllers
{
    [Route("api/[controller]")]
    [SwaggerTag("Clientes - Cadastro e Manutenção")]
    [ApiController]
    public class ClientesController(IClienteApp clienteApp) : ControllerBase
    {
        private readonly IClienteApp clienteApp = clienteApp;

        [ProducesResponseType(typeof(RetunValue), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Excluir Cliente")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(typeof(RetunValue), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Adicionar um  Cliente")]
        [HttpPost("")]
        public async Task<IActionResult> Gravar(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(typeof(List<ClienteViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter Todos os Clientes")]
        [HttpGet("")]
        public async Task<IActionResult> Obter()
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Obter Cliente por Id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            throw new NotImplementedException();
        }


    }
}
