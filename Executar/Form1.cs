using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buscas;
using Biblioteca;

namespace Executar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t0.Text = "1";
            t1.Text = "2";
            t2.Text = "3";
            t3.Text = "4";
            t4.Text = "5";
            t5.Text = "6";
            t6.Text = "7";
            t7.Text = "8";
            t8.Text = "9";
            t9.Text = "10";
            t10.Text = "11";
            t11.Text = "12";
            t12.Text = "-1";
            t13.Text = "13";
            t14.Text = "14";
            t15.Text = "15";
        }

        private void Print(List<No> _lst, int b)
        {
            var aux = _lst;

            tResultado.Text += "Busca em ";

            switch (b)
            {
                case 1:
                    tResultado.Text += "Largura";
                    break;
                case 2:
                    tResultado.Text += "Profundidade";
                    break;
                case 3:
                    tResultado.Text += "Profundidade Limitada";
                    break;
                case 4:
                    tResultado.Text += "Aprofundamento Iterativo";
                    break;
                case 5:
                    tResultado.Text += "Custo Uniforme";
                    break;
            }

            tResultado.Text += System.Environment.NewLine + "Profundidade: " + aux[0]._profundidade;
            tResultado.Text += System.Environment.NewLine + "Custo caminho: " + aux[0]._custoCaminho;

            for (int j = aux.Count - 1; j >= 0; j--)
            {
                tResultado.Text += System.Environment.NewLine;

                for (int i = 0; i < 16; i++)
                {
                    if (i % 4 == 0)
                    {
                        if (aux[j]._estado[i] < 10 && aux[j]._estado[i] != -1)
                            tResultado.Text += System.Environment.NewLine + "0" + aux[j]._estado[i];
                        else
                            tResultado.Text += System.Environment.NewLine + aux[j]._estado[i];
                    }
                    else
                    {
                        if (aux[j]._estado[i] < 10 && aux[j]._estado[i] != -1)
                            tResultado.Text += "|0" + aux[j]._estado[i];
                        else
                            tResultado.Text += "|" + aux[j]._estado[i];
                    }
                }
            }
        }

        private List<No> BLargura(int[] aiInteiros)
        {
            return Largura.Buscar(aiInteiros);
        }

        private List<No> BCustoUniforme(int[] aiInteiros)
        {
            return CustoUniforme.Buscar(aiInteiros);
        }

        private List<No> BProfundidade(int[] aiInteiros)
        {
            return Profundidade.Buscar(aiInteiros);
        }

        private List<No> BProfundidadeLimitada(int[] aiInteiros, int limite)
        {
            return ProfundidadeLimitada.Buscar(aiInteiros, limite);
        }

        private List<No> BAprofundamentoIterativo(int[] aiInteiros)
        {
            return AprofundamentoIterativo.Buscar(aiInteiros);
        }

        private int[] ObterVetor()
        {
            int[] vetor = { Convert.ToInt32(t0.Text), Convert.ToInt32(t1.Text), Convert.ToInt32(t2.Text), Convert.ToInt32(t3.Text),
                            Convert.ToInt32(t4.Text), Convert.ToInt32(t5.Text), Convert.ToInt32(t6.Text), Convert.ToInt32(t7.Text),
                            Convert.ToInt32(t8.Text), Convert.ToInt32(t9.Text), Convert.ToInt32(t10.Text), Convert.ToInt32(t11.Text),
                            Convert.ToInt32(t12.Text), Convert.ToInt32(t13.Text), Convert.ToInt32(t14.Text), Convert.ToInt32(t15.Text) };

            return vetor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tResultado.Text = "";

            int b = 0;
            int[] aiInteiros = ObterVetor();

            var lst = new List<No>();

            if (cbLargura.Checked == true) { lst = BLargura(aiInteiros); b = 1; }
            if (cbProfundidade.Checked == true) { lst = BProfundidade(aiInteiros); b = 2; }
            if (cbProfundidadeLimitada.Checked == true && tProfundidade.Text != "") { lst = BProfundidadeLimitada(aiInteiros, Convert.ToInt32(tProfundidade.Text)); b = 3; }
            if (cbAprofundamentoIterativo.Checked == true) {  lst = BAprofundamentoIterativo(aiInteiros) ; b = 4; }
            if (cbCustoUniforme.Checked == true) { lst = BCustoUniforme(aiInteiros); b = 5; }

            Print(lst, b);
        }
    }
}
