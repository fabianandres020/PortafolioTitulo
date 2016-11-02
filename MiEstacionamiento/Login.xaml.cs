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
            
            string email = txtemail.Text.Trim();
            string pass = txtpws.Password.Trim();
            ApiOperacion ops = new ApiOperacion();
            UsuarioTest user = ops.autentificacion(email, pass);

            if (user.result == null)
            {
                await this.ShowMessageAsync("Oh hubo un problema :(", "Tus datos son Incorrectos");
             
            }
            else
            {
                Globals.LoggedInUser = user;
                //mostrar ventana estilo w 8
                await this.ShowMessageAsync("Exito!", "Tus datos son correctos");
                // mostrar la ventana menu
                Menu _ver = new Menu();
                //cerrar esta ventana 
                this.Close();
                _ver.ShowDialog();
            }
        

            //int valor = 0;
            //Usuario usuario = new Usuario();
            //UsuarioRequest usuarioRequest = new UsuarioRequest();
            //usuarioRequest.Mail = email;
            //usuarioRequest.Clave = pass;
            ////string requestUrl = "http://186.64.123.8:8080/mi-estacionamiento-web/usuario/login/ADMIN@ADMIN.CL/admin";
            //string requestUrl = "http://localhost:8090/mi-estacionamiento-web/usuario/login/adminasdjas/admin";
            //object JSONRequest = usuarioRequest;
            //string JSONmethod = "POST";
            //string JSONContentType = "application/json";
            //Type JSONResponseType = typeof(UsuarioResponse);

            //MakeRequest(requestUrl, JSONRequest, JSONmethod, JSONContentType, JSONResponseType);







        }
       
    }
}
