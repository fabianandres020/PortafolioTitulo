using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEstacionamiento
{
    public class UsuarioResponse
    {
        private String msg;

        private Usuario result;

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }

        public Usuario Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }
    }
}
