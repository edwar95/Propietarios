using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModulosG4;


namespace Proyectov2.LeerArchivos
{
    class Leerfichero
    {

        TextReader leer_archivo;

//esta funcion me devuelve una lista de las solicitudes que están pendientes
        public ArrayList leerA2(String archivo)
        {
            Console.WriteLine("estoy leyendooo");
            ArrayList arrText= new ArrayList();

            string line;
            string retorno = "";
            string[] aray;
            StreamReader file = new StreamReader(archivo);

            while ((line = file.ReadLine()) != null)
            {
                retorno = line;
                aray = retorno.Split(',');

                if (aray[9] == "Pendiente")
                {
                    arrText.Add(retorno);
                }
            }
            foreach(string val in arrText)
            {
                Console.WriteLine(val);
            }
            file.Close();

            return arrText;
        }




        public LinkedList<string[]> leerA(String archivo)
        {
           // Console.WriteLine("estoy leyendooo");
            LinkedList<string[]> arrText = new LinkedList<string[]>();

            string line;
            string retorno = "";
            string[] aray;
            StreamReader file = new StreamReader(archivo);

            while ((line = file.ReadLine()) != null)
            {
                retorno = line;
                Console.WriteLine(retorno);
                aray = retorno.Split(',');
               
              /* if (aray[8] == "Pendiente")
                {
                    arrText.AddLast(aray);
                }*/
            }

            file.Close();
            return arrText;
        }

        public LinkedList<string[]> ioArchivos(String archivo)
        {
            
            LinkedList<string[]> arrText = new LinkedList<string[]>();

            string line;
            string retorno = "";
            string[] aray;
            StreamReader file = new StreamReader(archivo);

            while ((line = file.ReadLine()) != null)
            {
                retorno = line;
                aray = retorno.Split(',');

               arrText.AddLast(aray);
                
            }

            file.Close();
            return arrText;
        }





        //este metodo solo escribe una nueva solicitud en el archivo Solicitud.txt
       public void escribirArchivo(String solicitud,String archivo)
        {
          
            StreamWriter file = File.AppendText(archivo);
            
            file.WriteLine(solicitud);
            file.Close();

        }


        //este metodo sirve para buscar en el archivo Solicitud.txt, con la id que se manda desde la tabla de la vista,
        //y retorna toda l tupla la cual se va mandar a la funcion autorizar() de la autorización
        public string[] busqueda(string id)
        {
            StreamReader lectura;
            bool encontrado = false;
            string cadena = "";
            string[] campos = new string[10];
          
            try
            {
                lectura = File.OpenText("Viaje.txt");
               
                while ((cadena=lectura.ReadLine()) != null && encontrado==false)
                {
                    campos = cadena.Split(',');
                    if (campos[0].Equals(id))
                    {

                        encontrado = true;
                    }
                }

            lectura.Close();

            }catch(FileNotFoundException e)
            {
                MessageBox.Show("Error, no hay el archivo.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
            

            return campos;
        }


        

    }


    

}
