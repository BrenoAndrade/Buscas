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
                case 6:
                    tResultado.Text += "Gulosa";
                    break;
                case 7:
                    tResultado.Text += "A*";
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

        private List<No> BGulosa(int[] aiInteiros, bool h1)
        {
            return Gulosa.Buscar(aiInteiros, h1);
        }

        private List<No> BAEstrela(int[] aiInteiros, bool h1)
        {
            return AEstrela.Buscar(aiInteiros, h1);
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
            tResultado.Visible = true;
            dtgTabela.Visible = false;
            tResultado.Text = "";

            int b = 0;
            int[] aiInteiros = ObterVetor();
            bool h1 = false;

            var lst = new List<No>();

            if (cbLargura.Checked == true) { lst = BLargura(aiInteiros); b = 1; }
            if (cbProfundidade.Checked == true) { lst = BProfundidade(aiInteiros); b = 2; }
            if (cbProfundidadeLimitada.Checked == true && tProfundidade.Text != "") { lst = BProfundidadeLimitada(aiInteiros, Convert.ToInt32(tProfundidade.Text)); b = 3; }
            if (cbAprofundamentoIterativo.Checked == true) {  lst = BAprofundamentoIterativo(aiInteiros) ; b = 4; }
            if (cbCustoUniforme.Checked == true) { lst = BCustoUniforme(aiInteiros); b = 5; }
            if (cbGulosa.Checked == true) { if (cbH1.Checked == true) { h1 = true; } else if (cbH2.Checked == true) { h1 = false; } lst = BGulosa(aiInteiros, h1); b = 6; }
            if (cbAEstrela.Checked == true) { if (cbH1.Checked == true) { h1 = true; } else if (cbH2.Checked == true) { h1 = false; } lst = BAEstrela(aiInteiros, h1); b = 7; }

            Print(lst, b);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tResultado.Visible = false;
            dtgTabela.Visible = true;
            int[] aiInteiros = ObterVetor();

            var gulosaH1 = BGulosa(aiInteiros, true);
            var gulosaH2 = BGulosa(aiInteiros, false);
            
            var AEstrelaH1 = BAEstrela(aiInteiros, true);
            var AEstrelaH2 = BAEstrela(aiInteiros, false);

            tResultado.Text = "";
            String g1, g2, a1, a2;
             for (int i = 1, a = gulosaH1.Count - 1, b = gulosaH2.Count - 1, c = AEstrelaH1.Count - 1, d = AEstrelaH2.Count - 1; a >= -1 || b >= -1 || c >= -1 || d >= -1   ; i++, a--, b--, c--, d--)
             {
                if (a >= 0) { g1 = gulosaH1[a]._heuristica_1.ToString(); } else { g1 = ""; }
                if (b >= 0) { g2 = gulosaH2[b]._heuristica_2.ToString(); } else { g2 = ""; }
                if (c >= 0) { a1 = AEstrelaH1[c]._heuristica_1.ToString(); } else { a1 = ""; }
                if (d >= 0) { a2 = AEstrelaH2[d]._heuristica_2.ToString(); } else { a2 = ""; }
                dtgTabela.Rows.Add(i, g1, g2, a1, a2);
             }
        }
    }
}
