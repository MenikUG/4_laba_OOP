using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_laba_OOP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        class circle
        {
            public int x, y; // Координаты круга
            public int rad = 15; // Радиус круга
            public circle()
            {
                x = 0;
                y = 0;
            }
            public circle(int x, int y)
            {
                this.x = x-rad;
                this.y = y-rad;
            }

        }


        private void paint_box_MouseMove(object sender, MouseEventArgs e)
        {
            label_x.Text = "Координаты X: " + e.X.ToString();
            label_y.Text = "Координаты Y: " + e.Y.ToString();
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            label_x.Text = "";
            label_y.Text = "";
        }

        private void paint_box_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3); // Объявляем объект - карандаш, которым будем рисовать контур
            circle krug = new circle(e.X, e.Y);
            paint_box.CreateGraphics().DrawEllipse(pen, krug.x, krug.y, krug.rad * 2, krug.rad * 2);
            label_paintbox.Visible = false;
            
        }

        private void button_clear_paintbox_Click(object sender, EventArgs e)
        {
            paint_box.Invalidate();
            label_paintbox.Visible = true;
        }
    }

    }

