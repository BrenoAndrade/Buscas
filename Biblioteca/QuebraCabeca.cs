using System.Collections.Generic;

namespace Biblioteca
{
    public static class QuebraCabeca
    {
        public static List<No> Parentes(No noBase)
        {
            var lst = new List<No>();

            lst.Add(noBase);

            while (noBase._pai != null)
            {
                noBase = noBase._pai;
                lst.Add(noBase);
            }

            return lst;
        } 

        public static List<No> Sucessor(No noBase)
        {
            int posicaoNula = PosicaoNula(noBase._estado);
            
            List<No> lst = new List<No>();
            No no;

            //subir
            if (posicaoNula < 12 && noBase._acao != "Descer")
            {
                no = new No();
                no._pai = noBase;
                no._acao = "Subir";
                no._custoCaminho = noBase._custoCaminho + 1;
                no._profundidade = noBase._profundidade + 1;
                no._estado = Subir(noBase._estado);
                no._heuristica_1 = CalcularHeuristica_1(no);
                no._heuristica_2 = CalcularHeuristica_2(no);
                lst.Add(no);
            }
            
            //descer
            if (posicaoNula > 3 && noBase._acao != "Subir")
            {
                no = new No();
                no._pai = noBase;
                no._acao = "Descer";
                no._custoCaminho = noBase._custoCaminho + 1;
                no._profundidade = noBase._profundidade + 1;
                no._estado = Descer(noBase._estado);
                no._heuristica_1 = CalcularHeuristica_1(no);
                no._heuristica_2 = CalcularHeuristica_2(no);
                lst.Add(no);
            }
            
            //direita
            if (posicaoNula != 0 && posicaoNula != 4 && posicaoNula != 8 && posicaoNula != 12 && noBase._acao != "Esquerda")
            {
                no = new No();
                no._pai = noBase;
                no._acao = "Direita";
                no._custoCaminho = noBase._custoCaminho + 1;
                no._profundidade = noBase._profundidade + 1;
                no._estado = Direita(noBase._estado);
                no._heuristica_1 = CalcularHeuristica_1(no);
                no._heuristica_2 = CalcularHeuristica_2(no);
                lst.Add(no);
            }
            
            //esquerda
            if (posicaoNula != 3 && posicaoNula != 7 && posicaoNula != 11 && posicaoNula != 15 && noBase._acao != "Direita")
            {
                no = new No();
                no._pai = noBase;
                no._acao = "Esquerda";
                no._custoCaminho = noBase._custoCaminho + 1;
                no._profundidade = noBase._profundidade + 1;
                no._estado = Esquerda(noBase._estado);
                no._heuristica_1 = CalcularHeuristica_1(no);
                no._heuristica_2 = CalcularHeuristica_2(no);
                lst.Add(no);
            }

            return lst;
        }

        private static int PosicaoNula(int[] vetor)
        {
            for (int i = 0; i < vetor.Length; i++)
            {
                if (vetor[i] == -1)
                    return i;
            }
            return -1;
        }

        private static int[] Subir(int[] vetor)
        {
            int[] novoVetor = new int[vetor.Length];

            for (int i = 0; i < vetor.Length; i++)
            {
                novoVetor[i] = vetor[i];
            }

            int vazio = PosicaoNula(vetor);
             
            novoVetor[vazio + 4] = vetor[vazio];
            novoVetor[vazio] = vetor[vazio + 4];

            return novoVetor;
        }

        private static int[] Descer(int[] vetor)
        {
            int[] novoVetor = new int[vetor.Length];

            for (int i = 0; i < vetor.Length; i++)
            {
                novoVetor[i] = vetor[i];
            }

            int vazio = PosicaoNula(vetor);

            novoVetor[vazio - 4] = vetor[vazio];
            novoVetor[vazio] = vetor[vazio - 4];

            return novoVetor;
        }

        private static int[] Direita(int[] vetor) 
        {
            int[] novoVetor = new int[vetor.Length];

            for (int i = 0; i < vetor.Length; i++)
            {
                novoVetor[i] = vetor[i];
            }

            int vazio = PosicaoNula(vetor);

            novoVetor[vazio - 1] = vetor[vazio];
            novoVetor[vazio] = vetor[vazio - 1];

            return novoVetor;
        }
        
        private static int[] Esquerda(int[] vetor)
        {
            int[] novoVetor = new int[vetor.Length];

            for (int i = 0; i < vetor.Length; i++)
            {
                novoVetor[i] = vetor[i];
            }

            int vazio = PosicaoNula(vetor);

            novoVetor[vazio + 1] = vetor[vazio];
            novoVetor[vazio] = vetor[vazio + 1];

            return novoVetor;
        }

        public static bool TesteObjetivo(No noBase)
        {
            for (int i = 0; i < 15; i++)
            {
                if (noBase._estado[i] != (i + 1)) return false;
            }

            return true;
        }

        public static int CalcularHeuristica_1(No noBase)
        {
            int cont = 0;

            for (int i = 0; i <= 15; i++)
            {
                if(noBase._estado[i] != -1)
                    if (noBase._estado[i] != (i + 1)) cont++;
            }

            return cont;
        }

        public static int CalcularHeuristica_2(No noBase)
        {
            int cont = 0;

            for (int i = 0; i < 16; i++)
            {
                int objetivo;
                if (noBase._estado[i] != -1) { objetivo = noBase._estado[i] - 1; } else { objetivo = -1; }

                int  linha, coluna;
                int[] arrayObjetivo = new int[2];
                int[] arrayNo = new int[2];

                if (objetivo != i && objetivo != -1)
                {
                    arrayNo = LinhaColuna(i);
                    arrayObjetivo = LinhaColuna(objetivo);

                    linha = arrayNo[0] - arrayObjetivo[0];
                    coluna = arrayNo[1] - arrayObjetivo[1];

                    if (linha < 0)
                        linha = linha * -1;
                    if (coluna < 0)
                        coluna = coluna * -1;

                    cont += linha + coluna;
                }
            }

            return cont;
        }

        private static int[] LinhaColuna(int no)
        {
            int linha, coluna;
            int[] pos = new int[2];

            if (no <= 3) linha = 0;
            else if (no <= 7) linha = 1;
            else if (no <= 11) linha = 2;
            else linha = 3;

            if (no == 0 || no == 4 || no == 8 || no == 12) coluna = 0;
            else if (no == 1 || no == 5 || no == 9 || no == 13) coluna = 1;
            else if (no == 2 || no == 6 || no == 10 || no == 14) coluna = 2;
            else coluna = 3;

            pos[0] = linha;
            pos[1] = coluna;

            return pos;
        }
    }
}
