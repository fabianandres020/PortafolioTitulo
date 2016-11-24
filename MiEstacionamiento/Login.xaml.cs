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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Data.Common;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Negocio;
using System.Text.RegularExpressions;

namespace MiEstacionamiento
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {

       
        public Login()
        {
            InitializeComponent();

        }



        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var ProgressAlert = await this.ShowProgressAsync("Conectando con el servidor", "Sincronizando datos....");
            ProgressAlert.SetIndeterminate(); //Infinite

            try
            {
                if (txtemail.Text.Length == 0 || txtpws.Password.Length == 0)
                {
                    await ProgressAlert.CloseAsync();
                    errormessage.Text = "Ingresar datos";
                    txtemail.Focus();
                }
                else if (!Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    await ProgressAlert.CloseAsync();
                    errormessage.Text = "Ingresar un Correo Valido.";
                    txtemail.Select(0, txtemail.Text.Length);
                    txtemail.Focus();
                }
                else
                {
             
                string email = txtemail.Text.Trim();
                string pass = txtpws.Password.Trim();
                ApiOperacion ops = new ApiOperacion();
                UsuarioTest user = ops.autentificacion(email, pass);
                
                if (user.result == null)
                {

                        await Task.Delay(3000);
                        await ProgressAlert.CloseAsync();
                        await this.ShowMessageAsync("Problemas de autentificación", "Tus datos son Incorrectos");
                        txtemail.Focus();

                }
                else if(user.result.idRol==3)
                {
                    
                        Globals.LoggedInUser = user;
                        await Task.Delay(3000);
                        await ProgressAlert.CloseAsync();
                      
                        Menu _ver = new Menu();
                    //cerrar esta ventana 
                    this.Close();
                    _ver.ShowDialog();
                }
                else
                {
                        await Task.Delay(3000);
                        await ProgressAlert.CloseAsync();
                        await this.ShowMessageAsync("Problemas de autentificación", "Acceso denegado,No posees los permisos suficientes ");
                        txtemail.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                string log = ex.Message;
                await Task.Delay(3000);
                await ProgressAlert.CloseAsync();
                await this.ShowMessageAsync("Problema de conexión", "Contactar a supervisor");
            }
        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Lista _ver = new Lista();
            _ver.consultor = true;
            //cerrar esta ventana 
            this.Close();
            _ver.ShowDialog();
        }
    }
}
