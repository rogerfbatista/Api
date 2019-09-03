using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IClienteBusiness : IBaseBusiness<Cliente> 
    {
        Cliente Autenticar(string nome, string senha);
    }
}
