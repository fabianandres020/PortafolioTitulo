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
            int valor = 0;
            Usuario usuario = new Usuario();
            UsuarioRequest usuarioRequest = new UsuarioRequest();
            usuarioRequest.Mail = email;
            usuarioRequest.Clave = pass;
            string requestUrl = "http://186.64.123.8:8080/mi-estacionamiento-web/usuario/login/ADMIN@ADMIN.CL/admin";
            //string requestUrl = "http://localhost:8090/mi-estacionamiento-web/usuario/login";
            object JSONRequest = usuarioRequest;
            string JSONmethod = "POST";
            string JSONContentType = "application/json";
            Type JSONResponseType = typeof(UsuarioResponse);

            MakeRequest(requestUrl, JSONRequest, JSONmethod, JSONContentType, JSONResponseType);

                //mostrar ventana estilo w 8
                await this.ShowMessageAsync("Exito", "Tus datos son correctos");
                // mostrar la ventana menu
                Menu _ver = new Menu();
                //cerrar esta ventana 
                this.Close();
                _ver.ShowDialog();
            



            
        }
        public static object MakeRequest(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType, Type JSONResponseType)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                //WebRequest WR = WebRequest.Create(requestUrl);

                //string sb = JsonConvert.SerializeObject(JSONRequest);

                request.Method = JSONmethod;// "POST";
                request.ContentType = JSONContentType; // "application/json";
                /**
                Byte[] bt = Encoding.UTF8.GetBytes(sb);
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();
                **/

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    //  DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    // object objResponse = JsonConvert.DeserializeObject();
                    Stream stream1 = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream1);
                    string strsb = sr.ReadToEnd();
                    object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);

                    return objResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
