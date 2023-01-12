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
                ValidaDados(fornecedor);

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
            try
            {
                //Busca entidade no banco pelo Id
                var _f = ObterFornecedorUnico(Id);

                //Caso não retorne nada, então não existe no banco
                if (_f == null)
                    return "Fornecedor não existe";

                //Deleta do banco
                repositorioFornecedor.Delete(_f);

                return "Deletado com sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] Deletar() > {ex.Message} ");
            }
        }

        public string Editar(Fornecedor fornecedor)
        {
            try
            {
                ValidaDados(fornecedor, true);

                //Seta o Id do Fornecedor nos Enderecos, para nao dar erro na FK na hora do Insert
                fornecedor.Enderecos.ToList().ForEach(e => e.IdFornecedor = fornecedor.IdFornecedor);

                //Busca todos os enderecos do banco
                var enderecos = repositorioEndereco.GetEnderecos(new List<int>() { fornecedor.IdFornecedor }).ToList();

                //Inserer os Enderecos Novos
                var enderecosNovos = fornecedor.Enderecos.Where(e => e.IdEndereco == 0 || !enderecos.Select(x => x.IdEndereco).Contains(e.IdEndereco)).ToList();
                enderecosNovos.ForEach(e =>
                {
                    e.IdEndereco = 0;
                    repositorioEndereco.Create(e);
                });

                //Atualiza os Enderecos que foram modificados
                var enderecosUpdate = fornecedor.Enderecos.Where(e => enderecos.Select(x => x.IdEndereco).Contains(e.IdEndereco)).ToList();
                enderecosUpdate.ForEach(e => repositorioEndereco.Edit(e));

                //Deleta os Enderecos
                var enderecosDelete = enderecos.Where(e => !fornecedor.Enderecos.Select(x => x.IdEndereco).Contains(e.IdEndereco)).ToList();
                enderecosDelete.ForEach(e => repositorioEndereco.Delete(e));

                //Atualiza Fornecedor
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

                if (forn == null)
                    throw new Exception($"Fornecedor nao existe");

                //Busca todos os enderecos dos fornecedores encontrados
                forn.Enderecos = repositorioEndereco.GetEnderecos(new List<int>() { Id }).ToList();

                return forn;

            }
            catch (Exception ex)
            {
                throw new Exception($" [DOMAIN LAYER] ObterFornecedorUnico() > {ex.Message} ");
            }
        }


        #region Utils

        public void ValidaDados(Fornecedor fornecedor, bool verificaExistenciaNoBanco = false)
        {
            try
            {
                if (fornecedor == null)
                    throw new Exception($"Nenhum fornecedor enviado no Body para cadastro");

                if (string.IsNullOrEmpty(fornecedor.Nome) || string.IsNullOrEmpty(fornecedor.Nome.Trim()))
                    throw new Exception($"O Nome do fornecedor deve ser informado");

                if (fornecedor.Enderecos == null || fornecedor.Enderecos.Count <= 0)
                    throw new Exception($"O fornecedor deve ter ao menos 1 Endereco");

                if ((string.IsNullOrEmpty(fornecedor.Email) && string.IsNullOrEmpty(fornecedor.Telefone)) || (string.IsNullOrEmpty(fornecedor.Email.Trim()) && string.IsNullOrEmpty(fornecedor.Telefone.Trim())))
                    throw new Exception($"O fornecedor deve ter ao menos um meio de contato(Email OU Telefone)");

                if (verificaExistenciaNoBanco)
                {
                    if (fornecedor.IdFornecedor == 0)
                        throw new Exception($"Id do fornecedor deve ser maior que zero(0) ");

                    var _f = ObterFornecedorUnico(fornecedor.IdFornecedor);

                    if (_f == null)
                        throw new Exception($"Nenhum fornecedor com o Id.{fornecedor.IdFornecedor} localizado");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($" ValidaDados() > {ex.Message} ");
            }
        }

        #endregion
    }
}
