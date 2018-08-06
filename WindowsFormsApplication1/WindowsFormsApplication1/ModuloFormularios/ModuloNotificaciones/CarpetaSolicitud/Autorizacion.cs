using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApplication1.CarpetaSolicitud
{
    class Autorizacion
    {
        public Boolean estado = false;
        public String fecha_autorizacion;
        
        LinkedList<string[]> list = new LinkedList<string[]>();
        string[] motivosValidos = { "Excursion", "Salida de campo", "Gira"};
        DateTime thisDay = DateTime.Today;


        //este analiza solo la que se envio para analizar, es decir, la que que se selecciono de la tabla de solicitudes de la ventana
        public void autorizacion(string[] a)
        {
            int i = 0;
           //se analiza que el motivo esté dentro de los permitidos
            if (a[8] == motivosValidos[0] || a[8] == motivosValidos[1] || a[8] == motivosValidos[2])
            {
                i++;
            }
            //analiza que el numero de pasajeros sea no tan grande como para sobrepasar la capacidad del vehiculo de mayor capacidad
            /*if (int.Parse(a[3]) < 35)
            {
                i++;
            }*/
            //compara la fecha para la cual se pidio el viaje, con la fecha de hoy
            int aux = DateTime.Compare(Convert.ToDateTime(a[5]), Convert.ToDateTime(thisDay.ToString("dd/MM/yyyy")));
            //si el resultado de aux es mayor que 0 entonces significa que la fecha para la cual se pidio el viaje sí está después de la de hoy
            if (aux > 0)
            {

                i++;
            }


            //si i==3 significa que se cumplieron todos los parametros para autorizar (se van analizar mas parametros, por ahora estan esos 3)
            if (i == 2)
            {
                a[9] = "Aprobada";
                estado = true;
            }


            

            //se crea un string con la solicitd aprobada
            string auxiliar = "";
            if (a[9] == "Aprobada")
            {
                for (int j = 0; j < 10; j++)
                {
                    
                        auxiliar += a[j] + ",";
                   

                }

                //si se aprobó, se le pone una fecha a la autorizacion
                fecha_autorizacion = thisDay.ToString("dd/MM/yyyy");

                //se la añade la fecha de autorizacion a la solicitud aprobada
                auxiliar += fecha_autorizacion;

                //se escribe la solicitud aprobada en el archivo de las aprobadas

            }






        }






        //este analiza todas las solicitudes de golpe, no se la llama en ningun lado por el momento, solo se la usó para hacer pruebas al inicio

        public void autorizar()
        {
          
            int i = 0;
            foreach(string[] a in list)
            {
                i = 0;
                if (a[4]==motivosValidos[0] || a[4]==motivosValidos[1] || a[4] == motivosValidos[2])
                {
                    i++;
                }
                if (int.Parse(a[3])<35)
                {
                    i++;
                }
                int aux = DateTime.Compare(Convert.ToDateTime(a[5]), Convert.ToDateTime(thisDay.ToString("dd/MM/yyyy")));
                if (aux > 0)
                {
                   
                    i++;
                }

                if (i==3)
                {
                    a[8] = "aprobada";
                }

                      

            }

            string auxiliar = "";
            foreach(string[] b in list){
                auxiliar = "";
                if (b[8] == "aprobada")
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j != 8)
                        {
                            auxiliar += b[j] + ",";
                        }
                        else
                        {
                            auxiliar += b[j];
                        }

                    }
                }
                
            }


        }


        
    }
}
