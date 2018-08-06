using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace WindowsFormsApplication1
{
    class Correo
    {

        public void enviarCorreoNotificacion(String correoDestinatario, String asunto,String cuerpoMensaje)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //a quien va dirigido
           
            msg.To.Add(correoDestinatario);
            msg.To.Add("andresbalcazar2020@gmail.com");
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            
            //una copia a alguien adicional que deba recibir el correo
            //msg.Bcc.Add("andresbalcazar2020@gmail.com");

            msg.Body = cuerpoMensaje;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //quien está enviando el correo
            msg.From = new System.Net.Mail.MailAddress("transporteepn@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //las credenciales de quien envia y se coloca el password
            cliente.Credentials = new System.Net.NetworkCredential("transporteepn@gmail.com", "EPN123456");
            //a gmail

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com"; //mail.dominio.com
            try
            {
                cliente.Send(msg);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }

        internal void enviarCorreoNotificacion()
        {
            throw new NotImplementedException();
        }
    }
}
