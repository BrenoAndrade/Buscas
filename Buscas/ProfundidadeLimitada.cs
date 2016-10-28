using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca;

namespace Buscas
{
    public class ProfundidadeLimitada : Profundidade
    {
        public static List<No> Buscar(int[] aiInteiros, int profundidade)
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
                    return QuebraCabeca.Parentes(lista.Last());
                }

                lst = QuebraCabeca.Sucessor(primeiro);

                if(primeiro._profundidade < profundidade)
                    pilha = Empilhar(lst, pilha);
            }

            throw new Exception("Objetivo não alcançado! <3");
        }
    }
}
