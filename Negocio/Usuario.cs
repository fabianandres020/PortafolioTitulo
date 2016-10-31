using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEstacionamiento
{
    public class Usuario
    {

        private String rutUsuario;
 
        private int idUsuario;

        private String nombre;

        private String apellidoPaterno;

        private String apellidoMaterno;

        private String correoUsuario;

        private String claveUsuario;

        private int idEstado;

        private String fonoUsuario;

        private int idRol;

        public string RutUsuario
        {
            get
            {
                return rutUsuario;
            }

            set
            {
                rutUsuario = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return apellidoPaterno;
            }

            set
            {
                apellidoPaterno = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return apellidoMaterno;
            }

            set
            {
                apellidoMaterno = value;
            }
        }

        public string CorreoUsuario
        {
            get
            {
                return correoUsuario;
            }

            set
            {
                correoUsuario = value;
            }
        }

        public string ClaveUsuario
        {
            get
            {
                return claveUsuario;
            }

            set
            {
                claveUsuario = value;
            }
        }

        public int IdEstado
        {
            get
            {
                return idEstado;
            }

            set
            {
                idEstado = value;
            }
        }

        public string FonoUsuario
        {
            get
            {
                return fonoUsuario;
            }

            set
            {
                fonoUsuario = value;
            }
        }

        public int IdRol
        {
            get
            {
                return idRol;
            }

            set
            {
                idRol = value;
            }
        }
    }
}
