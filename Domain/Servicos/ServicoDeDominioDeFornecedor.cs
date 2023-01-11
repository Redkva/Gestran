using Domain.Entidades;
using Domain.Interfaces;
using Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicoDeDominioDeFornecedor : IServicoDeDominioDeFornecedor
    {
        IRepositorioFornecedor repositorioFornecedor;
        IRepositorioEndereco repositorioEndereco;

        public ServicoDeDominioDeFornecedor(IRepositorioFornecedor _repositorioFornecedor, IRepositorioEndereco _repositorioEndereco)
        {
            repositorioFornecedor = _repositorioFornecedor;
            repositorioEndereco = _repositorioEndereco;
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
            try
            {
                var _f = repositorioFornecedor.GetFornecedor(fornecedor.IdFornecedor);

                if (_f == null)
                {
                    Cadastrar(fornecedor);
                    return "Cadastraodo com sucesso";
                }


                repositorioFornecedor.Edit(fornecedor);
                return "Editado com sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] Editar() > {ex.Message} ");
            }
        }

        public List<Fornecedor> ListarFornecedores()
        {
            try
            {
                //Busca todos os Fornecedores
                var retorno = repositorioFornecedor.ListEntitys().ToList();

                if (retorno == null || retorno.Count <= 0)
                    return new List<Fornecedor>();

                //Busca todos os enderecos dos fornecedores encontrados
                var enderecos = repositorioEndereco.GetEnderecos(retorno.Select(x => x.IdFornecedor).ToList());

                //Adiicona os Enderecos na lista dos fornecedor
                enderecos.GroupBy(e => e.IdFornecedor).ToList().ForEach(e =>
                {
                    if (retorno.Any(f => f.IdFornecedor == e.Key))
                        retorno.Where(f => f.IdFornecedor == e.Key).First().Enderecos = e.ToList();
                });

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] ListarFornecedores() > {ex.Message} ");
            }
        }

        public Fornecedor ObterFornecedorUnico(int Id)
        {
            try
            {
                //Busca o fornecedor pelo Id
                var forn = repositorioFornecedor.GetFornecedor(Id);

                //Busca todos os enderecos dos fornecedores encontrados
                forn.Enderecos = repositorioEndereco.GetEnderecos(new List<int>() { Id }).ToList();

                return forn;

            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] ObterFornecedorUnico() > {ex.Message} ");
            }
        }
    }
}
