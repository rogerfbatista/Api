using System.Collections.Generic;

namespace Domain
{
    public interface IClienteBusiness : IBaseBusiness<Cliente> 
    {
        Cliente Autenticar(string nome, string senha);

        List<Cliente> ObterTodos(string caminho);
    }
}
