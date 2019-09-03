using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Domain;
using Dommel;

namespace Data
{
    public class ClienteRepository : IClienteRepository
    {
        private string ConnectionString;

        public ClienteRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        }

        public Cliente Autenticar(string nome, string senha)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                        var sql = @"SELECT DISTINCT
                        c.Id
                        ,c.[Nome]
                        , con.Nome as NomeConfiguracao
                        ,[Senha]
                        ,[Ambiente]
                        FROM [ModernStore].[dbo].[Cliente] c
                        inner join [dbo].[ClienteConfiguracao] cc
                        on c.Id = cc.idCliente
                        INNER JOIN [dbo].[Configuracao] con
                        on  con.Id = cc.idConfiguracao ";
                        return db.Query<Cliente>(sql)
                            .FirstOrDefault<Cliente>(cliente => cliente.Nome == nome && cliente.Senha == senha);


                        //  return db.FirstOrDefault<Cliente>(cliente => cliente.Nome == nome && cliente.Senha == senha);


            }
        }

        public List<Cliente> ObterTodos()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<Cliente>().AsList();
            }
        }
    }
}
