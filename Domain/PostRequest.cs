using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PostRequest
    {
        public PostRequest()
        {

        }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string value { get; set; }
    }
}
