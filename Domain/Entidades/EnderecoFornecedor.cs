using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class EnderecoFornecedor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }

        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }

        public Fornecedor? Fornecedor { get; set; }
  
    }
}
