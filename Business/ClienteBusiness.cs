using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;

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
        public List<Cliente> ObterTodos(string caminho)
        {
            var lista = _repository.ObterTodos();
            var result = JsonConvert.SerializeObject(lista);

            var key = "6UHjPgXZzXCGkhxV2QCnooyJexUzvJrw";

            var encrypt = Util.Aes256CbcEncrypter.Encrypt(result, key);

            Util.Arquivo.SalvarArquivoText(caminho, encrypt);

            var txt = Util.Arquivo.ObterArquivoText(caminho);

            var decrypted = Util.Aes256CbcEncrypter.Decrypt(txt, key);


            return lista;

        }

        public List<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
