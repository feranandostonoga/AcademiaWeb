using Academia.Models.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    [Table("TB_Avaliacao")]
    public class Avaliacao
    {
        public Avaliacao()
        {
            dtCriado = DateTime.Now;
            StatusAvaliacao = "Pendente";
        }

        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        public string StatusAvaliacao { get; set; }

        public int Pessoa_ID { get; set; }
        [ForeignKey("Pessoa_ID")]
        [Display(Name = "Pessoa")]
        public virtual Pessoa Pessoa { get; set; }

        public string Professor { get; set; }

        [Column("altura")]
        public string altura { get; set; }
        [Column("peso")]
        public string peso { get; set; }
        [Column("imc")]
        public string imc { get; set; }
        [Column("resultadoIMC")]
        public string resultadoIMC { get; set; }

        [Display(Name = "Data Marcou")]
        [Column("dtCriado")]
        public DateTime dtCriado { get; set; }
        [Column("dtMarcado")]
        public DateTime? dtMarcado { get; set; }
    }
}
