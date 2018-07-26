using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Chofer
    {
        private string nombreChofer;
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
    }
}
