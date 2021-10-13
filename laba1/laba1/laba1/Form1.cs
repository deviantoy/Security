using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        private bool isKeywordAdded = false;
        private int KeyLength = 16;
        public Form1()
        {
            InitializeComponent();

        }
        TritemiusCipher tc = new TritemiusCipher();


        private void button1_Click(object sender, EventArgs e) // загрузить слово
        {
            if(textBox1.Text.Length > KeyLength)
            {
                MessageBox.Show("Максимальная длина ключа: 16 символов");
                return;
            }
            GenerateMatrix();
        }


        private void GenerateMatrix()
        {
            bool res = tc.setKeyword(textBox1.Text.ToLower());
            if (!res)
            {
                MessageBox.Show("Вы ввели неподходящий ключ. Скорее всего содержит символы, не входящие в русский алфавит.");
                return;
            }
            RenderMatrix();
        }

        private void RenderMatrix()
        {
            matrixLabel.Text = String.Empty;
            int couter = 0;
            foreach (var ch in tc.getMatrix())
            {
                if (couter % 1 == 0)
                    matrixLabel.Text += ' ';
                if (couter % 7 == 0)
                    matrixLabel.Text += '\n';

                couter++;
                matrixLabel.Text += ch;
            }
            isKeywordAdded = true;
        }

        private void загрузитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadFile(richTextBox1);
            richTextBox2.Text = String.Empty;
            SaveEncryptBtn.Visible = false;
        }

        private void загрузитьФайлДляДЕшифровкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadFile(richTextBox3);
            richTextBox4.Text = String.Empty;
            SaveDecryptBtn.Visible = false;
        }
        private void ReadFile(RichTextBox rtb)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Encoding enc;
                string text;
                Stream fs = new FileStream(ofd.FileName, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs, true))
                {
                    enc = sr.CurrentEncoding;
                    if (enc != Encoding.UTF8)
                    {
                        MessageBox.Show("Кодировка файла должна быть UTF-8!");
                        return;
                    }
                    text = sr.ReadToEnd().ToLower();
                }
                rtb.Text = text;
                bool flag = true;
                for (int i = 0; i < text.Length; i++)
                {
                    //MessageBox.Show($"l:{text[i]} byte:{(byte)text[i]}");
                    if ((byte)text[i] == 10 || (byte)text[i] == 13)
                        continue;

                    if (!tc.inMatrix(text[i]))
                    {
                        MessageBox.Show($"Символа \"{text[i]}\" на позиции {i} нет в алфавите");
                        rtb.Text = String.Empty;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    MakeVisibleElements();
            }
        }

        private void MakeVisibleElements()
        {
            label3.Text = "Введите кодовое слово";
            textBox1.Visible = true;
            button1.Visible  = true;
            button2.Visible  = true;
        }

        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text) && !isKeywordAdded)
            {
                MessageBox.Show("Вы не указали кодовое слово. Если не хотите использовать никакое кодовое слово, то просто нажмите \"Загрузить слово\" и загрузится стандартный алфавит.");
                return;
            }

            try
            {
                richTextBox2.Text = tc.Encrypt(richTextBox1.Text);
                SaveEncryptBtn.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка шифровки: " + ex.Message);
            }
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text) && !isKeywordAdded)
            {
                MessageBox.Show("Вы не указали кодовое слово. Если не хотите использовать никакое кодовое слово, то просто нажмите \"Загрузить слово\" и загрузится стандартный алфавит.");
                return;
            }

            try
            {
                richTextBox4.Text = tc.Decrypt(richTextBox3.Text);
                SaveDecryptBtn.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка дешифровки: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            matrixLabel.Text = String.Empty;

            Random r = new Random();
            int lengthRandomKey = r.Next(1, 17); // от 1 до 16
            for(int _ = 0; _ < lengthRandomKey; _++)
            {
                textBox1.Text +=tc.getCharFromAlphabet(r.Next(0, tc.getAlphabetLenght()));
            }
            GenerateMatrix();
        }

        private void SaveEncryptBtn_Click(object sender, EventArgs e)
        {
            WriteDataToFile(WriteMode.Encrypted);
        }

        private void SaveDecryptBtn_Click(object sender, EventArgs e)
        {
            WriteDataToFile(WriteMode.Decrypted);
        }

        private void WriteDataToFile(WriteMode mode)
        {
            string encryptedFile = $"saved_Encrypted_{DateTime.Now.ToString("F").Replace(':', '-')}.txt";
            string decryptedFile = $"saved_Decrypted_{DateTime.Now.ToString("F").Replace(':', '-')}.txt";

            switch( mode)
            {
                case WriteMode.Encrypted:
                    File.WriteAllText(encryptedFile, richTextBox2.Text);
                    break;
                case WriteMode.Decrypted:
                    File.WriteAllText(decryptedFile, richTextBox4.Text);
                    break;
            }
        }

        enum WriteMode
        {
            Encrypted,
            Decrypted
        }
    }
}
