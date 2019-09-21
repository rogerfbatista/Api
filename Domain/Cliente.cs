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
            ListaConfiguracaos = new List<Configuracao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }
        public string Ambiente { get; set; }

        public List<Configuracao> ListaConfiguracaos { get; set; }
    }
}
