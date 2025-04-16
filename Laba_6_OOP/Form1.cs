using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Laba_6_OOP;
using System.Runtime.CompilerServices;

namespace Laba_6_OOP
{
    public partial class Form1 : Form
    {
        // Объект класса Folder для хранения фигур
        Folder folder_1 = new Folder(0);

        public Form1()
        {
            InitializeComponent();
        }
        bool ctrl = false; // Флаг для отслеживания нажатия клавиши Ctrl
        // Обработчик события отпускания клавиши
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.ControlKey)// Если отпущена клавиша Ctrl
                ctrl = false;// Сбрасываем флаг
        }
        // Обработчик события нажатия клавиши
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.ControlKey)// Если нажата клавиша Ctrl
                ctrl = true;// Устанавливаем флаг

            // Перемещение активных фигур с помощью клавиш A, D, W, S
            if (e.KeyValue == (char)Keys.A)// Клавиша A - движение влево
            {
                folder_1.moveLeft(-15,0);// Перемещение фигуры влево
                folder_1.paint(pictureBox1);// Перерисовка PictureBox
            }

            if(e.KeyValue == (char)Keys.D)// Клавиша D - движение вправо
            {
                folder_1.moveRight(15,0);// Перемещение фигуры вправо
                folder_1.paint(pictureBox1);// Перерисовка PictureBox
            }

            if(e.KeyValue == (char)Keys.W)// Клавиша W - движение вверх
            {
                folder_1.moveTop(0,-15);// Перемещение фигуры вверх
                folder_1.paint(pictureBox1);// Перерисовка PictureBox
            }

            if(e.KeyValue == (char)Keys.S)// Клавиша S - движение вниз
            {
                folder_1.moveBottom(0,15);// Перемещение фигуры вниз
                folder_1.paint(pictureBox1);// Перерисовка PictureBox
            }

            // Удаление активных фигур при нажатии клавиши Delete
            if (e.KeyValue == (char)Keys.Delete)
            {
                folder_1.del_active();// Удаление активных фигур
                folder_1.paint(pictureBox1);// Перерисовка PictureBox
            }
        }
        // Обработчик события клика мыши на PictureBox
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;// Убираем фокус с активного элемента 
            if (ctrl != true)// Если Ctrl не нажат
                folder_1.deact_all();// Деактивируем все фигуры
            folder_1.probeg(e.X, e.Y);// Проверяем, была ли выбрана фигура
            folder_1.paint(pictureBox1);// Перерисовываем PictureBox
        }
        // Обработчик события изменения цвета через диалоговое окно
        private void change_color_button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)// Если пользователь выбрал цвет
            {
                Color color = colorDialog1.Color;// Получаем выбранный цвет
                folder_1.changecolor(color);// Меняем цвет активных фигур
                this.ActiveControl = null;// Убираем фокус с активного элемента
                folder_1.paint(pictureBox1);// Перерисовываем PictureBox
            }
        }
        // Обработчик события перерисовки PictureBox
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            folder_1.paint(pictureBox1);// Вызываем метод перерисовки фигур
        }
        // Обработчик движения мыши по PictureBox
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();// Отображаем координаты X курсора
            label2.Text = e.Y.ToString();// Отображаем координаты Y курсора
            folder_1.picturebox1 = pictureBox1;// Присваиваем PictureBox объекту Folder
        }
        // Обработчики событий для кнопок создания фигур
        private void Button_Circle_Click(object sender, EventArgs e)
        {
            folder_1.flag_circle = true;// Включаем режим создания кругов
            folder_1.flag_square = false;// Отключаем режим создания квадратов
            folder_1.flag_triangle = false;// Отключаем режим создания треугольников
        }
        private void Button_Square_Click(object sender, EventArgs e)
        {
            folder_1.flag_circle = false;// Отключаем режим создания кругов
            folder_1.flag_square = true;// Включаем режим создания квадратов
            folder_1.flag_triangle = false;// Отключаем режим создания треугольников
        }
        private void Button_Rectangular_Click_1(object sender, EventArgs e)
        {
            folder_1.flag_circle = false;// Отключаем режим создания кругов
            folder_1.flag_square = false;// Отключаем режим создания квадратов
            folder_1.flag_triangle = true;// Включаем режим создания треугольников
        }

        int size;// Переменная для хранения размера фигуры
        // Обработчик события ввода размера фигуры
        private void resize_box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)// Если нажата клавиша Enter
            {
                size = Convert.ToInt32(resize_box.Text);// Получаем значение из текстового поля
                folder_1.resize(size);// Изменяем размер активных фигур
                this.ActiveControl = null;// Убираем фокус с активного элемента
                folder_1.paint(pictureBox1);// Перерисовываем PictureBox
            }
        }
    }
}
// Базовый класс для всех фигур
public class Object
{
    protected int x;// Координата X центра фигуры
    protected int y;// Координата Y центра фигуры
    protected Color color;// Цвет фигуры
    public PictureBox picturebox1;// Ссылка на PictureBox
    public bool active;// Флаг активности фигуры
    // Конструктор класса
    public Object(int x_1, int y_1, PictureBox pictureBox)
    {
        active = true;// По умолчанию фигура активна
        this.x = x_1;// Устанавливаем координату X
        this.y = y_1;// Устанавливаем координату Y
        this.color = Color.Black;// Устанавливаем черный цвет
        this.picturebox1 = pictureBox;// Присваиваем PictureBox
    }
    // Метод для управления активностью фигуры
    public void change_active()
    {
        this.active = !(this.active);// Поменять активность
    }
    // Метод для активации фигуры
    public void activate()
    {
        this.active = true;// Активировать
    }
    // Метод для деактивации фигуры
    public void deactivate()
    {
        this.active = false;// Деактивировать
    }
    // Метод для проверки активности фигуры
    public bool isActive()
    {
        return this.active;// Проверить активность
    }
    // Метод для изменения цвета фигуры
    public void changecolor(Color color)
    {
        this.color = color;
    }
    // Виртуальный метод для отрисовки фигуры
    public virtual void Paint(PictureBox picturebox1, Graphics g)
    {

    }
    // Виртуальный метод для проверки, была ли выбрана фигура
    public virtual bool Selected(int x, int y) 
    { 
        return false; 
    }
    // Виртуальный метод для изменения размера фигуры
    public virtual void resize(int new_size) 
    { 
    
    }
    // Виртуальный метод для перемещения фигуры
    public virtual void move(int x, int y) 
    { 
    
    }
    // Виртуальный метод для применения изменений
    protected virtual void changes_accepted(int dx,int dy,int new_size) 
    {

    }
    // Деструктор класса
    ~Object()
    {
        Console.Write("Деструктор класса object");
    }
}

