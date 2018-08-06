using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Vehiculo
    {
        private int idVehiculo;
        private string placa;
        private string tipo;

        public int IdVehiculo
        {
            get
            {
                return idVehiculo;
            }

            set
            {
                idVehiculo = value;
            }
        }

        public string Placa
        {
            get
            {
                return placa;
            }

            set
            {
                placa = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
    }
}
