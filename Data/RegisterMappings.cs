using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Data
{
    public static class RegisterMappings
    {

        public static void Register()
        {

            if (FluentMapper.EntityMaps.Count == 0)
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new ClienteMap());
                    config.AddMap(new ConfiguracaoMap());
                    config.AddMap(new ClienteConfiguracaoMap());
                    config.ForDommel();
                });

            }
        }
    }
}
