using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace laboratorio_tp1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            this.lblResultado.Text =resultado.ToString();

        }
        private void btnConvertirADecimal(object sender, EventArgs e)
        {

        }

        private void btnConvertirABinario(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = " ";
            this.txtNumero2.Text = " ";
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = " ";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            char caracter;
            double resultado = 0;
            if(numero1 != null && numero2 != null && operador != null)
            {
                char.TryParse(operador, out caracter);
                Operando operador1 = new Operando(numero1);
                Operando operador2 = new Operando(numero2);

                resultado = Calculadora.Operador(operador1, operador2, caracter);
            }
            return resultado;
        }




    }
}
