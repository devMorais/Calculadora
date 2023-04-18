using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        double n1 = 0, n2 =0;
        string operacao;
        int estado = 1;

        public MainPage()
        {
            InitializeComponent();
            Limpar(new Object(), new EventArgs());
        }
        private void LerValor(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(lbResultado.Text == "0")
            {
                lbResultado.Text = button.Text;
            }
            else
            {
                lbResultado.Text += button.Text;
            }
           
        }

        private void Limpar(Object sender, EventArgs e)
        {
            lbResultado.Text = "";
            
            //ZERAR AS VARIÁVEIS QUANDO LIMPAR
            n1 = 0;  
            n2 = 0;
            estado = 1;
        }

        private void LimpaUm(Object sender, EventArgs e)
        {
            if (lbResultado.Text.Length > 1)
            
                lbResultado.Text =  lbResultado.Text.Substring(0, lbResultado.Text.Length - 1);
            
            else
            
                lbResultado.Text = "";
            
        }

        private void Virgula(Object sender, EventArgs e)
        {
            if (lbResultado.Text != " ")
            {
                if(!lbResultado.Text.Contains("."))
                lbResultado.Text = lbResultado.Text + ".";
            }

        }

        private void RaizQuadrada(Object sender, EventArgs e)
        {
            if (lbResultado.Text != "" && lbResultado.Text != "0")
            {
                Button button = (Button)sender;
                operacao = button.Text;
                if (operacao == "X²")
                {
                    lbResultado.Text =( double.Parse(lbResultado.Text) * double.Parse(lbResultado.Text)).ToString();
                }else if(operacao == "√")
                {
                    lbResultado.Text = Math.Sqrt(double.Parse(lbResultado.Text)).ToString();
                }
            }
        }


        private void Operador(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operacao = button.Text;
            // VERIFICA SE O USUARIO INSERIU O PRIMEIRO NÚMERO
            if (lbResultado.Text != "0" && lbResultado.Text != "")
            {
                n1 = double.Parse(lbResultado.Text);
               // VERIFICA SE O USUARIO CLICOU EM ALGUM OPERADOR
                estado = 2;
                lbResultado.Text = "0";
            }


        }
        private void Calcular(Object sender, EventArgs e)
        {
            double res = 0; 

            if(estado == 2)
            {
                n2 = double.Parse(lbResultado.Text);
                if(operacao == "+")
                {
                    res = n1 + n2;
                }else if(operacao == "/")
                {
                    res = n1 / 2;
                }else if(operacao == "*")
                {
                    res = n1 * n2;
                }else if(operacao == "-")
                {
                    res = n1 - n2;
                }else if(operacao == "%")
                {
                    res = (n1 / 100) * n2;
                }
                
                this.lbResultado.Text = res.ToString();
            }
            

            
        }




    }
}
