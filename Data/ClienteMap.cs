using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Data
{
   public  class ClienteMap : DommelEntityMap<Cliente>
    {

        public ClienteMap()
        {
            ToTable("Cliente");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Nome).ToColumn("Nome");
            Map(x => x.Senha).ToColumn("Senha");
            Map(x => x.Ambiente).ToColumn("Ambiente");
            
        }
    }
}
