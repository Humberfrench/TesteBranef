﻿using Dietcode.Api.Core.Results;
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
                    return BadRequest(baseValidationResult.Erros[0].Message);
                }
            }
            else
            {
                if (clienteExcluir.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Cliente não encontrado");
                }
                return BadRequest(clienteExcluir.Erros[0].Message);
            }

            return Ok(true);
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
                    return BadRequest(baseValidationResult.Erros[0].Message);
                }
            }
            else
            {
                if(clienteGravar.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Cliente não encontrado");
                }
                return BadRequest(clienteGravar.Erros[0].Message);
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

            retorno = clientes.Retorno.ConvertObjects<List<ClienteViewModel>>();

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
            retorno = clientes.Retorno.ConvertObjects<ClienteViewModel>();

            return Ok(retorno);
        }
    }
}
