using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Academia.Models
{
    [Table("TB_CARRINHO")]
    public class Carrinho
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        public int Pessoa_ID { get; set; }
        [ForeignKey("Pessoa_ID")]
        public virtual Pessoa Pessoas { get; set; }

        public int Produto_ID { get; set; }
        [ForeignKey("Produto_ID")]
        public virtual Produto Produtos { get; set; }
    }
}
