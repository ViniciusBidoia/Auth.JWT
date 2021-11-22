using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.Domain.Models.Base
{
    public class BaseEntity
    {
        //protected BaseEntity()
        //{
        //    Id = Guid.NewGuid();
        //}

        [Column(name: "Id")]
        public Guid Id { get; set; }
    }
}
