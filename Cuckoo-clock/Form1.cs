using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cuckoo_clock
{
    public partial class Form1 : Form
    {
        private Graphics gr;
        private Pen myPenSeconds;
        private Pen myPenMinute;
        private Pen myPenHour;
        private float xSec;
        private float ySec;
        private float xMin;
        private float yMin;
        private float xHour;
        private float yHour;
        int secondNow = DateTime.Now.Second;
        int minuteNow = DateTime.Now.Minute;
        int hourNow = DateTime.Now.Hour;
        double angleSeconds;
        double angleSecondsStatic;
        double angleMinute;
        double angleHour;
        Timer secondNows = new Timer();

        public Form1()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();

            if(hourNow > 12)
            {
                hourNow = hourNow - 12;
            }

            double angleNow = 0.104 * secondNow;
            angleSeconds = Math.PI * 1.5 + (angleNow + 0.104);
            angleSecondsStatic = angleSeconds;

            double angleMinNow = 0.104 * minuteNow;
            angleMinute = Math.PI * 1.5 + angleMinNow;

            double angleHourNow = 0.52 * hourNow;
            angleHour = Math.PI * 1.5 + angleHourNow;

            myPenSeconds = new Pen(Brushes.Black, 1);
            myPenMinute = new Pen(Brushes.Black, 2);
            myPenHour = new Pen(Brushes.Black, 4);

            secondNows.Interval = 1000;
            secondNows.Tick += new EventHandler(this.secondNowTimer);
            secondNows.Start();
            
        }

        public void secondNowTimer(object sender, EventArgs e)
        {
            gr.Clear(Color.Gainsboro);
            xSec = 120 * (float)Math.Cos(angleSeconds) + 180;
            ySec = 120 * (float)Math.Sin(angleSeconds) + 130;
            angleSeconds += 0.104;

            xMin = 100 * (float)Math.Cos(angleMinute) + 180;
            yMin = 100 * (float)Math.Sin(angleMinute) + 130;

            xHour = 70 * (float)Math.Cos(angleHour) + 180;
            yHour = 70 * (float)Math.Sin(angleHour) + 130;

            if (angleSeconds > 10.995)
            {
                angleSeconds = Math.PI * 1.5;
                angleMinute += 0.104;
            }

            if(angleMinute > 10.995)
            {
                angleMinute = Math.PI * 1.5;
                angleHour += 0.52;
                for(int i=0; i < hourNow; i++)
                {
                    label3.Text = label3.Text + "КАР";
                }
            }

            gr.DrawLine(myPenSeconds, 180, 130, xSec, ySec);
            gr.DrawLine(myPenMinute, 180, 130, xMin, yMin);
            gr.DrawLine(myPenMinute, 180, 130, xHour, yHour);

            Console.WriteLine(angleSeconds);
            Console.WriteLine(angleMinute);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
