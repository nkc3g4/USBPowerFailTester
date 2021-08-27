using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTuner;
using Microsoft.Win32.SafeHandles;

namespace USBMonitor
{
    /// <summary>
    /// Procedure:
    /// initial: SEQ write file, calc MD5 (File size 10s)
    /// 1. Turn on, read file MD5, compare
    /// 2. write new file, turn off
    /// 3. repeat
    /// </summary>
    class Tester
    {
        private string Path { get; set; }
        private TextBox textBox { get; set; }
        private long dataLength = 536866816L;
        private static uint FILE_FLAG_NO_BUFFERING = 536870912u;
        private static uint FILE_FLAG_WRITE_THROUGH = 2147483648u;
        private static uint file_flags = FILE_FLAG_NO_BUFFERING | FILE_FLAG_WRITE_THROUGH;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public Tester(UsbDisk usbDisk, TextBox textBox)
        {
            Path = usbDisk.Volume.Substring(0, 2)+"\\";
            this.textBox = textBox;
        }
        public void BeginTest2()
        {
            string testFilePath = Path + "test_orig.bin";

            Model.sc.On();
            
            WriteSeq(testFilePath, DiskOperation.GetHardDiskFreeSpace(Path)*5 / 4,0);
            string md5 = GetMD5HashFromFile(testFilePath);
            textBox.Invoke(new Action(() => {
                textBox.AppendText("Orig File Created with MD5: "+md5 + Environment.NewLine);
            }));
            for (int i = 1; i <= 1000; i++)
            {
                while (!File.Exists(testFilePath))
                {
                    Thread.Sleep(1000);
                }
                string newMD5 = GetMD5HashFromFile(testFilePath);
                textBox.Invoke(new Action(() => {
                    textBox.AppendText("MD5:" + newMD5.ToString() + Environment.NewLine);
                }));

                if (newMD5 != md5)
                {
                    textBox.Invoke(new Action(() => {
                        textBox.AppendText("Error! MD5 mismatch!" + Environment.NewLine);
                    }));
                    break;
                }
                textBox.Invoke(new Action(() => {
                    textBox.AppendText("Loop " + i.ToString() + " OK!" + Environment.NewLine + Environment.NewLine);
                }));


                Task writeTask = new Task(new Action(() => {
                    WriteSeq(Path+"temp.bin", 10737418240, 10 * 1000);
                }));
                writeTask.Start();
                Thread.Sleep(2000);
                Model.sc.Off();
                Thread.Sleep(3000);
                Model.sc.On();
                Thread.Sleep(5000);

            }
        }
        public void BeginTest1()
        {
            string testFilePath = Path + "test.bin";
            
            Model.sc.On();

            WriteSeq(testFilePath, 10737418240, 10 * 1000);
            string md5 = GetMD5HashFromFile(testFilePath);
            textBox.Invoke(new Action(() => {
                textBox.AppendText("File Created"+Environment.NewLine);
            }));
            for (int i = 1; i <= 1000; i++)
            {
                
                
                Thread.Sleep(2000);
                Model.sc.Off();
                Thread.Sleep(3000);
                Model.sc.On();
                Thread.Sleep(5000);

                string newMD5 = GetMD5HashFromFile(testFilePath);
                textBox.Invoke(new Action(() => {
                    textBox.AppendText("MD5:"+newMD5.ToString() + Environment.NewLine);
                }));

                if (newMD5 != md5)
                {
                    textBox.Invoke(new Action(() => {
                        textBox.AppendText("Error! MD5 mismatch!" + Environment.NewLine);
                    }));
                    break;
                }
                textBox.Invoke(new Action(() => {
                    textBox.AppendText("Loop "+i.ToString()+" OK!" + Environment.NewLine);
                }));

                WriteSeq(testFilePath, 10737418240,10*1000);
                md5 = GetMD5HashFromFile(testFilePath);

            }

        }
        private void GenerateRandomArray(byte[] rnd_array)
        {
            Random random = new Random();
            for (int i = 0; i < rnd_array.Length; i++)
            {
                rnd_array[i] = (byte)random.Next(255);
            }
        }
        private double WriteSeq(string path,long totalLength,long testDuration)
        {


            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            SafeFileHandle safeFileHandle = CreateFile(path, FileAccess.ReadWrite, FileShare.None, IntPtr.Zero, FileMode.OpenOrCreate, file_flags, IntPtr.Zero);

            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.ReadWrite, 4096, false);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int seqSize = 67108864;
            byte[] seqBuffer = new byte[seqSize];
            GenerateRandomArray(seqBuffer);
            List<double> seqPoints = new List<double>();
            
            for (dataLength = 0L; dataLength < totalLength; dataLength += seqSize)
            {

                fileStream.Position = dataLength;

                long preTime = sw.ElapsedMilliseconds;
                fileStream.Write(seqBuffer, 0, seqSize);
                fileStream.Flush();
                long curTime = sw.ElapsedMilliseconds;
                seqPoints.Add((seqSize / (1024.0 * 1024)) / ((curTime - preTime) / 1000.0));
                if (testDuration !=0 && sw.ElapsedMilliseconds > testDuration)
                    break;
            }
            sw.Stop();
            fileStream.Close();
            return seqPoints.Average();
        }
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
