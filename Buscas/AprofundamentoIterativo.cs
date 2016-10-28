using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca;

namespace Buscas
{
    public class AprofundamentoIterativo : Profundidade
    {
        public static new List<No> Buscar(int[] aiInteiros)
        {
            var noBs = new No();
            noBs.Iniciar(aiInteiros);
            var lst = QuebraCabeca.Sucessor(noBs);
            var pilha = new Stack<No>();
            pilha = Empilhar(lst, pilha);
            var lista = new List<No>();
            var profundidade = 1;

            while (true)
            {
                var primeiro = pilha.Pop();
                lista.Add(primeiro);

                if (QuebraCabeca.TesteObjetivo(primeiro))
                {
                    Console.WriteLine("Sucesso!");
                    break;
                }

                lst = QuebraCabeca.Sucessor(primeiro);

                if (primeiro._profundidade <= profundidade)
                    pilha = Empilhar(lst, pilha);

                if (pilha.Count == 0)
                {
                    profundidade++;
                    pilha = Empilhar(QuebraCabeca.Sucessor(noBs), pilha);
                }

                Console.WriteLine("lst - " + pilha.Count);
            }

            return QuebraCabeca.Parentes(lista.Last());
        }
    }
}
