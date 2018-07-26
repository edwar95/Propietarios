using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	class Viaje
	{
		Fecha fechaAux = new Fecha();
		private string tipoVehiculo;
		private string chofer;

		public string TipoVehiculo
		{
			get
			{
				return tipoVehiculo;
			}

			set
			{
				tipoVehiculo = value;
			}
		}

		public string Chofer
		{
			get
			{
				return chofer;
			}

			set
			{
				chofer = value;
			}
		}


		public void asignarChofer(int NumeroPersonas)
		{

			Chofer chofer = new Chofer();
			int cont = 0;

			if (NumeroPersonas <= 5)
			{

				foreach (string line in File.ReadLines(@"Choferes.txt"))
				{
					Char delimiter = ';';
					String[] substrings = line.Split(delimiter);

					if (substrings[1] == "B" && cont == 0)
					{
						chofer.NombreChofer = substrings[0];
						chofer.TipoLicencia = substrings[1];
						cont += 1;
					}

				}
			}
			else if (NumeroPersonas > 5)
			{

				foreach (string line in File.ReadLines(@"Choferes.txt"))
				{
					Char delimiter = ';';
					String[] substrings = line.Split(delimiter);

					if (substrings[1] == "C" && cont == 0)
					{
						chofer.NombreChofer = substrings[0];
						chofer.TipoLicencia = substrings[1];
						cont += 1;
					}

				}
			}
			string lineAux = chofer.NombreChofer + ";" + chofer.TipoLicencia + ";";
			Console.WriteLine(chofer.NombreChofer + chofer.TipoLicencia);
			File.AppendAllText(@"reservacion.txt", lineAux);
		}

		public void asignarVehiculo(int NumeroPersonas)
		{
			Vehiculo vehiculo = new Vehiculo();
			int cont = 0;

			if (NumeroPersonas <= 5)
			{

				foreach (string line in File.ReadLines(@"vehiculo.txt"))
				{
					Char delimiter = ';';
					String[] substrings = line.Split(delimiter);

					if (substrings[1] == "auto" && cont == 0)
					{
						vehiculo.Tipo = substrings[1];
						vehiculo.Placa = substrings[0];
						cont += 1;
					}
				}
			}
			else if (NumeroPersonas > 5)
			{

				foreach (string line in File.ReadLines(@"vehiculo.txt"))
				{
					Char delimiter = ';';
					String[] substrings = line.Split(delimiter);

					if (substrings[1] == "bus" && cont == 0)
					{
						vehiculo.Tipo = substrings[1];
						vehiculo.Placa = substrings[0];
						cont += 1;
					}

				}
			}
			Console.WriteLine(vehiculo.Placa + vehiculo.Tipo);
			string lineAux = vehiculo.Tipo + ";" + vehiculo.Placa + ";";
			File.AppendAllText(@"reservacion.txt", lineAux);
		}

		public void asignarFecha(string fechaInicio, string fechaFin)
		{
			Fecha fecha = new Fecha();
			fecha.FechaInicio = fechaInicio;
			fecha.FechaFin = fechaFin;

			fechaAux = fecha;
			string lineAux = fecha.FechaInicio + ";" + fecha.FechaFin + System.Environment.NewLine;
			File.AppendAllText(@"reservacion.txt", lineAux);

		}

		private bool verificarDisponibilidadVehiculo(string fechaInicio, string fechaFin, string placa)
		{
			bool disponibilidad = false;
			Char delim_1 = '-';

			string auxIni = fechaInicio;
			String[] auxIni_ = auxIni.Split(delim_1);

			string auxFin = fechaFin;
			String[] auxFin_ = auxFin.Split(delim_1);


			foreach (string line in File.ReadLines(@"reservacion.txt"))
			{
				Char delimiter = ';';
				String[] substrings = line.Split(delimiter);


				string inicio = substrings[4];
				String[] subsInicio = inicio.Split(delim_1);

				string fin = substrings[5];
				String[] subsFin = fin.Split(delim_1);

				if (placa == substrings[3] && Convert.ToInt32(subsInicio[2]) > Convert.ToInt32(auxIni_[2]))
				{
					disponibilidad = false;
				}

			}

			return disponibilidad;
		}

	}
}
