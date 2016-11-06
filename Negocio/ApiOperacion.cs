using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using MiEstacionamiento;

namespace Negocio
{
    public class ApiOperacion
    {
        private string baseUrl;

        public ApiOperacion()
        {
            this.baseUrl = "http://186.64.123.8:8080/mi-estacionamiento-web";
        }
        public Usuario listar ()
        {
            string endpoint = this.baseUrl + "/usuario/selectAll";
            string method = "POST";
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method);
               // IList<Usuario> cliente = JsonConvert.DeserializeObject<IList<Usuario>>(response);
                return JsonConvert.DeserializeObject<Usuario> (response);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Usuario Elminiar(string rut)
        {
            string endpoint = this.baseUrl + "/usuario/deleteByRut";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = rut

            });
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                Usuario test = JsonConvert.DeserializeObject<Usuario>(response);
                return JsonConvert.DeserializeObject<Usuario>(response);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public Usuario Modificar(string rut,string nombre,string apellidoM,string apellidoP,string email,string telefono)
        {
            string endpoint = this.baseUrl + "/usuario/update";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = rut,
                username = nombre,
                apellidoMaterno = apellidoM,
                apellidoPaterno = apellidoP,
                correoUsuario = email,
                fonoUsuario = telefono,
               
            });
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<Usuario>(response);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Usuario Buscar (string rut)
        {
            string endpoint = this.baseUrl + "/usuario/selectByRut";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = rut

            });
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                //Usuario test = JsonConvert.DeserializeObject<Usuario>(response);
                return JsonConvert.DeserializeObject<Usuario>(response);

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
                correoUsuario = email,
                claveUsuario = pass
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

