using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServicoDeDominioDeFornecedor
    {
        string Cadastrar(Fornecedor fornecedor);

        string Editar(Fornecedor fornecedor);

        List<Fornecedor> ListarFornecedores();

        Fornecedor ObterFornecedorUnico(int Id);

        string Deletar(int Id);


    }
}
