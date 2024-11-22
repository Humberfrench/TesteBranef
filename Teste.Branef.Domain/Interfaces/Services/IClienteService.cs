using Dietcode.Core.DomainValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Branef.Domain.Entity;

namespace Teste.Branef.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ValidationResult<bool>> Excluir(int id);
        Task<ValidationResult> Gravar(Cliente cliente);
        Task<ValidationResult<List<Cliente>>> Obter();
        Task<ValidationResult<Cliente>> Obter(int id);
    }
}
