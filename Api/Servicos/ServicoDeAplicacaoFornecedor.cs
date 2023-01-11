using Api.Servicos.Interfaces;
using Domain.Entidades;
using Domain.Interfaces;

namespace Api.Servicos
{
    public class ServicoDeAplicacaoFornecedor : IServicoDeAplicacaoDeFornecedor
    {
        private readonly IServicoDeDominioDeFornecedor servicoDeDominioDeFornecedor;
        public ServicoDeAplicacaoFornecedor(IServicoDeDominioDeFornecedor _servicoDeDominioDeFornecedor)
        {
            servicoDeDominioDeFornecedor = _servicoDeDominioDeFornecedor;
        }

        public string Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                return servicoDeDominioDeFornecedor.Cadastrar(fornecedor); 
            }
            catch (Exception ex)
            {
                throw new Exception($" [APPLICATION LAYER] Cadastrar() > {ex.Message} ");
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
                return servicoDeDominioDeFornecedor.ListarFornecedores();
            }
            catch (Exception ex)
            {
                throw new Exception($" [APPLICATION LAYER] ListarFornecedores() > {ex.Message} ");
            }
        }

        public Fornecedor ObterFornecedorUnico(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
