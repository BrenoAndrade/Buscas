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
    }
}
