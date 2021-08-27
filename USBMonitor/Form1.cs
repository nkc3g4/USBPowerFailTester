using iTuner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBMonitor
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            GetUdiskList.LoadUDList(comboBoxUd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(buttonOpen.Text == "Close")
            {
                if (serialPort != null)
                    serialPort.Close();
                buttonOpen.Text = "Open";
                return;
            }
            serialPort = new SerialPort(comboBoxPorts.SelectedItem.ToString(), 115200);
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            else
            {
                MessageBox.Show("Port Open Fail");
                return;
            }
            buttonOpen.Text = "Close";
            textBox1.AppendText("Open Port Successful: "+ serialPort.PortName + Environment.NewLine);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                textBox1.AppendText("Port not open!" + Environment.NewLine);
                return;
            }
            Model.sc = new SerialController(serialPort);
            UsbDisk usbDisk = (UsbDisk)comboBoxUd.SelectedItem;
            Task task = new Task(new Action(() => {
                Console.WriteLine("In task");
                try
                {
                    Tester tester = new Tester(usbDisk, textBox1);
                    if (checkBoxWrite.Checked)
                    {
                        tester.BeginTest2();
                    }
                    else { 
                        tester.BeginTest1(); 
                    }
                }
                catch(Exception ex)
                {
                    textBox1.Invoke(new Action(() => { textBox1.AppendText(ex.ToString()); }));
                }

            }));

            task.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort.Write("ON");
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            serialPort.Write("OF");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            comboBoxPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
        }
        
    }
}
