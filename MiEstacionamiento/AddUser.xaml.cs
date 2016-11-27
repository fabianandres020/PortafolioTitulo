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
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiOperacion ops = new ApiOperacion();
                Rol rol = ops.ListarRol();
                cbRol.SelectedValuePath = "idRol";
                cbRol.DisplayMemberPath = "nombre";
                cbRol.ItemsSource = rol.result;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Problemas de Conexcion", "Contacte con el administrador de la base datos");
            }

        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Ingresando Usuario....");
            ProgressAlert.SetIndeterminate(); //Infinite
            if (txtRut.Text.Length == 0)
            {
                await ProgressAlert.CloseAsync();
                errormessage.Text = "Ingresar Rut";
                txtRut.Focus();
            }
            else if (txtRut.Text.Length < 8 || txtRut.Text.Length > 11)
            {
                await ProgressAlert.CloseAsync();
                errormessage.Text = "Ingresar Rut Valido";
            }
            else if (txtClave.Text.Length == 0 || txtNombre.Text.Length == 0 || txtApellidoP.Text.Length == 0 || txtApellidoM.Text.Length == 0 || txtEmail.Text.Length == 0 || cbRol.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                errormessage.Text = "Ingresar Datos";
                await ProgressAlert.CloseAsync();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                await ProgressAlert.CloseAsync();
                errormessage.Text = "Ingresar un Correo Valido.";
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else
            {
                errormessage.Text = string.Empty;
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
                if(user==null)
                {
                    await Task.Delay(2000);
                    await ProgressAlert.CloseAsync();
                    await this.ShowMessageAsync("Problemas de ingreso", "Usuario ya existente");
                    txtRut.Focus();
                }
                else
                {
                    await Task.Delay(2000);
                    await ProgressAlert.CloseAsync();
                    await this.ShowMessageAsync("Exito", "Ingreso exitosa");
                }
                
            }

            
        }

        private void btnVolver1_Click(object sender, RoutedEventArgs e)
        {
            Administracion _ver = new Administracion();
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }

        private void txtRut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                if (ascci >= 48 && ascci <= 57) e.Handled = false;
                else e.Handled = true;
            }
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
                if (ascci >= 48 && ascci <= 57) e.Handled = false;
                else e.Handled = true;
            }
        }
    }
}
