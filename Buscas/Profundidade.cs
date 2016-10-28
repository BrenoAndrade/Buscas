using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca;

namespace Buscas
{
    public class Profundidade
    {
        protected static Stack<No> Empilhar(List<No> lst, Stack<No> pilha)
        {
            foreach (var no in lst) { pilha.Push(no); }

            return pilha;
        }

        public static List<No> Buscar(int[] aiInteiros)
        {
            var noBs = new No();
            noBs.Iniciar(aiInteiros);
            var lst = QuebraCabeca.Sucessor(noBs);
            var pilha = new Stack<No>();
            pilha = Empilhar(lst, pilha);
            var lista = new List<No>();

            while (pilha.Count > 0)
            {
                var primeiro = pilha.Pop();
                lista.Add(primeiro);

                if (QuebraCabeca.TesteObjetivo(primeiro))
                {
                    Console.WriteLine("Sucesso!");
                    break;
                }

                pilha = Empilhar(QuebraCabeca.Sucessor(primeiro), pilha);
            }
            
            return QuebraCabeca.Parentes(lista.Last());
        }
    }
}
