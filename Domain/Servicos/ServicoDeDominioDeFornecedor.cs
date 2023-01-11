using Domain.Entidades;
using Domain.Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Domain.Servicos
{
    public class ServicoDeDominioDeFornecedor : IServicoDeDominioDeFornecedor
    {
    

        public string Cadastrar(Fornecedor fornecedor)
        {

         
            throw new NotImplementedException();
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
                var retorno = new List<Fornecedor>();

                return retorno;
            }
            catch (Exception ex)
            {

                throw new Exception($" ListarFornecedores() > {ex.Message} ");
            }
        }

        public Fornecedor ObterFornecedorUnico(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
