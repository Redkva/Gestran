using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorio
{
    public interface IRepositorioEndereco : IRepositorio<Endereco>
    { 
        public List<Endereco> GetEnderecos(List<int> fornecedoresIds);

    }
}
