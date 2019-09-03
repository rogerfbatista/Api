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

   public class ConfiguracaoMap : DommelEntityMap<Configuracao>
   {

       public ConfiguracaoMap()
       {
           ToTable("Configuracao");
           Map(x => x.Id).ToColumn("Id").IsKey();
           Map(x => x.Nome).ToColumn("Nome");
          

       }
   }

   public class ClienteConfiguracaoMap : DommelEntityMap<ClienteConfiguracao>
   {

       public ClienteConfiguracaoMap()
       {
           ToTable("ClienteConfiguracao");
           Map(x => x.Id).ToColumn("Id").IsKey();
           Map(x => x.IdCliente).ToColumn("idCliente");
           Map(x => x.IdConfiguracao).ToColumn("idConfiguracao");
           Map(x => x.Ativo).ToColumn("ativo");

       }
   }
}
