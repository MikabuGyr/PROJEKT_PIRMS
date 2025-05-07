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
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics;

namespace Projekt_pirms
{
    public partial class Form1: Form
    {
        private List<double> buffer = new List<double>();
        private const int SampleSize = 1024;
        public Form1()
        {
            InitializeComponent();
            serialPort1.BaudRate = 115200;
            serialPort1.PortName = "COM3";  // uprav dle potřeby
            serialPort1.DataReceived += SerialPort1_DataReceived;

        }

        private void button1_Click(object sender, EventArgs e) //tlačítko pro start
        {
            buffer.Clear();
            serialPort1.Open();
            timer1.Start();
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                string line = serialPort1.ReadLine();
                if (double.TryParse(line, out double value))
                {
                    if (buffer.Count < SampleSize)
                        buffer.Add(value);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer.Count >= SampleSize)
            {
                double[] data = buffer.ToArray();
                buffer.Clear();

                // Odstranění DC složky
                double mean = 0;
                foreach (var d in data) mean += d;
                mean /= data.Length;
                for (int i = 0; i < data.Length; i++) data[i] -= mean;

                // FFT
                Complex[] fftData = new Complex[SampleSize];
                for (int i = 0; i < SampleSize; i++)
                    fftData[i] = new Complex(data[i], 0);

                Fourier.Forward(fftData, FourierOptions.Matlab);

                // Spektrum (modul)
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < SampleSize / 2; i++)
                {
                    double magnitude = fftData[i].Magnitude;
                    chart1.Series[0].Points.AddXY(i, magnitude);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
