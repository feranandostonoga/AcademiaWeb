using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    [Table("TB_Professor")]
    public class Professor : Pessoa
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }
    }
}
