using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface Estado
    {
        void notificarEstado(string correoDestinatario,string asunto,string solicitud);
    }
}
