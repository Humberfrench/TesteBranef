using Dietcode.Api.Core.Results;
using Dietcode.Core.DomainValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Branef.Domain.Interfaces.Repository;
using Teste.Branef.ViewModel.Interfaces;

namespace Teste.Branef.App
{
    public class BaseApp(IUnitOfWork uow) : AppServiceBase, IBaseApp
    {
        private readonly IUnitOfWork uow = uow;
        protected ValidationResult baseValidationResult = new ValidationResult();

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public async Task Commit()
        {
            var retorno = await Task.Run(() => uow.SaveChanges());

            if (retorno.Invalid)
            {
                retorno.Erros.ToList().ForEach(e => baseValidationResult.Add(e.Message));
            }
        }

    }
}
