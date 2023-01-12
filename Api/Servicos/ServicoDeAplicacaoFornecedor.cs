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
            try
            {
                return servicoDeDominioDeFornecedor.Deletar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($" [APPLICATION LAYER] Deletar() > {ex.Message} ");
            }
        }

        public string Editar(Fornecedor fornecedor)
        {
            try
            {
                return servicoDeDominioDeFornecedor.Editar(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception($" [APPLICATION LAYER] Editar() > {ex.Message} ");
            }
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
            try
            {
                return servicoDeDominioDeFornecedor.ObterFornecedorUnico(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($" [APPLICATION LAYER] ObterFornecedorUnico() > {ex.Message} ");
            }
        }
    }
}
