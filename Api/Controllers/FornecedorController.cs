using Api.Servicos;
using Api.Servicos.Interfaces;
using Domain.Entidades;
using Domain.Servicos;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DAL;
using System.Net;

namespace Api.Controllers
{
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {

        private readonly IServicoDeAplicacaoDeFornecedor servicoDeAplicacaoDeFornecedor;

        public FornecedorController(IServicoDeAplicacaoDeFornecedor _servicoDeAplicacaoDeFornecedor)
        {
            servicoDeAplicacaoDeFornecedor = _servicoDeAplicacaoDeFornecedor;
        }

        [Route("Cadastrar"), HttpPost]
        public IActionResult Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                var retorno = servicoDeAplicacaoDeFornecedor.Cadastrar(fornecedor);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [Route("Editar"), HttpPost]
        public IActionResult Editar(Fornecedor fornecedor)
        {
            try
            {
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [Route("ListarFornecedores"), HttpGet]
        public IActionResult ListarFornecedores()
        {
            try
            {
                var retorno = servicoDeAplicacaoDeFornecedor.ListarFornecedores();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("ObterFornecedorUnico"), HttpGet]
        public IActionResult ObterFornecedorUnico(int Id)
        {
            try
            {
                return Ok(new List<Fornecedor>());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [Route("Deletar"), HttpGet]
        public IActionResult Deletar(int Id)
        {
            try
            {
                return Ok("Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
