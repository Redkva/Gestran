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
        protected RepositorioBase _rep;

        public FornecedorController(RepositorioBase rep)
        {
            _rep = rep;

        }

        [Route("Cadastrar"), HttpPost]
        public IActionResult Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                var retorno = new ServicoDeDominioDeFornecedor().Cadastrar(fornecedor);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest("Falha ao tentar cadastrar");
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
                return BadRequest("Falha ao tentar cadastrar");
            }
        }


        [Route("ListarFornecedores"), HttpGet]
        public IActionResult ListarFornecedores()
        {
            try
            {
                var xptro = _rep.Fornecedores.ToList();

                var retorno = new ServicoDeDominioDeFornecedor().ListarFornecedores();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest("Falha ao tentar cadastrar");
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
                return BadRequest("Falha ao tentar cadastrar");
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
                return BadRequest("Falha ao tentar cadastrar");
            }
        }

    }
}
