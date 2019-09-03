using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                return db.FirstOrDefault<Cliente>(c => c.Nome == nome && c.Senha == senha);
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
