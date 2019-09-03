using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IBaseBusiness<T> where T : class
    {
        List<T> ObterTodos();

    }
}