// Класс кругов
class Circle : Object
{
    protected int radius;// Радиус круга
    // Конструктор класса
    public Circle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1,picturebox1)
    {
        this.radius = 100;// Устанавливаем начальный радиус
    }
    // Перекрытый метод для проверки, был ли выбран круг
    public override bool Selected(int x_1, int y_1)
    {
        // Проверяем, находится ли точка (x_1, y_1) внутри круга
        if ((Math.Pow((x_1 - this.x),2) + Math.Pow((y_1 - this.y),2)) < this.radius/2 * this.radius/2)
        {
            return true;// Точка находится внутри круга
        }
        else
        {
            return false;// Точка находится вне круга
        }
    }
    // Перекрытый метод для отрисовки круга
    public override void Paint(PictureBox picturebox1, Graphics g)
    {
        // Создаем перо для рисования с цветом фигуры и толщиной линии, зависящей от активности
        Pen blackPen = new Pen(this.color, active?3:1);
        // Определяем прямоугольник, в который будет вписан круг
        Rectangle rect = new Rectangle(this.x - (this.radius / 2), this.y - (this.radius / 2), this.radius, this.radius);
        g.DrawEllipse(blackPen, rect);// Рисуем круг, используя метод DrawEllipse
    }
    // Перекрытый метод для применения изменений (перемещение и изменение размера)
    protected override void changes_accepted(int dx,int dy,int new_size)
    {
        // Проверяем, не выходит ли круг за границы PictureBox при изменении размера
        if (((this.y + new_size/2) < picturebox1.Width)&&((this.y - new_size/2)>0)&&((this.x - new_size/2) > 0)&&((this.x + new_size/2) < picturebox1.Height))
          this.radius = new_size;// Обновляем радиус
        // Логика перемещения по оси Y
        if (dy > 0)
        {
            if((this.y + radius/2 + dy) < picturebox1.Height - dy)// Если круг не выходит за нижнюю границ
                this.y = this.y + dy;// Перемещаем вниз
        }
        else
        {
            if((this.y - radius/2 + dy) > 0) // Если круг не выходит за верхнюю границу
                this.y = this.y + dy; // Перемещаем вверх
        }
        // Логика перемещения по оси X
        if (dx < 0)
        {
            if((this.x - radius/2  + dx) > 0)// Если круг не выходит за левую границу
                this.x = this.x + dx;// Перемещаем влево
        }
        else
        {

            if((this.x + radius/2 + dx) < picturebox1.Width - dx)// Если круг не выходит за правую границу
                this.x = this.x + dx;// Перемещаем вправо
        }
    }
    // Перекрытый метод для изменения размера
    public override void resize(int new_size)
    {
        changes_accepted(0,0,new_size);// Вызываем метод изменения размера без перемещения
    }
    // Перекрытый метод для перемещения
    public override void move(int dx, int dy)
    {
        changes_accepted(dx,dy,this.radius);// Вызываем метод перемещения с текущим радиусом
    }

}
// Класс квадратов
class Square : Object
{
    protected int width; // Ширина квадрата
    // Конструктор класса
    public Square(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1,picturebox1)
    {
        this.width = 100;// Устанавливаем начальную ширину
    }
    // Перекрытый метод для проверки, был ли выбран квадрат
    public override bool Selected(int x_1, int y_1)
    {
        // Проверяем, находится ли точка (x_1, y_1) внутри квадрата
        if ((Math.Abs(x_1 - this.x) + Math.Abs(y_1 - this.y)) < this.width)
        {
            return true;// Точка находится внутри квадрата
        }
        else
        {
            return false;// Точка находится вне квадрата
        }
    }
    // Перекрытый метод для отрисовки квадрата
    public override void Paint(PictureBox picturebox1, Graphics g)
    {
        // Создаем перо для рисования с цветом фигуры и толщиной линии, зависящей от активности
        Pen blackPen = new Pen(this.color, active?3:1);
        // Определяем прямоугольник, в который будет вписан квадрат
        Rectangle rect = new Rectangle(this.x - (this.width/2), this.y - (this.width / 2), this.width, this.width);
        g.DrawRectangle(blackPen, rect);// Рисуем квадрат, используя метод DrawRectangle
    }
    // Перекрытый метод для применения изменений (перемещение и изменение размера)
    protected override void changes_accepted(int dx, int dy, int new_size)
    {
        // Проверяем границы PictureBox перед изменением размера и позиции
        if (((this.y + new_size/2) < 440)&&((this.y - new_size/2)>0)&&((this.x - new_size/2) > 0)&&((this.x + new_size/2) < 910))
                this.width = new_size;// Обновляем ширину
        // Логика перемещения по оси Y
        if (dy > 0)
        {
            if ((this.y + width / 2 + dy) < picturebox1.Height - dy)// Если квадрат не выходит за нижнюю границу
                this.y = this.y + dy;// Перемещаем вниз
        }
        else
        {
            if ((this.y - width / 2 + dy) > dy)// Если квадрат не выходит за верхнюю границу
                this.y = this.y + dy;// Перемещаем вверх
        }
        // Логика перемещения по оси X
        if (dx > 0)
        {
            if ((this.x + width / 2 + dx) < picturebox1.Width - dx)// Если квадрат не выходит за правую границу
                this.x = this.x + dx;// Перемещаем вправо
        }
        else
        {
            if ((this.x - width / 2 + dx) > dx)// Если квадрат не выходит за левую границу
                this.x = this.x + dx;// Перемещаем влево
        }
    }
    // Перекрытый метод для изменения размера
    public override void resize(int new_size)
    {
        changes_accepted(0,0,new_size);// Вызываем метод изменения размера без перемещения
    }
    // Перекрытый метод для перемещения
    public override void move(int dx, int dy)
    {
        changes_accepted(dx,dy,this.width);// Вызываем метод перемещения с текущей шириной
    }
}
// Класс треугольников
class Triangle : Object
{
    protected int dist_to_peak;// Расстояние от центра до вершин треугольника
    // Конструктор класса
    public Triangle(int x_1, int y_1, PictureBox picturebox1) : base(x_1, y_1,picturebox1)
    {
        this.dist_to_peak = 50;// Устанавливаем начальное расстояние до вершин
    }
    // Перекрытый метод для проверки, был ли выбран треугольник
    public override bool Selected(int x_1, int y_1)
    {
        // Проверяем, находится ли точка(x_1, y_1) внутри треугольника
        if ((Math.Pow((x_1 - this.x),2) + Math.Pow((y_1 - this.y),2)) < this.dist_to_peak/2 * this.dist_to_peak)
        {
            return true;// Точка находится внутри треугольника
        }
        else
        {
            return false;// Точка находится вне треугольника
        }
    }
    // Перекрытый метод для отрисовки треугольника
    public override void Paint(PictureBox picturebox1, Graphics g)
    {
        // Создаем перо для рисования с цветом фигуры и толщиной линии, зависящей от активности
        Pen blackPen = new Pen(this.color, active?3:1);
        // Определяем координаты трех вершин треугольника
        PointF point1 = new PointF(this.x,  this.y - this.dist_to_peak);// Верхняя вершина
        PointF point2 = new PointF(this.x + dist_to_peak,  this.y + this.dist_to_peak);// Правая нижняя вершина
        PointF point3 = new PointF(this.x - dist_to_peak,  this.y + this.dist_to_peak);// Левая нижняя вершина
        // Массив точек для рисования треугольника
        PointF[] curvePoints =
        {
            point1,
            point2,
            point3,
        };
        // Рисуем треугольник, используя метод DrawPolygon
        g.DrawPolygon(blackPen, curvePoints);

    }

