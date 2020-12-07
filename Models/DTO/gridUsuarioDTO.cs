using Academia.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class gridUsuarioDTO
    {
        [Display(Name = "Codigo")]
        public int Codigo { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Tipo")]
        public virtual EnumTipoUsuario TipoPessoa { get; set; }
    }
}