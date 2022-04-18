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
        

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            this.lblResultado.Text =resultado.ToString();

            lstOperaciones.Items.Add($"{this.txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {this.txtNumero2.Text} = {resultado}");

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

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.btnConvertirADecimal.Enabled = false;
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = true;
        }

        private void btnConvertirABinario_click(object sender, EventArgs e)
        {
            this.btnConvertirABinario.Enabled = false;
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = true;
        }

        private void FormCalculadora_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
