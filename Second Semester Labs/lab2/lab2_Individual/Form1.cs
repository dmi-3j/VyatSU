using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace lab2_Individual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // создание контекстного меню
            System.Windows.Forms.ContextMenu contextMenu1;
            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();
            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            menuItem1, menuItem2, menuItem3 });
            menuItem1.Index = 0;
            menuItem1.Text = "Открыть";
            menuItem2.Index = 1;
            menuItem2.Text = "Сохранить";
            menuItem3.Index = 2;
            menuItem3.Text = "Сохранить как";
            richTextBox1.ContextMenu = contextMenu1;
            menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
        }
        string MyFName = "";
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = openFileDialog1.FileName;
                richTextBox1.LoadFile(MyFName);
            }
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (MyFName != "")
            {
                richTextBox2.SaveFile(MyFName);
            }
            else
            {
                saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MyFName = saveFileDialog1.FileName;
                    richTextBox2.SaveFile(MyFName);
                }
            }
        }
        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовые файлы(*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = saveFileDialog1.FileName;
                richTextBox2.SaveFile(MyFName);
            }
        }
        int cnt = 0; // счетчик количетсва табуляций
        private void Form1_KeyPress(object sender, KeyPressEventArgs e) // метод обработки нажатий клавиш на клавиатуре
        {
            if (richTextBox1.ReadOnly == true) // если поле для ввода заблокировано
            {
                string[] lines = richTextBox1.Text.Split('\t'); // создаем массив строк, разделенных символом табуляции
                if (lines.Length == 1) // проверка на отсутствие символов табуляции в тексте
                {
                    MessageBox.Show("Нет символов табуляции в тексте!"); // вывод информационного сообщения
                    return; // выход из метода
                }
                if (cnt < lines.Length) // считывание количества нажатий на клавиши и проверка на выход за границы массива строк
                {
                    richTextBox2.AppendText(lines[cnt] + Environment.NewLine); //разделение исходного текста на строки
                    cnt++; // увеличение счетчика количества табуляций
                }
                else //если вывели все фрагменты текста, выводим сообщение
                {
                   MessageBox.Show("Количество символов табуляции: " + (cnt-1)); //вывод информационного сообщения с количеством табуляций
                }
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true; //блокировка поля для ввода для корректной обработки нажатий клавиш
            button1.Enabled = false; //блокировка кнопки готово
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = false; // разблокировка поля для ввода
            richTextBox1.Text = ""; // очистка поля для ввода
            richTextBox2.Text = ""; // очистка поля для вывода
            cnt = 0; // сброс счетчика табуляций
            button1.Enabled = true; //разблокировка кнопки готово
        }
    }
}