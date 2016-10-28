using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;
using System.Collections;

namespace Buscas
{
    public class CustoUniforme : Largura
    {
        private static Queue<No> Ordenar(Queue<No> lst)
        {
            return Enfileirar(lst.OrderBy(n => n._custoCaminho).ToList(), new Queue<No>());
        }

        public static new List<No> Buscar(int[] aiInteiros)
        {
            var noBs = new No();
            noBs.Iniciar(aiInteiros);
            var lst = QuebraCabeca.Sucessor(noBs);
            var fila = new Queue<No>();
            fila = Ordenar(Enfileirar(lst, fila));
            var lista = new List<No>();
            

            while (fila.Count > 0)
            {
                var primeiro = fila.Dequeue();
                lista.Add(primeiro);

                if (QuebraCabeca.TesteObjetivo(primeiro))
                {
                    Console.WriteLine("Sucesso!");
                    break;
                }

                fila = Ordenar(fila);
                fila = Enfileirar(QuebraCabeca.Sucessor(primeiro), fila);              
            }

            lista = QuebraCabeca.Parentes(lista.Last());
            return lista;
        }
    }
}
