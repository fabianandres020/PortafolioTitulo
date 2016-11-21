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
            this.baseUrl = "http://186.64.123.8:80/mi-estacionamiento-web";
        }
        public Usuario Ingresar(string rut, string nombre, string apellidoM, string apellidoP,string telefono, string email, string clave, string rol, string estado)
        {
            string endpoint = this.baseUrl + "/usuario/insert";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = rut,
                nombre = nombre,
                apellidoPaterno = apellidoP,
                apellidoMaterno = apellidoM,
                correoUsuario = email,
                claveUsuario = clave,
                idEstado = estado,
                fonoUsuario = telefono,
                idRol = rol

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
        public Rol ListarRol()
        {
            string endpoint = this.baseUrl + "/rol/selectAll";
            string method = "POST";
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method);
                // IList<Usuario> cliente = JsonConvert.DeserializeObject<IList<Usuario>>(response);
                return JsonConvert.DeserializeObject<Rol>(response);
            }
            catch (Exception)
            {
                return null;
            }
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
        public Usuario Modificar(string rut,string nombre,string apellidoM,string apellidoP,string email,string telefono,string pass,int idEstado , int idRol)
        {
            string endpoint = this.baseUrl + "/usuario/update";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                rutUsuario = rut,
                nombre = nombre,
                apellidoMaterno = apellidoM,
                apellidoPaterno = apellidoP,
                correoUsuario = email,
                claveUsuario = pass,
                fonoUsuario = telefono,
                idEstado=idEstado,
                idRol=idRol
               
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
        public Vehiculo Ingresar (string patente,string rut_propietario,string rut_usuario,string tipo_veh,string id_marca)
        {
            string endpoint = this.baseUrl + "/vehiculo/insert";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                patente = patente,
                rutUsuario=rut_usuario,
                rutPropietario = rut_propietario,
                idTipoVehiculo = tipo_veh,
                idMarca = id_marca

            });
            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            try
            {
                string response = wc.UploadString(endpoint, method, json);
                return JsonConvert.DeserializeObject<Vehiculo>(response);
            }
            catch (Exception)
            {
                return null;
            }
        }  
        
        

    }
    }

