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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para AddUser.xaml
    /// </summary>
    public partial class AddUser : MetroWindow
    {
        public bool completado = false;
        public AddUser()
        {
            InitializeComponent();
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ApiOperacion ops = new ApiOperacion();
            Rol rol = ops.ListarRol();
            cbRol.SelectedValuePath = "idRol";
            cbRol.DisplayMemberPath = "nombre";
            cbRol.ItemsSource = rol.result;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length == 0)
            {
                errormessage.Text = "Ingresar Rut";
                txtRut.Focus();
            }
            else if (txtRut.Text.Length < 8 || txtRut.Text.Length > 11)
            {
                errormessage.Text = "Ingresar Rut Valido";
                txtRut.Focus();
            }
            else if (txtNombre.Text.Length == 0 || txtApellidoP.Text.Length == 0 || txtApellidoM.Text.Length == 0 || txtEmail.Text.Length == 0 || cbRol.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                errormessage.Text = "Ingresar Datos";
                txtRut.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Ingresar un Correo Valido.";
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                string rut = txtRut.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellidoM = txtApellidoM.Text.Trim();
                string apellidoP = txtApellidoP.Text.Trim();
                string email = txtEmail.Text.Trim();
                string clave = txtClave.Text.Trim();
                int idRol = cbRol.SelectedIndex + 1;
                int idEstado = cbEstado.SelectedIndex + 1;
                string telefono = txtTelefono.Text.Trim();
                ApiOperacion ops = new ApiOperacion();
                Usuario user = ops.Ingresar(rut, nombre, apellidoM, apellidoP, telefono, email, clave, idRol, idEstado);
                await this.ShowMessageAsync("Exito", "Ingreso exitosa");
            }

            
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
