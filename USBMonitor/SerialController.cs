using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBMonitor
{
    public class SerialController
    {
        private SerialPort serialPort { get; set; }
        public SerialController(SerialPort serialPort)
        {
            this.serialPort = serialPort;
        }
        public void On()
        {
            serialPort.Write("ON");
        }
        public void Off()
        {
            serialPort.Write("OF");
        }
    }
}
