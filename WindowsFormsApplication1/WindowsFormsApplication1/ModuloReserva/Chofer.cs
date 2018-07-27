using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Chofer
    {
        private int idChofer;
        private string cedulaChofer;
        private string nombreChofer;
        private string apellidoChofer;
        private string tipoLicencia;

        public string NombreChofer
        {
            get
            {
                return nombreChofer;
            }

            set
            {
                nombreChofer = value;
            }
        }

        public string TipoLicencia
        {
            get
            {
                return tipoLicencia;
            }

            set
            {
                tipoLicencia = value;
            }
        }

        public string CedulaChofer
        {
            get
            {
                return cedulaChofer;
            }

            set
            {
                cedulaChofer = value;
            }
        }

        public string ApellidoChofer
        {
            get
            {
                return apellidoChofer;
            }

            set
            {
                apellidoChofer = value;
            }
        }

        public int IdChofer
        {
            get
            {
                return idChofer;
            }

            set
            {
                idChofer = value;
            }
        }
    }
}
