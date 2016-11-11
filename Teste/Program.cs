using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca;
using Buscas;

namespace Teste
{
    class Program
    {
        static void Print(List<No> _lst)
        {
            var aux = _lst;
            for (int j = aux.Count - 1; j >= 0; j--)
            {
                Console.Write("\n");

                for (int i = 0; i < 16; i++)
                {
                    if (i % 4 == 0)
                    {
                        if (aux[j]._estado[i] < 10 && aux[j]._estado[i] != -1)
                            Console.Write("\n0" + aux[j]._estado[i]);
                        else
                            Console.Write("\n" + aux[j]._estado[i]);
                    }
                    else
                    {
                        if (aux[j]._estado[i] < 10 && aux[j]._estado[i] != -1)
                            Console.Write("|0" + aux[j]._estado[i]);
                        else
                            Console.Write("|" + aux[j]._estado[i]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            int[] aiInteiros = {  1,   2,   3,  4,
                                  5,   6,   7,  8,
                                  9,  10,  11, 12,
                                 13,  14,  -1, 15};

            var lst = Gulosa.Buscar(aiInteiros, true);
            Print(lst);
            Console.WriteLine("\nProfundidade: " + lst.First()._custoCaminho);

            Console.ReadLine();
        }
    }
}