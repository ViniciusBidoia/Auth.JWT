using Auth.JWT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Domain.Models
{
    [Table(name: "Usuario")]
    public class Usuario : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataHoraRegistro { get; set; }
    }
}
