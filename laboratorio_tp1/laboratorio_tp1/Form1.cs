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
        /// <summary>
        /// Hace uso del metodo Operar de la clase FormCalculadora, el resultado lo muestra a treaves del Label y guarda la operacion realizada en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            this.lblResultado.Text =resultado.ToString();

            lstOperaciones.Items.Add($"{this.txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {this.txtNumero2.Text} = {resultado}");

        }

        /// <summary>
        /// al apretar el boton pregunta si el usuario quiere cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// usa el metodo limpiar al precionar el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Limpia los textBox y label de la pantalla, ademas inhabilita los botones de conversion.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = " ";
            this.txtNumero2.Text = " ";
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = " ";
        }

        /// <summary>
        /// Se hace uso del metodo Operar de la clase Calculadora para que realice una operacion matematica entre dos numeros. 
        /// Tambien se le pasa el operador para que sepa que operacion realizar.
        /// </summary>
        /// <param name="numero1">Numero que se recibe mediante el txtOperando1</param>
        /// <param name="numero2">Numero que se recibe mediante el txtOperando2</param>
        /// <param name="operador">Operador que se recibe mediante el cmbOperador</param>
        /// <returns>Retorna el resultado de la operacion realizada.</returns>
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
        /// <summary>
        /// Boton que hace uso del metodo para convertir el numero recibido del label en decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.btnConvertirADecimal.Enabled = false;
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Boton que hace uso del metodo para convertir el numero recibido del label en binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_click(object sender, EventArgs e)
        {
            this.btnConvertirABinario.Enabled = false;
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Evento del Form que al querer cerrar la aplicacion pregunte al usuario si realmente  quiere hacerlo. Si asi lo desea, se cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
