using Academia.Models.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    [Table("TB_Pessoa")]
    public class Pessoa : RegisterViewModel
    {
        [Key]
        [Column("Pessoa_ID")]
        public int Codigo { get; set; }

        [Display(Name = "Tipo")]
        public virtual EnumTipoUsuario TipoPessoa { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario Usuario { get; set; }

    }
}
