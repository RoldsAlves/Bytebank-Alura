using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        static void Teste()
        {
            List<int> idades = new List<int>();
            idades.Add(14);
            idades.Add(24);
            idades.Add(38);
            idades.AdicionarVarios(418, 540, 4808);
            //Extensoes<int>.AdicionarVarios(idades, 2, 3, 5);

            List<string> nomes = new List<string>();
            nomes.Add("Guilherme");
            nomes.Add("Rodolfo");
            nomes.Add("Lorena");
            nomes.AdicionarVarios("Lindolfo", "Flavia", "Amanda");
            //ListExtensoes<string>.AdicionarVarios(nomes, "Lindolfo", "Flavia", "Amanda");

        }
    }
}
