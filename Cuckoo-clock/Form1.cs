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
        private Pen myPen;
        private float x;
        private float y;
        int secondNow = DateTime.Now.Second;
        double angleSeconds;
        Timer secondNows = new Timer();

        public Form1()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();
            angleSeconds = Math.PI * 1.5;
            myPen = new Pen(Brushes.Black, 3);

            secondNows.Interval = 1000;
            secondNows.Tick += new EventHandler(this.secondNowTimer);
            secondNows.Start();
            
        }

        public void secondNowTimer(object sender, EventArgs e)
        {
            gr.Clear(Color.Gainsboro);
            

            x = 90 * (float)Math.Cos(angleSeconds) + 180;
            y = 90 * (float)Math.Sin(angleSeconds) + 130;

            angleSeconds += 0.104;
            gr.DrawLine(myPen, 180, 130, x, y);

            Console.WriteLine("Рисуй сука");
        }

        private void timeSecondNow(object sender,
       System.Windows.Forms.PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 10);
            
            int Xposition = (int)(90 * Math.Sin(angleSeconds) + 292);
            int Yposition = (int)(90 * Math.Cos(angleSeconds) + 281);
            g.DrawLine(myPen, 292, 281, 400, 400);
            angleSeconds = angleSeconds + 0.104;

            Console.WriteLine(secondNow);
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
