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
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }

        public string? CEP { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }


        [ForeignKey("Fornecedor")]
        [JsonIgnore]
        public int IdFornecedor { get; set; }


        [JsonIgnore]
        public Fornecedor? Fornecedor { get; set; }

    }
}
