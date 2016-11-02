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
                txtTipoU.Text = user.result[0].idRol.ToString();
                txtDireccion.Text = user.result[0].correoUsuario;
                txtTelefono.Text = "falta";
            }
        }
    }
}
