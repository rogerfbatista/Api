using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _repository;

        public ClienteBusiness(IClienteRepository repo)
        {
            _repository = repo;
        }
        public Cliente Autenticar(string nome, string senha)
        {
            return _repository.Autenticar(nome, senha);
        }


        public virtual List<Cliente> Obter()
        {
            return new List<Cliente>()
            {
                new Cliente()
                {
                    Nome ="Rogerio"
                }
            };
        }
        public  List<Cliente> ObterTodos()
        {

            return _repository.ObterTodos();

        }
    }
}
