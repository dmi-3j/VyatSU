using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab4
{
    public partial class Form1 : Form
    {
        struct Book
        {
            public int bookID;//код книги
            public int readerID;//номер читательского билета
            public DateTime dateOfIssue;//дата выдачи
            public DateTime dateOfHandover; //срок сдачи
            public Book(int bId, int rId, DateTime dOfIssue, DateTime dOfHandover)//конструктор
            {
                bookID = bId;
                readerID = rId;
                dateOfIssue = dOfIssue;
                dateOfHandover = dOfHandover;
            }
        }
        Book[] givenBooks = new Book[10];
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Код книги";
            dataGridView1.Columns[1].HeaderText = "Номер читательского билета";
            dataGridView1.Columns[2].HeaderText = "Дата выдачи";
            dataGridView1.Columns[3].HeaderText = "Срок сдачи";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "Код книги";
            dataGridView2.Columns[1].HeaderText = "Номер читательского билета";
            dataGridView2.Columns[2].HeaderText = "Дата выдачи";
            dataGridView2.Columns[3].HeaderText = "Срок сдачи";
            dataGridView2.RowHeadersVisible = false;
            button2.Enabled = false; //блокировка кнопки поиска
            поискДанныхToolStripMenuItem.Enabled = false; //блокировка пункта меню
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBox1.Text, out givenBooks[cnt].bookID))
            { 
                MessageBox.Show("Введите корректный код книги!"); //если ошибка, выводим сообщение
                return; 
            }
            
            if (!int.TryParse(textBox2.Text, out givenBooks[cnt].readerID))
            {
                MessageBox.Show("Введите корректный номер читальского билета!"); //если ошибка, выводим сообщение
                return;
            }
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date) //проверка на то, чтобы дата сдачи была позже даты выдачи
            {
                MessageBox.Show("Дата выдачи не может быть позже срока сдачи!"); //если это не так, выводим сообщение
                return;
            }
            
            givenBooks[cnt].dateOfIssue = dateTimePicker1.Value.Date;
            givenBooks[cnt].dateOfHandover = dateTimePicker2.Value.Date;
            dataGridView1.Rows.Add(givenBooks[cnt].bookID, givenBooks[cnt].readerID,givenBooks[cnt].dateOfIssue.ToString("dd.MM.yyyy"), givenBooks[cnt].dateOfHandover.ToString("dd.MM.yyyy")); //добавляем запись в datagridview
            cnt++;
            if (cnt == givenBooks.Length-1) //если число записей превысит размер массива
            {
                Array.Resize(ref givenBooks, 2*givenBooks.Length); //увеличиваем массив в 2 раза
            }
            button2.Enabled = true; //разблокировка кнопки поиска
            поискДанныхToolStripMenuItem.Enabled = true; //разблокировка пункта меню 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int debtorsCount = 0; //счеткик добавленных в поле для вывода строк
            dataGridView2.Rows.Clear(); //очистка поля для вывода
            DateTime selectedDateTime = dateTimePicker3.Value.Date;
            foreach (Book givenBook in givenBooks)
            {
                if (selectedDateTime > givenBook.dateOfHandover) //ищем должников
                {
                    dataGridView2.Rows.Add(givenBook.bookID, givenBook.readerID, givenBook.dateOfIssue.ToString("dd.MM.yyyy"), givenBook.dateOfHandover.ToString("dd.MM.yyyy")); //добавляем записи в таблицу
                    debtorsCount++; //увеличиваем счетчик
                }
            }
            if (debtorsCount == 0) //если должников нет
            {
                MessageBox.Show("Должники на текущую дату не найдены!"); //выводим сообщение
                return;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); //очистка поля для вывода
            dataGridView2.Rows.Clear(); //очистка поля для вывода
            textBox1.Text = ""; //очистка поля для ввода
            textBox2.Text = ""; //очистка поля для ввода
            Array.Clear(givenBooks,0, givenBooks.Length); //очистка массива
            cnt = 0;
            button2.Enabled = false; //блокировка кнопки поиска
            поискДанныхToolStripMenuItem.Enabled = false; //блокировка пункта меню
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 help = new Form2();
            help.ShowDialog(); //вызов справки
        }
        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        { button1_Click(sender, e); }
        private void вЫполнитьЗапросToolStripMenuItem_Click(object sender, EventArgs e)
        { button2_Click(sender, e); }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        { Close(); }
    }
}