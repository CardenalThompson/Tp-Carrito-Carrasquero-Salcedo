using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negosio;

namespace WindowsForms
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            btnIngresar.Enabled = false;  // el boton de ingresar en inicio sale desabilitado
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            FormPrincipal ventana2 = new FormPrincipal(tbnombre.Text);
            ventana2.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbnombre_TextChanged(object sender, EventArgs e)
        {
            if (tbnombre.Text.Trim() != String.Empty && tbnombre.Text.All(char.IsLetter)) // si no esta vacio y todas son letras
            {
                btnIngresar.Enabled = true;
                errorProvider1.SetError(tbnombre, "");
            }
            else
            {
                if (!(tbnombre.Text.All(char.IsLetter)))   // si no son todas letras
                {
                    errorProvider1.SetError(tbnombre, "el nombre solo debe contener letras");
                }
                else
                {
                    errorProvider1.SetError(tbnombre, "tiene que ingresar un nombre");
                }
                btnIngresar.Enabled = false;
            }
        }

        private void FormBienvenida_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void tbnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && tbnombre.Text != string.Empty)
            {
                FormPrincipal ventana2 = new FormPrincipal(tbnombre.Text);
                ventana2.ShowDialog();
            }
        }
    }
}
