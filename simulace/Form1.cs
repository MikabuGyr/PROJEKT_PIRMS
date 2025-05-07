using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SoundSimulatorGUI
{
    public partial class Form1 : Form
    {
        private Thread workerThread;
        private volatile bool running = false;
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            comboBaudRate.SelectedItem = "115200";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (running)
                return;

            // Získání hodnot z UI
            string comPort = txtComPort.Text;
            double[] frequencies = {
                double.Parse(txtFreq1.Text),
                double.Parse(txtFreq2.Text),
                double.Parse(txtFreq3.Text)
            };
            double[] amplitudes = {
                double.Parse(txtAmp1.Text),
                double.Parse(txtAmp2.Text),
                double.Parse(txtAmp3.Text)
            };
            double noiseLevel = double.Parse(txtNoise.Text);

            int baudRate;
            if (!int.TryParse(comboBaudRate.SelectedItem?.ToString(), out baudRate))
            {
                MessageBox.Show("Zvolte platný baud rate.");
                return;
            }

            // Otevření sériového portu
            try
            {
                serialPort = new SerialPort(comPort, baudRate);
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při otevírání COM portu: " + ex.Message);
                return;
            }

            running = true;
            lblStatus.Text = "Běží…";

            // Spuštění generování ve vlákně
            workerThread = new Thread(() =>
            {
                const int sampleRate = 8000;
                const int resolution = 255; // 8bitové rozlišení
                Stopwatch sw = new Stopwatch();
                sw.Start();
                long ticksPerSample = Stopwatch.Frequency / sampleRate;
                long nextTick = sw.ElapsedTicks;
                int sampleNum = 0;
                Random rnd = new Random();

                while (running)
                {
                    if (sw.ElapsedTicks >= nextTick)
                    {
                        double t = (double)sampleNum / sampleRate;
                        double value = 0.0;

                        for (int i = 0; i < 3; i++)
                            value += amplitudes[i] * Math.Sin(2 * Math.PI * frequencies[i] * t);

                        value += (rnd.NextDouble() - 0.5) * 2 * noiseLevel; // Šum ±noiseLevel

                        value = (value + 2) / 4.0; // Normalizace do 0–1
                        value = Math.Max(0.0, Math.Min(1.0, value));
                        byte sample = (byte)(value * resolution);

                        try
                        {
                            serialPort.Write(new byte[] { sample }, 0, 1); // binární zápis jednoho bajtu
                        }
                        catch
                        {
                            break;
                        }

                        sampleNum++;
                        nextTick += ticksPerSample;
                    }
                    else
                    {
                        Thread.Sleep(0); // čekání
                    }
                }

                try { serialPort.Close(); } catch { }
                Invoke(new Action(() => lblStatus.Text = "Zastaveno"));
            });

            workerThread.IsBackground = true;
            workerThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            running = false;
        }
    }
}
