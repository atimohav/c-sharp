namespace Snake_Genetic
{
    partial class Screen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.CurSnakeTextBox = new System.Windows.Forms.TextBox();
            this.CurSnakeButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SpeedButton = new System.Windows.Forms.Button();
            this.ShowAllSnakesCheckBox = new System.Windows.Forms.CheckBox();
            this.PopulationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(455, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Генетический алгоритм обучения нейросети (µ + λ)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(379, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите значение для µ (целое число > 0):";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(395, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "λ определяется автоматически, λ = µ*µ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(772, 220);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "25";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(772, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "подтвердить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Initial_Data_Set);
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InformationLabel.Location = new System.Drawing.Point(806, 513);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(697, 87);
            this.InformationLabel.TabIndex = 5;
            this.InformationLabel.Text = "Текущее поколение:\r\nЛучший счёт в предыдущем поколении:\r\nМаксимально яблок съеден" +
    "о в предыдущем поколении:";
            this.InformationLabel.Visible = false;
            // 
            // CurSnakeTextBox
            // 
            this.CurSnakeTextBox.Location = new System.Drawing.Point(908, 625);
            this.CurSnakeTextBox.Name = "CurSnakeTextBox";
            this.CurSnakeTextBox.Size = new System.Drawing.Size(50, 22);
            this.CurSnakeTextBox.TabIndex = 6;
            this.CurSnakeTextBox.Text = "0";
            this.CurSnakeTextBox.Visible = false;
            // 
            // CurSnakeButton
            // 
            this.CurSnakeButton.Location = new System.Drawing.Point(964, 622);
            this.CurSnakeButton.Name = "CurSnakeButton";
            this.CurSnakeButton.Size = new System.Drawing.Size(89, 29);
            this.CurSnakeButton.TabIndex = 7;
            this.CurSnakeButton.Text = "показать";
            this.CurSnakeButton.UseVisualStyleBackColor = true;
            this.CurSnakeButton.Visible = false;
            this.CurSnakeButton.Click += new System.EventHandler(this.ChangeCurSnake);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(808, 628);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Змея номер:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(808, 661);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Отрисовывать каждые";
            this.label5.Visible = false;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(982, 658);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(44, 22);
            this.SpeedTextBox.TabIndex = 10;
            this.SpeedTextBox.Text = "1";
            this.SpeedTextBox.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1032, 661);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "шагов";
            this.label6.Visible = false;
            // 
            // SpeedButton
            // 
            this.SpeedButton.Location = new System.Drawing.Point(1084, 654);
            this.SpeedButton.Name = "SpeedButton";
            this.SpeedButton.Size = new System.Drawing.Size(111, 30);
            this.SpeedButton.TabIndex = 12;
            this.SpeedButton.Text = "установить";
            this.SpeedButton.UseVisualStyleBackColor = true;
            this.SpeedButton.Visible = false;
            this.SpeedButton.Click += new System.EventHandler(this.ChangeSpeed);
            // 
            // ShowAllSnakesCheckBox
            // 
            this.ShowAllSnakesCheckBox.AutoSize = true;
            this.ShowAllSnakesCheckBox.Location = new System.Drawing.Point(1059, 627);
            this.ShowAllSnakesCheckBox.Name = "ShowAllSnakesCheckBox";
            this.ShowAllSnakesCheckBox.Size = new System.Drawing.Size(219, 20);
            this.ShowAllSnakesCheckBox.TabIndex = 13;
            this.ShowAllSnakesCheckBox.Text = "Показывать сразу всех змей";
            this.ShowAllSnakesCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllSnakesCheckBox.Visible = false;
            this.ShowAllSnakesCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllSnakesChange);
            // 
            // PopulationChart
            // 
            chartArea3.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisY2.Interval = 1D;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.PopulationChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.PopulationChart.Legends.Add(legend3);
            this.PopulationChart.Location = new System.Drawing.Point(811, 9);
            this.PopulationChart.Name = "PopulationChart";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.Legend = "Legend1";
            series5.Name = "Лучший счёт \\nпредыдущих \\n100 поколений \\nОсь слева";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.Name = "Наибольшее количество \\nяблок съедено \\nв последних \\n100 поколениях \\nОсь справа" +
    "";
            series6.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.PopulationChart.Series.Add(series5);
            this.PopulationChart.Series.Add(series6);
            this.PopulationChart.Size = new System.Drawing.Size(750, 500);
            this.PopulationChart.TabIndex = 14;
            this.PopulationChart.Text = "chart1";
            this.PopulationChart.Visible = false;
            this.PopulationChart.Click += new System.EventHandler(this.PopulationChart_Click);
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 737);
            this.Controls.Add(this.ShowAllSnakesCheckBox);
            this.Controls.Add(this.SpeedButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SpeedTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CurSnakeButton);
            this.Controls.Add(this.CurSnakeTextBox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PopulationChart);
            this.Name = "Screen";
            this.Text = "КП Аладьин Т.В. М8О-202Б-22";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Screen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Screen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Screen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PopulationChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.TextBox CurSnakeTextBox;
        private System.Windows.Forms.Button CurSnakeButton;
        private System.Windows.Forms.CheckBox ShowAllSnakesCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SpeedButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart PopulationChart;
    }
}

