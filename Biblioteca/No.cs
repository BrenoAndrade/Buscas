namespace Biblioteca
{
    public class No
    {
        public No _pai;
        public string _acao;
        public int[] _estado = new int[16];
        public int _custoCaminho;
        public int _profundidade;
        public int _heuristica_1;
        public int _heuristica_2;
        public int _heuristica_custo;

        public void Iniciar(int[] EstadoInicial)
        {
            for(int i = 0; i < EstadoInicial.Length; i++)
            {
                _estado[i] = EstadoInicial[i];
            }          
            this._custoCaminho = 0;
            this._profundidade = 0;
            this._acao = "First!"; 
        }
    }
}
