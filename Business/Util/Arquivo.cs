using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business.Util
{
    public class Arquivo
    {
        public static void SalvarArquivoText(string caminho, string valores)
        {
            System.IO.File.WriteAllText(caminho, valores,Encoding.UTF8);

        }


        public static string ObterArquivoText(string caminho)
        {
            return System.IO.File.ReadAllText(caminho, Encoding.UTF8);

        }
    }
}
