using System;
using System.Data.SqlTypes;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        static char[] letters = { 'А', 'Б', 'В', 'Г', 'Д', 'Е','Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        int N = letters.Length; 
        public string EncodeDecode(string inputText, string keyWord, int param)
        {
            string outText = "";
            inputText = inputText.ToUpper();
            keyWord = keyWord.ToUpper();
            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Поле не может быть пустым. Введите текст.");
                return "";
            }
            if (string.IsNullOrWhiteSpace(keyWord))
            {
                MessageBox.Show("Поле ключ не может быть пустым.");
                return "";
            }
            int keyWordIndex = 0;
            int index = 0;
            foreach (char symbol in inputText)
            {
                int indexOfSymbolText = Array.IndexOf(letters, symbol);
                int indexOfKey = Array.IndexOf(letters, keyWord[keyWordIndex]);
                if (indexOfKey == -1)
                {
                    MessageBox.Show("Некорректный ключ!");
                    return "";
                }
                switch (param)
                {
                    case 0: index = (indexOfSymbolText + indexOfKey) % N; break;
                    case 1: index = (indexOfSymbolText + N - indexOfKey) % N; break;
                }
                if (indexOfSymbolText == -1)
                {
                    outText += symbol;
                }
                else
                {
                    outText += letters[index];
                    keyWordIndex++;
                    if (keyWordIndex == keyWord.Length) keyWordIndex = 0;
                }
            }
            endodeButton.Enabled = false;
            decodeButton.Enabled = false;
            encodeToolStripMenuItem.Enabled = false;
            decodeToolStripMenuItem.Enabled = false;
            encodedTextField.ReadOnly = true;
            originalTextField.ReadOnly = true;
            return outText;
        }
      
        private void endodeButton_Click(object sender, EventArgs e)
        {
            string inputText = originalTextField.Text;
            string keyWord = keyField.Text;
            string outText = EncodeDecode(inputText, keyWord, 0);
            encodedTextField.Text = outText;
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            string inputText = encodedTextField.Text;
            string keyWord = keyField.Text;
            string outText = EncodeDecode(inputText, keyWord, 1);
            originalTextField.Text = outText;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            originalTextField.Clear();
            encodedTextField.Clear();
            encodedTextField.ReadOnly = false;
            originalTextField.ReadOnly = false;
            endodeButton.Enabled = true;
            decodeButton.Enabled = true;
            encodeToolStripMenuItem.Enabled = true;
            decodeToolStripMenuItem.Enabled = true;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 help = new Form2();
            help.ShowDialog();
        }

        private void encodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endodeButton_Click(sender, e);
        }

        private void decodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decodeButton_Click(sender, e);
        }
    }
}