    protected override void changes_accepted(int dx, int dy, int new_size)
    {
        // Проверяем, не выходит ли треугольник за границы PictureBox при изменении размера
        if (((this.y + new_size) < picturebox1.Width - 30)&&((this.y - new_size)>30)&&((this.x - new_size) > 30)&&((this.x + new_size) < picturebox1.Height - 30))
                this.dist_to_peak = new_size;
        // Логика перемещения по оси Y
        if (dy > 0)
        {
            if ((this.y + dist_to_peak + dy) < picturebox1.Height)// Если треугольник не выходит за нижнюю границу
                this.y = this.y + dy;// Перемещаем вни
        }
        else
        {
            if ((this.y - dist_to_peak  + dy) > 0)// Если треугольник не выходит за верхнюю границу
                this.y = this.y + dy;// Перемещаем вверх
        }
        // Логика перемещения по оси X
        if (dx > 0)
        {
            if ((this.x + dist_to_peak  + dx) < picturebox1.Width)// Если треугольник не выходит за правую границу
                this.x = this.x + dx;// Перемещаем вправо
        }
        else
        {
            if ((this.x - dist_to_peak  + dx) > 0)// Если треугольник не выходит за левую границу
                this.x = this.x + dx;// Перемещаем влево
        }

    }
    // Перекрытый метод для изменения размера треугольника
    public override void resize(int new_size)
    {
        changes_accepted(0,0,new_size);// Вызываем метод изменения размера без перемещения
    }
    // Перекрытый метод для перемещения треугольника
    public override void move(int dx, int dy)
    {
        changes_accepted(dx,dy,this.dist_to_peak);// Вызываем метод перемещения с текущим размером
    }
}
// Класс для управления хранилищем фигур
public class Folder
{
    public Object[] objects;// Массив для хранения фигур
    public int folder_size;// Размер массива
    public PictureBox picturebox1;// Ссылка на PictureBox
    public bool flag_circle;// Флаг для режима создания круга
    public bool flag_triangle;// Флаг для режима создания треугольника
    public bool flag_square;// Флаг для режима создания квадрата
    // Конструктор класса
    public Folder(int folder_sizee)
    {
        Console.Write("Конструктор по умолчанию класса folder");
        this.folder_size = folder_sizee;// Устанавливаем начальный размер массива
        this.objects = new Object[folder_sizee];// Инициализируем массив фигур

        flag_circle = false;// По умолчанию режим создания кругов выключен
        flag_square = false;// По умолчанию режим создания квадратов выключен
        flag_triangle = false;// По умолчанию режим создания треугольников выключен
        // Инициализируем все элементы массива как null
        for (int i = 0; i < folder_size; i++)
        {
            objects[i] = null;
        }
    }
    // Метод для увеличения размера массива
    private void increase_array(Object[] objectss, int array_size, int new_array_size)
    {
        // Создаем новый массив с увеличенным размером
        Object[] new_objects = new Object[new_array_size];
        // Копируем существующие элементы в новый массив
        for (int i = 0; i < new_array_size; i++)
            if (i < array_size)// Если индекс в пределах старого массива
                new_objects[i] = objects[i];// Копируем элемент
            else
                new_objects[i] = null;// Заполняем оставшиеся элементы значением null
        // Обновляем ссылку на массив и его размер
        this.folder_size = new_array_size;
        this.objects = new_objects;

    }
    // Метод для деактивации всех фигур
    public void deact_all()
    {
        // Проходим по всем элементам массива
        for (int i = 0; i < folder_size; ++i)
            if (objects[i] != null)// Если фигура существует
                objects[i].deactivate();// Деактивируем её
    }
    // Метод для удаления активных фигур
    public void del_active()
    {
        // Проходим по всем элементам массива
        for (int i = 0; i < folder_size; ++i)
            if (objects[i] != null)// Проходим по всем элементам массива
                if (objects[i].isActive())// Если фигура активна
                    objects[i] = null;// Удаляем её (заменяем на null)
    }
    // Метод для проверки выбора или создания новой фигуры
    public void probeg(int x_1, int x_2)
    {
        bool reactive = false;// Флаг, указывающий, была ли выбрана фигура
        // Проходим по всем фигурам в массиве
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
                if (objects[i].Selected(x_1, x_2))//Если фигура выбрана
                {
                    objects[i].change_active();// Меняем её активность
                    reactive = true;// Устанавливаем флаг
                    break;// Выходим из цикла
                }
        }
        // Если ни одна фигура не была выбрана, создаём новую
        if (reactive == false)
        {
            if (flag_circle == true)// Если включен режим создания кругов
            {
                Circle circle = new Circle(x_1, x_2, picturebox1);// Создаём круг
                add_object(circle);// Добавляем круг в массив
                // Активируем только что созданную фигуру
                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }
            else if (flag_square == true)// Если включен режим создания квадратов
            {
                Square square = new Square(x_1, x_2, picturebox1);// Создаём квадрат
                add_object(square);// Добавляем квадрат в массив
                // Активируем только что созданную фигуру
                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }
            else if (flag_triangle == true)// Если включен режим создания треугольников
            {
                Triangle triangle = new Triangle(x_1, x_2 , picturebox1);// Создаём треугольник
                add_object(triangle);// Добавляем треугольник в массив
                // Активируем только что созданную фигуру
                for (int i = 0; i < folder_size + 1; i++)
                {
                    if (objects[i] != null)
                        if (objects[i].Selected(x_1, x_2))
                        {
                            objects[i].activate();
                            break;
                        }
                }
            }

        }

    }
    // Метод для отрисовки всех фигур
    public void paint(PictureBox picturebox1)
    {
        Graphics g = picturebox1.CreateGraphics();// Получаем объект Graphics для рисования
        g.Clear(Color.White);// Очищаем PictureBox (закрашиваем белым цветом)
        // Проходим по всем фигурам в массиве
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
                objects[i].Paint(picturebox1, g);// Отрисовываем её
        }
    }
    // Метод для проверки наличия фигуры по индексу
    public bool check_by_index(int index)
    {
        if (index < folder_size)// Если индекс в границах массива
        {
            if (objects[index] == null)// Если элемент равен null
            {
                return false;// Возвращаем false
            }
            else
            {
                return true;// Возвращаем true
            }
        }
        else
        {
            return false;// Возвращаем false, если индекс вне границ массива
        }
    }
    // Метод для добавления новой фигуры в массив
    public void add_object(Object something)
    {
        Circle circlecheck = something as Circle;// Проверяем, является ли объект кругом
        bool place = false;// Флаг, указывающий, найдено ли свободное место
        for (int i = 0; i < folder_size; i++)// Проходим по всем элементам массива
        {
            if (objects[i] == null)// Если место свободно
            {
                place = true;// Устанавливаем флаг
                objects[i] = something;// Добавляем фигуру
            }
        }// Если массив заполнен, вызываем метод set_object для увеличения размера массива
        if (place == false)
        {
            set_object(folder_size, something);
        }

    }
    // Метод для изменения размера активных фигур
    public void resize(int new_size)
    {
        // Проходим по всем фигурам в массиве
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна
                {
                    objects[i].resize(new_size);// Изменяем её размер
                }
            }
        }
    }
    // Методы для перемещения активных фигур
    // Влево
    public void moveLeft(int dx,int dy)
    {
        for(int i=0; i< folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна    
                {
                    objects[i].move(dx,dy);// Перемещаем её
                }
            }
        }
    }
    // Вправо
    public void moveRight(int dx,int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна
                {
                    objects[i].move(dx,dy);// Перемещаем её     
                }
            }
        }
    }
    // Наверх
    public void moveTop(int dx, int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна
                {
                    objects[i].move(dx,dy);// Перемещаем её
                }
            }
        }
    }
    // Вниз
    public void moveBottom(int dx, int dy)
    {
        for (int i = 0; i < folder_size; i++)
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна
                {
                    objects[i].move(dx,dy);// Перемещаем её
                }
            }
        }
    }
    // Метод для изменения цвета активных фигур
    public void changecolor(Color color)
    {
        for(int i = 0; i < folder_size; i++)// Проходим по всем фигурам в массиве
        {
            if (objects[i] != null)// Если фигура существует
            {
                if (objects[i].isActive())// Если фигура активна
                {
                    objects[i].changecolor(color);// Изменяем её цвет
                }
            }
        }
    }
    // Метод для установки фигуры по индексу
    public void set_object(int index, Object something)
    {
        if (index >= this.folder_size)// Если индекс больше текущего размера массива
        {
            increase_array(objects, folder_size, index + 1);// Увеличиваем размер массива
            objects[index] = something;// Устанавливаем фигуру по индексу
        }
    }
    // Деструктор класса
    ~Folder()
    {
        Console.Write("Хранилище было удалено");// Выводим сообщение при удалении объекта
    }
}