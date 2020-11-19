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

        class Circle
        {
            public int x, y; // Координаты круга
            public int rad = 15; // Радиус круга
            public Circle()
            {
                x = 0;
                y = 0;
            }
            public Circle(int x, int y)
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

        static int k = 5; // Кол-во ячеек в хранилище
        Storage storag = new Storage(k); // Создаем объект хранилища
        int index = 0;
        private void paint_box_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3); // Объявляем объект - карандаш, которым будем рисовать контур
            Circle krug = new Circle(e.X, e.Y);
            if (index == k)
                storag.doubleSize(ref k);
            storag.add_object(index, ref krug);
            paint_box.CreateGraphics().DrawEllipse(pen, krug.x, krug.y, krug.rad * 2, krug.rad * 2); // По заданным координатам рисуем круг
            label_paintbox.Visible = false;
            ++index;
        }

        private void button_clear_paintbox_Click(object sender, EventArgs e)
        {
            paint_box.Invalidate();
            label_paintbox.Visible = true;
        }

        class Storage
        {
            public Circle[] objects;

            public Storage(int count)
            {
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void initialisat(int count)
            {
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }

            public void add_object(int index, ref Circle object1)
            {
                objects[index] = object1;
            }

            public void delete_object(int index)
            {
                objects[index] = null;
            }

            public bool check_empty(int index)
            {
                if (objects[index] == null)
                    return true;
                else return false;
            }

            public int occupied(int size)
            {
                int count_occupied = 0;
                for (int i = 0; i < size; ++i)
                    if (!check_empty(i))
                        ++count_occupied;
                return count_occupied;
            }

            public void doubleSize(ref int size)
            {   // Функция для увеличения кол-ва элементов в хранилище в 2 раза 
                Storage storage1 = new Storage(size * 2);
                for (int i = 0; i < size; ++i)
                    storage1.objects[i] = objects[i];
                for (int i = size; i < (size * 2) - 1; ++i)
                {
                    storage1.objects[i] = null;
                }
                size = size * 2;
                initialisat(size);
                for (int i = 0; i < size; ++i)
                    objects[i] = storage1.objects[i];
            }

            //public void doubleSize(ref Storage storage, ref int size)
            //{   // Функция для увеличения кол-ва элементов в хранилище в 2 раза 
            //    Storage storage1 = new Storage(size * 2);
            //    for (int i = 0; i < size; ++i)
            //        storage1.objects[i] = storage.objects[i];
            //    for (int i = size; i < (size * 2) - 1; ++i)
            //    {
            //        storage1.objects[i] = null;
            //    }
            //    size = size * 2;
            //    storage.initialisat(size);
            //    for (int i = 0; i < size; ++i)
            //        storage.objects[i] = storage1.objects[i];
            //}

            ~Storage() { }
        };

        private void button_show_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3); // Объявляем объект - карандаш, которым будем рисовать контур
            label_paintbox.Visible = false;
            for (int i = 0; i < index; ++i)
            {
                paint_box.CreateGraphics().DrawEllipse(pen, storag.objects[i].x, storag.objects[i].y, storag.objects[i].rad * 2, storag.objects[i].rad * 2);
            }
        }
    }

}

