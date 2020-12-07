using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academia.Models
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("Produto_ID")]
        public int Codigo { get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("valor")]
        public double valor { get; set; }
    }
}