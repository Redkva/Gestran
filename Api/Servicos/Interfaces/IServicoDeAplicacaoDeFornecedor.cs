using Domain.Entidades;

namespace Api.Servicos.Interfaces
{
    public interface IServicoDeAplicacaoDeFornecedor
    {
        string Cadastrar(Fornecedor fornecedor);

        string Editar(Fornecedor fornecedor);

        List<Fornecedor> ListarFornecedores();

        Fornecedor ObterFornecedorUnico(int Id);

        string Deletar(int Id);
    }
}
