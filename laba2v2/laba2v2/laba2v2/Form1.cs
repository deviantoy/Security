using laba2v2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        private TritemiusChipherHacker TCH;
        private string textToHack;
        private List<string> dict;



        public Form1()
        {
            InitializeComponent();

            StopHackBtn.Enabled = false;

            textToHack = "";
            TCH = new TritemiusChipherHacker();
            dict = new List<string>();

            initListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void initListView()
        {
            TCH.setListView(listView1);
            listView1.View = View.Details;
            listView1.Columns.Add("Попытка", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Время", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Событие", -2, HorizontalAlignment.Left);
        }

        private void StartHackBtn_Click(object sender, EventArgs e)
        {
            if (NotAllLoaded())
            {
                MessageBox.Show("Не все данные были загружены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DisableButtons();
            TCH.setCancel(false);

            StartTimeLabel.Text = DateTime.Now.ToShortTimeString();

            Task t = new Task(TCH.Start);
            t.Start();

            StartTimeLabel.Text = $"{DateTime.Now.ToShortTimeString()}";
        }

        private bool NotAllLoaded()
        {
            if (dict.Count == 0 || textToHack == String.Empty)
                return true;
            return false;
        }

        private void DisableButtons()
        {
            StartHackBtn.Enabled = false;
            LoadDictBtn.Enabled  = false;
            LoadTextBtn.Enabled  = false;
            StopHackBtn.Enabled  = true;
        }

        private void EnableButtons()
        {
            StartHackBtn.Enabled = true;
            LoadDictBtn.Enabled  = true;
            LoadTextBtn.Enabled  = true;
            StopHackBtn.Enabled  = false;
        }

        // Загрузить текст для взлома
        private void LoadTextBtn_Click(object sender, EventArgs e)
        {
            UploadData(textToHack);
            TCH.setText(textToHack);
        }

        //Загрузить словарь слов
        private void LoadDictBtn_Click(object sender, EventArgs e)
        {
            UploadData(dict);
            TCH.setDict(dict);
        }


        private void UploadData<T> (T dataList)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.Title = "Выберите файл .txt со словарём.";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    if (dataList.GetType() == typeof( List<string> ))
                    {
                        dict = sr.ReadToEnd().ToString().Split(' ').ToList();
                        IsDictLoadedLabel.Text = "Загружен";
                    }
                    else if (dataList.GetType() == typeof( string ))
                    {
                        textToHack = sr.ReadToEnd().ToString();
                        IsTextLoadedLabel.Text = "Загружен";
                    }
                }
            }
        }

        private void StopHackBtn_Click(object sender, EventArgs e)
        {
            if (TCH.workDone)
                SaveDecryptedText();

            TCH.setCancel(true);
            TCH.UpdateInfo();

            EnableButtons();
            DrawGraph();
        }

        private void SaveDecryptedText()
        {
            File.WriteAllText("Encrypted_text.txt", TCH.hackedText);
            MessageBox.Show("Наконец-то", "Файл с дешифрованным текстом сохранён!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DrawGraph()
        {
            chart1.Titles.Add("График зависимости траты попыток на взлом от кол-ва символов в ключе");
            chart1.Series[0].Color = Color.Purple;
            chart1.Series[0].BorderWidth = 3;
            chart1.ChartAreas[0].AxisX.Title = @"Длина ключа";
            chart1.ChartAreas[0].AxisY.Title = @"Кол-во попыток";

            for (int i = 0; i < TCH._attempts.Count; i++)
                chart1.Series[0].Points.AddXY(TCH._keyLength[i], TCH._attempts[i]);
            
        }


        private void panel1_Click(object sender, EventArgs e)
        {
            foreach (int i in TCH._attempts)
                MessageBox.Show("attempts: " + i);
            foreach (int i in TCH._keyLength)
                MessageBox.Show("length: " + i);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
