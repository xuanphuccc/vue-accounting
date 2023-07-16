using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DeleteManyDto
    {
        [Required(ErrorMessage ="Id không được để trống")]
        public Guid Id { get; set; }
    }
}
