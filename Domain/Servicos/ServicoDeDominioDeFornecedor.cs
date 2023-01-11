using Domain.Entidades;
using Domain.Interfaces;
using Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicoDeDominioDeFornecedor : IServicoDeDominioDeFornecedor
    {
        IRepositorioFornecedor repositorioFornecedor;

        public ServicoDeDominioDeFornecedor(IRepositorioFornecedor _repositorioFornecedor)
        {
            repositorioFornecedor = _repositorioFornecedor;
        }

        public string Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                repositorioFornecedor.Create(fornecedor);
                return "Cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] Cadastrar() > {ex.Message} ");
            }
        }

        public string Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public string Editar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public List<Fornecedor> ListarFornecedores()
        {
            try
            {
                return repositorioFornecedor.ListEntitys().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] ListarFornecedores() > {ex.Message} ");
            }
        }

        public Fornecedor ObterFornecedorUnico(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
