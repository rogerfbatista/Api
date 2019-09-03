using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class Cliente
    {
        public Cliente()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }
        public string Ambiente { get; set; }

        public List<Object> Configuraçao { get; set; }
    }
}
