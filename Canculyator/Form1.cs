using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canculyator
{
    public partial class Form1 : Form
    {
        private float Markaz_X = 482.0f;
        private float Markaz_Y = 216.0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Check(mk1.Text,mk2.Text,mk3.Text,mk4.Text))
            {
                float A, B, C, Determinant;
                float k;
                A = Convert.ToSingle(mk1.Text);
                B = Convert.ToSingle(mk2.Text);
                C = Convert.ToSingle(mk3.Text);
                k = Convert.ToSingle(mk4.Text);
                Determinant = B * B - 4 * A * C;
                if(Determinant < 0)
                {
                    deter.Text = "berilgan funksiya ildizlarga ega emas";
                }
                else
                {
                    double x1, x2;
                    x1 = (-B + Math.Sqrt(Determinant)) / (2 * A);
                    x2 = (-B - Math.Sqrt(Determinant)) / (2 * A);
                    X1.Text = x1.ToString();
                    X2.Text = x2.ToString();
                }
                DrawFunction(A, B, C, k);
            }
            else
            {
                deter.Text = "input qiymatlaridan biri null qiymatga ega";
            }
        }
        private bool Check(params string[] Text)
        {
            foreach (var text in Text)
                if (text == string.Empty)
                    return false;
            return true;
        }
        private void DrawFunction(float A,float B,float C,float k)
        {
            Pen pen = new Pen(Color.Black, 0.1f);
            Graphics graphics = this.CreateGraphics();
            for (float i = -200f; i < 200f; i +=2 * k)
            {
                DrawLine(i, A * i * i + B * i + C, i + k, A * (i + k) * (i + k) + B * (i + k) + C, k);
            }

        }
        private void DrawLine(float x1 ,float y1,float x2,float y2,float k)
        {
            Pen pen = new Pen(Color.Black, 0.1f);
            Graphics graphics = this.CreateGraphics();
            graphics.DrawLine(pen, x1 + Markaz_X,(-1) * y1 + Markaz_Y, x2 + Markaz_X, (-1) * y2 + Markaz_Y);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 0.1f);
            e.Graphics.DrawLine(pen, Markaz_X, 0, Markaz_X, 2 * Markaz_Y);
            e.Graphics.DrawLine(pen, 0, Markaz_Y, 2 * Markaz_X, Markaz_Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
            deter.Text = "";
            X1.Text = "";
            X2.Text = "";
            Pen pen = new Pen(Color.Black, 0.1f);
            graphics.DrawLine(pen, Markaz_X, 0, Markaz_X, 2 * Markaz_Y);
            graphics.DrawLine(pen, 0, Markaz_Y, 2 * Markaz_X, Markaz_Y);
        }
    }
}
