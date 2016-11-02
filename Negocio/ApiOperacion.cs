using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Negocio
{
    public class ApiOperacion
    {
        private string baseUrl;

        public ApiOperacion()
        {
            this.baseUrl = "http://186.64.123.8:8080/mi-estacionamiento-web";
        }
        public UsuarioTest Buscar (string rut)
        {
            string endpoint = this.baseUrl + "/usuario/slectByRut";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = "170992210"

            });
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                //UsuarioTest test = JsonConvert.DeserializeObject<UsuarioTest>(response);
                return JsonConvert.DeserializeObject<UsuarioTest>(response);

            }
            catch (Exception)
            {
                return null;
            }
        }
    

        public UsuarioTest autentificacion(string email, string pass)
        {
            string endpoint = this.baseUrl + "/usuario/login";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                mail = email,
                clave = pass
            });

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                //UsuarioTest test = JsonConvert.DeserializeObject<UsuarioTest>(response);
                return JsonConvert.DeserializeObject<UsuarioTest>(response);

            }
            catch (Exception)
            {
                return null;
            }
            }

            public UsuarioTest GetUserDetails(UsuarioTest user)
            {
            string endpoint = this.baseUrl + "/usuario/" + user.result.rutUsuario;
            string access_token = user.access_token;

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = access_token;
            try
            {
                string response = wc.DownloadString(endpoint);
                user = JsonConvert.DeserializeObject<UsuarioTest>(response);
                user.access_token = access_token;
                return user;
            }
            catch (Exception)
            {
                return null;
            }   
        }

    }
    }

