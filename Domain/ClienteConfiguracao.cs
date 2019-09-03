using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class ClienteConfiguracao
    {
        public ClienteConfiguracao()
        {

        }

        public int Id { get; set; }
       
        public  int IdCliente { get; set; }

        public int IdConfiguracao { get; set; }

        public  bool Ativo { get; set; }
    }
}

