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
        public string rutAModificar;
        public ModificacionUsuario()
        {
            InitializeComponent();
            //cbEstado.SelectedIndex = 1;
           
         
        }
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ApiOperacion ops = new ApiOperacion();
            Rol rol = ops.ListarRol();
            cbRol.SelectedValuePath = "idRol";
            cbRol.DisplayMemberPath = "nombre";
            cbRol.ItemsSource = rol.result;
            btnNoEdit.IsEnabled = false;
            if (rutAModificar != null)
            {
                txtBrut.Text = rutAModificar;
                var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Buscando Datos....");
                ProgressAlert.SetIndeterminate();
                await RellenarDatos(ProgressAlert, rutAModificar);

            }
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
            if (txtBrut.Text.Length==0)
            {
                errormessage.Text = "Ingresar Rut ";
                txtBrut.Focus();
            }
            else
            {
                HabilitarContenido();
                btnNoEdit.IsEnabled = true;
            }


        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBrut.Text.Length==0)
            {
                errormessage.Text = "Ingresar Rut";
                txtBrut.Focus();
            }
            else if (txtBrut.Text.Length < 8 || txtBrut.Text.Length > 11)
            {
                errormessage.Text = "Ingresar Rut Valido";
                txtBrut.Focus();
            }
            else if (txtPass.Text.Length==0 || txtTelefono.Text.Length==0 || txtNombre.Text.Length== 0 || txtApellidoP.Text.Length == 0 || txtApellidoM.Text.Length== 0 || txtEmail.Text.Length== 0)
            {
                errormessage.Text = "Ingresar Datos";
                txtBrut.Focus();
            }
            else
            {
            errormessage.Text = string.Empty;         
            string rut = txtBrut.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellidoM = txtApellidoM.Text.Trim();
            string apellidoP = txtApellidoP.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string pass = txtPass.Text.Trim();
                int idEstado = cbEstado.SelectedIndex + 1;
                int idRol = cbRol.SelectedIndex + 1;

                var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Realizando Cambios....");
                ProgressAlert.SetIndeterminate(); //Infinite
                try
                {
                    ApiOperacion ops = new ApiOperacion();
                    Usuario user = ops.Modificar(rut, nombre, apellidoM, apellidoP, email, telefono, pass, idEstado, idRol);
                    
                    await Task.Delay(2500);
                    await ProgressAlert.CloseAsync();
                    await this.ShowMessageAsync("Operacion Realizada", "Modificación exitosa");
                }
                catch (Exception)
                {

                    await Task.Delay(2500);
                    await ProgressAlert.CloseAsync();
                    await this.ShowMessageAsync("Error", "Intente Nuevamente");
                }

            DeshabilitarContenido();
           

           }
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBrut.Text.Length == 0)
            {
                errormessage.Text = "Ingresar rut";
                txtBrut.Focus();
            }
            else if (txtBrut.Text.Length <8 || txtBrut.Text.Length > 11)
            {
                errormessage.Text = "Ingresar rut valido";
                txtBrut.Focus();
            }
            else
            {
                var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Buscando Usuario....");
                ProgressAlert.SetIndeterminate(); //Infinite
                errormessage.Text = string.Empty;
                string rut = txtBrut.Text.Trim();
                await RellenarDatos(ProgressAlert, rut);
            }
        }

        private async Task RellenarDatos(ProgressDialogController ProgressAlert, string rut)
        {
            ApiOperacion ops = new ApiOperacion();
            Usuario user = ops.Buscar(rut);
            try
            {
                if (user.result[0] == null)
                {
                    await Task.Delay(2500);
                    await ProgressAlert.CloseAsync();
                    await this.ShowMessageAsync("Problema en la Búsqueda", "Rut No Encontrado");
                    txtBrut.Focus();
                }
                else
                {
                    await Task.Delay(2000);
                    await ProgressAlert.CloseAsync();
                    txtNombre.Text = user.result[0].nombre;
                    txtApellidoM.Text = user.result[0].apellidoMaterno;
                    txtApellidoP.Text = user.result[0].apellidoPaterno;
                    txtEmail.Text = user.result[0].correoUsuario;
                    txtTelefono.Text = user.result[0].fonoUsuario;
                    txtPass.Text = user.result[0].claveUsuario;
                    int estado = user.result[0].idEstado;
                    if (estado == 1)
                    {
                        cbEstado.SelectedIndex = 0;
                    }
                    else
                    {
                        cbEstado.SelectedIndex = 1;
                    }
                    cbRol.SelectedIndex = user.result[0].idRol - 1;



                }
            }
            catch (Exception)
            {

                await Task.Delay(3000);
                await ProgressAlert.CloseAsync();
                await this.ShowMessageAsync("Problema de conexión :(", "Contacte al administrador");
            }
        }

        private void HabilitarContenido()
        {
            txtBrut.IsEnabled = false;
            txtNombre.IsEnabled = true;
            txtApellidoM.IsEnabled = true;
            txtApellidoP.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtPass.IsEnabled = true;
            cbEstado.IsEnabled = true;
            cbRol.IsEnabled = true;

            txtNombre.IsReadOnly = false;
            txtApellidoM.IsReadOnly = false;
            txtApellidoP.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtTelefono.IsReadOnly = false;
            txtPass.IsReadOnly = false;
            cbEstado.IsReadOnly = false;
            cbRol.IsReadOnly = false;
        }

        private void DeshabilitarContenido()
        {
            txtBrut.Focus();
            txtBrut.IsEnabled = true;
            txtBrut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtPass.Text = string.Empty;
            cbEstado.SelectedItem = null;
            cbRol.SelectedItem = null;

            txtBrut.IsEnabled = true;
            txtNombre.IsEnabled = false;
            txtApellidoM.IsEnabled = false;
            txtApellidoP.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtPass.IsEnabled = false;
            cbEstado.IsEnabled = false;
            cbRol.IsEnabled = false;

            txtNombre.IsReadOnly = true;
            txtApellidoM.IsReadOnly = true;
            txtApellidoP.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtTelefono.IsReadOnly = true;
            txtPass.IsReadOnly = true;
            cbEstado.IsReadOnly = true;
            cbRol.IsReadOnly = true;
        }

        private void btnNoEdit_Click(object sender, RoutedEventArgs e)
        {
            DeshabilitarContenido();

        }

        private void image1_Loaded(object sender, RoutedEventArgs e)
        {

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
