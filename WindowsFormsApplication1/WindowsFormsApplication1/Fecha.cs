using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Fecha
    {
        private string fechaInicio;
        private string fechaFin;

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
            }
        }
    }
}
