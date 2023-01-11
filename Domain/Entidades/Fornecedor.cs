using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Fornecedor
    {
        [Key]
        public int IdFornecedor { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public ICollection<Endereco>? Enderecos { get; set; }

        //[JsonIgnore]//Não mostrar no swagger a propriedade
        //public ICollection<EnderecoFornecedor>? EnderecoFornecedor { get; set; }

    }
}
