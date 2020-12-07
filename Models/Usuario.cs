using Academia.Models.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class Usuario
    {
        public Usuario()
        {
            criadoEm = DateTime.Now;
        }

        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
        public DateTime criadoEm { get; set; }
        public DateTime? dataMarcada { get; set; }
        public virtual Professor professor { get; set; }
        public virtual Aluno aluno { get; set; }
        public virtual Carrinho venda { get; set; }
    }

}
