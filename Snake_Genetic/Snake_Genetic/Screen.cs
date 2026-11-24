using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Genetic
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
            if(Phase != 0)
            {
                g = CreateGraphics();
                game = new Game(g, InformationLabel, PopulationChart);
            }
        }
        int Phase = 0;
        Graphics g;
        Game game;
        Timer timer = new Timer();
        int MaxSpeed = GlobalVar.MaxSpeed;
        int MinSpeed = GlobalVar.MinSpeed;
        int timerCounter = 0;
        private void Screen_Load(object sender, EventArgs e)
        {
            if(timerCounter == 0) {
                timer.Interval = 10; //интервал между срабатываниями
                timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick  
                timer.Start();
            }
        }


        void timer_Tick(object sender, EventArgs e)
        {
            if(Phase != 0)
            {
                timerCounter++;
                if(timerCounter%GlobalVar.CountsPerTick == 0) {
                    for (int t = 0; t < GlobalVar.CurSpeed; t++) game.Tick(t == GlobalVar.CurSpeed - 1);
                    Update();
                }
            }
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (GlobalVar.CurSpeed == MaxSpeed) GlobalVar.CurSpeed = MinSpeed;
                else GlobalVar.CurSpeed = MaxSpeed;
            }
        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {
            if (Phase != 0)
            {
                g = CreateGraphics();
                game.Reload(g);
            }
        }

        private void Initial_Data_Set(object sender, EventArgs e)
        {
            GlobalVar.Mu = int.Parse(textBox1.Text);
            GlobalVar.Lambda = (int)Math.Pow(GlobalVar.Mu, 2);
            Phase = 1;
            g = CreateGraphics();
            game = new Game(g, InformationLabel, PopulationChart);

            label1.Dispose();
            label2.Dispose();
            textBox1.Dispose();
            label3.Dispose();
            button1.Dispose();
            InformationLabel.Visible = true;
            CurSnakeTextBox.Visible = true;
            CurSnakeButton.Visible = true;
            ShowAllSnakesCheckBox.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            SpeedTextBox.Visible = true;
            label6.Visible = true;
            SpeedButton.Visible = true;
            PopulationChart.Visible = true;
        }

        private void ChangeCurSnake(object sender, EventArgs e)
        {
            GlobalVar.CurSnake = int.Parse(CurSnakeTextBox.Text);
        }

        private void ChangeSpeed(object sender, EventArgs e)
        {
            GlobalVar.CurSpeed = int.Parse(SpeedTextBox.Text);
        }

        private void ShowAllSnakesChange(object sender, EventArgs e)
        {
            GlobalVar.ShowAllSnakes = ShowAllSnakesCheckBox.Checked;
            if(GlobalVar.ShowAllSnakes) GlobalVar.CountsPerTick = 5;
            else GlobalVar.CountsPerTick = 1;
        }

        private void PopulationChart_Click(object sender, EventArgs e)
        {

        }
    }
}
