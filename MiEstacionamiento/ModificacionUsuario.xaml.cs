using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Negocio;

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para ModificacionUsuario.xaml
    /// </summary>
    public partial class ModificacionUsuario : MetroWindow
    {
        public ModificacionUsuario()
        {
            InitializeComponent();

        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Menu _ver = new Menu();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void txtBrut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtBrut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                if (ascci >= 48 && ascci <= 57) e.Handled = false;
                else e.Handled = true;
            }
        }

        private async void txtBrut_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
          
            txtNombre.IsReadOnly = false;
            txtApellidoM.IsReadOnly = false;
            txtApellidoP.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            //txtDireccion.IsReadOnly = false;

        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBrut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidoM = txtApellidoM.Text.Trim();
            string apellidoP = txtApellidoP.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
           // string direccion = txtDireccion.Text.Trim();
            ApiOperacion ops = new ApiOperacion();
            Usuario user = ops.Modificar(rut, nombre, apellidoM, apellidoP, email, telefono);
            await this.ShowMessageAsync("Exito", "Modificacion exitosa");
            txtBrut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            //txtDireccion.Text = string.Empty;
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBrut.Text.Trim();
            ApiOperacion ops = new ApiOperacion();
            Usuario user = ops.Buscar(rut);
            if (user.result[0] == null)
            {
                await this.ShowMessageAsync("Oh hubo un problema :(", "Rut no Encontrado");
            }
            else
            {
                txtNombre.Text = user.result[0].nombre;
                txtApellidoM.Text = user.result[0].apellidoMaterno;
                txtApellidoP.Text = user.result[0].apellidoPaterno;
                txtEmail.Text = user.result[0].correoUsuario;
                txtTelefono.Text = user.result[0].fonoUsuario;
                //txtDireccion.Text = "falta";
            }
        }
    }
}
