using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.IntegralTransforms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private List<double> sampleBuffer = new List<double>();
        private const int FFT_SIZE = 1024;
        private const int MAX_SAMPLE = 255; // 8bitová data
        private const int SAMPLE_RATE = 8000;

        public Form1()
        {
            InitializeComponent();
            comboBaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            comboBaudRate.SelectedItem = "115200";

            comboComPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboComPort.Items.Count > 0)
                comboComPort.SelectedIndex = 0;

            chartFFT.Series[0].Points.Clear();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string portName = comboComPort.SelectedItem?.ToString();
            int baudRate = int.Parse(comboBaudRate.SelectedItem.ToString());

            serialPort = new SerialPort(portName, baudRate);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.ReadBufferSize = 4096;
            serialPort.ReceivedBytesThreshold = 1;

            try
            {
                serialPort.Open();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                lblStatus.Text = $"Čtení z {portName} @ {baudRate}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při otevírání portu: " + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort?.Close();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                lblStatus.Text = "Odpojeno";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při zavírání portu: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                lock (sampleBuffer)
                {
                    foreach (byte b in buffer)
                    {
                        double normalized = b / (double)MAX_SAMPLE;
                        sampleBuffer.Add(normalized);
                    }

                    while (sampleBuffer.Count >= FFT_SIZE)
                    {
                        var data = sampleBuffer.Take(FFT_SIZE).ToArray();
                        sampleBuffer.RemoveRange(0, FFT_SIZE);

                        Task.Run(() => ComputeAndDisplayFFT(data));
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    lblStatus.Text = $"Chyba při čtení: {ex.Message}";
                }));
            }
        }

        private void ComputeAndDisplayFFT(double[] samples)
        {
            Complex[] fftInput = samples.Select(v => new Complex(v, 0)).ToArray();
            Fourier.Forward(fftInput, FourierOptions.Matlab);

            double[] magnitudes = fftInput
                .Take(FFT_SIZE / 2)
                .Select(c => c.Magnitude)
                .ToArray();

            double[] freqs = Enumerable.Range(0, FFT_SIZE / 2)
                .Select(i => i * SAMPLE_RATE / (double)FFT_SIZE)
                .ToArray();

            Invoke(new Action(() =>
            {
                chartFFT.Series[0].Points.Clear();
                for (int i = 0; i < freqs.Length; i++)
                {
                    chartFFT.Series[0].Points.AddXY(freqs[i], magnitudes[i]);
                }
            }));
        }
    }
}
