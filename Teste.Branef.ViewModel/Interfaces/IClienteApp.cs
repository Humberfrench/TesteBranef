using Dietcode.Api.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Branef.ViewModel.Interfaces
{
    public interface IClienteApp
    {
        Task<MethodResult> Excluir(int id);
        Task<MethodResult> Gravar(ClienteViewModel cliente);
        Task<MethodResult> Obter();
        Task<MethodResult> Obter(int id);
    }
}
