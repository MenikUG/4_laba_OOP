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
            public Color color = Color.Navy;
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

            ~Circle() { }
        }


        private void paint_box_MouseMove(object sender, MouseEventArgs e)
        {
            label_x.Text = "Координаты X: " + e.X.ToString();
            label_y.Text = "Координаты Y: " + e.Y.ToString();
        }

        private void paint_circle(Color name, ref Storage stg, int index)
        {   // Рисует круг на панели            
            Pen pen = new Pen(name, 3); 
            // Объявляем объект - карандаш, которым будем рисовать контур
            paint_box.CreateGraphics().DrawEllipse(pen, stg.objects[index].x, 
                stg.objects[index].y, stg.objects[index].rad * 2,
                stg.objects[index].rad * 2);
            stg.objects[index].color = name;
        }

        private void remove_selection_circle(ref Storage stg)
        {   // Снимает выделение у всех элементов хранилища
            for (int i = 0; i < k; ++i)
            {
                if (!storag.check_empty(i))
                {   // Вызываем функцию отрисовки круга
                    paint_circle(Color.Navy, ref storag, i);
                }
            }
        }
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            label_x.Text = "";
            label_y.Text = "";
        }

        static int k = 20; // Кол-во ячеек в хранилище
        Storage storag = new Storage(k); // Создаем объект хранилища
        int index = 0; // Индекс в хранилище
        private void paint_box_MouseClick(object sender, MouseEventArgs e)
        {
            Circle krug = new Circle(e.X, e.Y);
            if (index == k)
                storag.doubleSize(ref k);
            int c = check_circle(ref storag, k, krug.x, krug.y); // Выбранный элемент
            if (c != -1)
            {   // Если на этом месте уже нарисован круг
                if (Control.ModifierKeys == Keys.Control)  
                {   // Если нажат ctrl, то выделяем выделяем несколько объектов
                    paint_circle(Color.Navy, ref storag, index-1);
                    paint_circle(Color.Red, ref storag, c); // Вызываем функцию отрисовки круга

                }
                else
                {   // Иначе выделяем только один объект
                    remove_selection_circle(ref storag); // Снимаем выделение у всех объектов хранилища
                    paint_circle(Color.Red, ref storag, c); // Вызываем функцию отрисовки круга
                }
                return;
            }
            storag.add_object(index, ref krug, k); // Добавляем круг в хранилище          
            remove_selection_circle(ref storag); // Снимаем выделение у всех объектов хранилища
            paint_circle(Color.Red, ref storag, index); // Вызываем функцию отрисовки круга
            label_paintbox.Visible = false;
            ++index;
        }

        private int check_circle(ref Storage stg, int size, int x, int y)
        {   // Проверяет есть ли уже круг с такими же координатами в хранилище
            if (stg.occupied(size) != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    if (!stg.check_empty(i))
                    {
                        int x1 = stg.objects[i].x - 15;
                        int x2 = stg.objects[i].x + 15;
                        int y1 = stg.objects[i].y - 15;
                        int y2 = stg.objects[i].y + 15;

                        if ((x1 <= x && x <= x2) && (y1 <= y && y <= y2)) // Если круг есть, возвращет индекс круга в хранилище
                            return i;
                    }
                }
            }
            return -1;
        }

        private void button_clear_paintbox_Click(object sender, EventArgs e)
        {   // Очищает панель от кругов
            paint_box.Invalidate(); // Перерисовывем панель paint_box
            label_paintbox.Visible = true;
        }

        class Storage
        {
            public Circle[] objects;

            public Storage(int count)
            {   // Конструктор по умолчанию 
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }
            public void initialisat(int count)
            {   // Выделяем count мест в хранилище
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }

            public void add_object(int index, ref Circle object1, int count)
            {   // Добавляет ячейку в хранилище
                if (check_empty(index)) // Если ячейка пуста, добавляет объект
                    objects[index] = object1;
                else
                {   // Иначе ищет свободное место
                    while (objects[index] != null)
                    {
                        index = (index + 1) % count;
                    }
                    objects[index] = object1;
                }
            }

            public void delete_object(ref int index)
            {   // Удаляет объект из хранилища
                objects[index] = null;
                index--;
            }

            public bool check_empty(int index)
            {   // Проверяет занято ли место хранилище
                if (objects[index] == null)
                    return true;
                else return false;
            }

            public int occupied(int size)
            { // Определяет кол-во занятых мест в хранилище
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

            ~Storage() { }
        };

        private void button_show_Click(object sender, EventArgs e)
        {   // Отобразить все круги из хранилища
            if (storag.occupied(k) != 0)
            {
                label_paintbox.Visible = false;
                for (int i = 0; i < index; ++i)
                {
                    paint_circle(Color.Navy, ref storag, i);                    
                }
            }
        }

        private void button_deletestorage_Click(object sender, EventArgs e)
        {   // Удалить все круги из хранилища
           // storag.delete_object(i);
            for (int i = 0; i < index; ++i)
            {
                storag.objects[i] = null;
            }
            index = 0;
        }
    }

}

