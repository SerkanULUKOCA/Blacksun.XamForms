using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Sockets.Models
{
    public class CustomMessage
    {

        public CustomMessage()
        {
            hola = "Hola soy un mensaje lorem ipsum";
            R = "255";
            G = "0";
            B = "0";
            A = "0";

        }

        public string hola { get; set; }

        public string R { get; set; }

        public string G { get; set; }

        public string B { get; set; }

        public string A { get; set; }

    }
}
