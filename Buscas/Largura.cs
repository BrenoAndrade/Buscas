using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca;

namespace Buscas
{
    public class Largura
    {
        protected static Queue<No> Enfileirar(List<No> lst, Queue<No> fila)
        {
            foreach (var no in lst) { fila.Enqueue(no); }
            return fila;
        }

        public static List<No> Buscar(int[] aiInteiros)
        {
            var noBs = new No();
            noBs.Iniciar(aiInteiros);            
            var lst = QuebraCabeca.Sucessor(noBs);
            var fila = new Queue<No>();    
            fila = Enfileirar(lst, fila);
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

                fila = Enfileirar(QuebraCabeca.Sucessor(primeiro), fila);
            }

            lista = QuebraCabeca.Parentes(lista.Last());
            return lista;
        }
    }
}
