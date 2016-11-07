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
    /// Lógica de interacción para AddUser.xaml
    /// </summary>
    public partial class AddUser : MetroWindow
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidoM = txtApellidoM.Text.Trim();
            string apellidoP = txtApellidoP.Text.Trim();
            string email = txtEmail.Text.Trim();
            string clave = txtClave.Text.Trim();
            string rol = txtRol.Text.Trim();
            string estado = txtEstado.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            ApiOperacion ops = new ApiOperacion();
            Usuario user = ops.Ingresar(rut, nombre, apellidoM, apellidoP,telefono, email, clave,rol,estado);
            await this.ShowMessageAsync("Exito", "Ingreso exitosa");
        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Administracion _ver = new Administracion();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }
    }
}
