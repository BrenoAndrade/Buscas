using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Buscas
{
    public class Gulosa:Largura
    {
        public static List<No> Buscar(int[] aiInteiros, bool h1)
        {
            var noBs = new No();
            noBs.Iniciar(aiInteiros);
            noBs._heuristica_1 = QuebraCabeca.CalcularHeuristica_1(noBs);
            noBs._heuristica_2 = QuebraCabeca.CalcularHeuristica_2(noBs);
            var lst = QuebraCabeca.Sucessor(noBs);

            while (lst.Count > 0)
            {
                var noGeral = lst[0];
                
                foreach (var no in lst)
                {
                    if (QuebraCabeca.TesteObjetivo(no))
                    {
                        return QuebraCabeca.Parentes(no);
                    }

                    switch (h1)
                    {
                        case true:
                            if(noGeral._heuristica_1 > no._heuristica_1) { noGeral = no; }
                            break;
                        case false:
                            if (noGeral._heuristica_2 > no._heuristica_2) { noGeral = no; }
                            break;
                    }
                }
                lst = QuebraCabeca.Sucessor(noGeral);
            }
            return lst;
        }
    }
}
