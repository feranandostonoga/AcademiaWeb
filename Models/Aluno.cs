using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    [Table("TB_Aluno")]
    public class Aluno : Pessoa
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
    }
}
