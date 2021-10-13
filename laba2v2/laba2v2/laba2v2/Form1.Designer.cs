
namespace laba2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LoadDictBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IsDictLoadedLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.StartHackBtn = new System.Windows.Forms.Button();
            this.LoadTextBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IsTextLoadedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.StopHackBtn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadDictBtn
            // 
            this.LoadDictBtn.Location = new System.Drawing.Point(651, 78);
            this.LoadDictBtn.Name = "LoadDictBtn";
            this.LoadDictBtn.Size = new System.Drawing.Size(119, 27);
            this.LoadDictBtn.TabIndex = 0;
            this.LoadDictBtn.Text = "Загрузить словарь";
            this.LoadDictBtn.UseVisualStyleBackColor = true;
            this.LoadDictBtn.Click += new System.EventHandler(this.LoadDictBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(776, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Словарь:";
            // 
            // IsDictLoadedLabel
            // 
            this.IsDictLoadedLabel.AutoSize = true;
            this.IsDictLoadedLabel.Location = new System.Drawing.Point(829, 85);
            this.IsDictLoadedLabel.Name = "IsDictLoadedLabel";
            this.IsDictLoadedLabel.Size = new System.Drawing.Size(72, 13);
            this.IsDictLoadedLabel.TabIndex = 1;
            this.IsDictLoadedLabel.Text = "Не загружен";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(623, 370);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // StartHackBtn
            // 
            this.StartHackBtn.Location = new System.Drawing.Point(907, 22);
            this.StartHackBtn.Name = "StartHackBtn";
            this.StartHackBtn.Size = new System.Drawing.Size(123, 55);
            this.StartHackBtn.TabIndex = 0;
            this.StartHackBtn.Text = "Начать взлом";
            this.StartHackBtn.UseVisualStyleBackColor = true;
            this.StartHackBtn.Click += new System.EventHandler(this.StartHackBtn_Click);
            // 
            // LoadTextBtn
            // 
            this.LoadTextBtn.Location = new System.Drawing.Point(651, 22);
            this.LoadTextBtn.Name = "LoadTextBtn";
            this.LoadTextBtn.Size = new System.Drawing.Size(119, 27);
            this.LoadTextBtn.TabIndex = 0;
            this.LoadTextBtn.Text = "Загрузить текст";
            this.LoadTextBtn.UseVisualStyleBackColor = true;
            this.LoadTextBtn.Click += new System.EventHandler(this.LoadTextBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Текст:";
            // 
            // IsTextLoadedLabel
            // 
            this.IsTextLoadedLabel.AutoSize = true;
            this.IsTextLoadedLabel.Location = new System.Drawing.Point(829, 29);
            this.IsTextLoadedLabel.Name = "IsTextLoadedLabel";
            this.IsTextLoadedLabel.Size = new System.Drawing.Size(72, 13);
            this.IsTextLoadedLabel.TabIndex = 1;
            this.IsTextLoadedLabel.Text = "Не загружен";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Разделитель слов в файле: пробел";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(904, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Время старта: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(984, 85);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(46, 13);
            this.StartTimeLabel.TabIndex = 1;
            this.StartTimeLabel.Text = "0 минут";
            // 
            // StopHackBtn
            // 
            this.StopHackBtn.Location = new System.Drawing.Point(1040, 22);
            this.StopHackBtn.Name = "StopHackBtn";
            this.StopHackBtn.Size = new System.Drawing.Size(123, 55);
            this.StopHackBtn.TabIndex = 0;
            this.StopHackBtn.Text = "Остановить работу";
            this.StopHackBtn.UseVisualStyleBackColor = true;
            this.StopHackBtn.Click += new System.EventHandler(this.StopHackBtn_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(651, 124);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.LegendText = ".";
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(499, 254);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 390);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.IsTextLoadedLabel);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.IsDictLoadedLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopHackBtn);
            this.Controls.Add(this.StartHackBtn);
            this.Controls.Add(this.LoadTextBtn);
            this.Controls.Add(this.LoadDictBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "-";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadDictBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IsDictLoadedLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button StartHackBtn;
        private System.Windows.Forms.Button LoadTextBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IsTextLoadedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.Button StopHackBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

