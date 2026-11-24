using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Snake_Genetic
{
    internal class Game //Управление полями змей
    {
        public int[] genarr = new int[100000];
        public float[] scorearr = new float[100000];
        public float[] applearr = new float[100000];
        public int Generation = 0;
        public static int N = GlobalVar.Mu + GlobalVar.Lambda;
        public Board[] boards = new Board[N];
        public Snake[] snakes = new Snake[N];
        public int[,] grid = new int[GlobalVar.BoardSize, GlobalVar.BoardSize];
        private Graphics g;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        public Game(Graphics g, System.Windows.Forms.Label InformationLabel, System.Windows.Forms.DataVisualization.Charting.Chart chart, int gen = 0)
        {
            Generation = gen;
            this.g = g;
            this.InformationLabel = InformationLabel;
            this.chart = chart;
            for (int i = 0; i < N; i++)
            {
                snakes[i] = new Snake();
                boards[i] = new Board(snakes[i]);
                boards[i].FillGrid(i == GlobalVar.CurSnake, grid);
            }
        }
        public void Reload(Graphics g)
        {
            this.g = g;
        }
        public void Tick(bool drawflag)
        {
            int sc = GlobalVar.Scale;
            bool GameLifeline = false;
            grid = new int[GlobalVar.BoardSize, GlobalVar.BoardSize];
            Parallel.For(0, N, i =>
            {
                boards[i].dostep();
                boards[i].FillGrid(i == GlobalVar.CurSnake, grid);

                GameLifeline = GameLifeline || snakes[i].lifeline;
            });
            if (drawflag)
            {
                Draw(g, InformationLabel);
            }
            ///////////////////////////////////////////////////////////////////////////////
            if (GameLifeline == false)
            {
                int Mu = GlobalVar.Mu;
                Array.Sort(snakes, new SnakeComparerApple());
                float appleavr = 0;
                foreach (var i in snakes) appleavr += i.length - Snake.InitLength;
                appleavr /= snakes.Length;
                applearr[Generation] = (float)(appleavr);
                Array.Sort(snakes, new SnakeComparerScore());
                scorearr[Generation] = (float)(snakes[0].score+0);
                genarr[Generation] = Generation;
                DrawChartPopulation(chart, genarr, scorearr, applearr);
                //DrawChartGeneration(g, snakes, 400, GlobalVar.BoardSize * GlobalVar.Scale + 10, 410);

                for (int i = 0; i < Mu; i++)
                {
                    snakes[i].Resurrect();
                }
                for (int i = 0; i < Mu; i++)
                    for (int j = 0; j < Mu; j++)
                    {
                        snakes[Mu + i * Mu + j] = new Snake(snakes[i], snakes[j]);
                    }
                for (int i = 0; i < N; i++) boards[i] = new Board(snakes[i]);
                Generation++;
            }
        }
        public void Draw(Graphics g, System.Windows.Forms.Label InformationLabel, int x0=0, int y0=0)
        {
            int sc = GlobalVar.Scale;
            g.FillRectangle(Brushes.Black, x0, y0, GlobalVar.BoardSize * sc, GlobalVar.BoardSize * sc);
            for (int i = 0; i < GlobalVar.BoardSize; i++)
            for (int j = 0; j < GlobalVar.BoardSize; j++)
            {
                SolidBrush appleBrush = new SolidBrush(Color.FromArgb(255, 255, 64, 0));
                SolidBrush snakeBrush = new SolidBrush(Color.FromArgb(255, 128, 128, 128));
                SolidBrush appleBrushWeak = new SolidBrush(Color.FromArgb(64, 255, 64, 0));
                SolidBrush snakeBrushWeak = new SolidBrush(Color.FromArgb(64, 128, 128, 128));
                if (grid[i, j] == 10) g.FillRectangle(appleBrush, x0 + i * sc, y0 + j * sc, sc, sc);
                else if (grid[i, j] == 20) g.FillRectangle(snakeBrush, x0 + i * sc, y0 + j * sc, sc, sc);
                if (GlobalVar.ShowAllSnakes) {
                    if (grid[i, j] == 1) g.FillRectangle(appleBrushWeak, x0 + i * sc, y0 + j * sc, sc, sc);
                    else if (grid[i, j] == 2) g.FillRectangle(snakeBrushWeak, x0 + i * sc, y0 + j * sc, sc, sc);
                }
            }
            InformationLabel.Text = "Текущее поколение: " + genarr[genarr.Max()] +
                    "\nЛучший счёт в предыдущем поколении: " + scorearr[genarr.Max()] + 
                    "\nМаксимально яблок съедено в предыдущем поколении: " + applearr[genarr.Max()];
        }

        public void DrawChartPopulation(Graphics g, int[] xax, int[] yax, int size = 200, int x0=0, int y0=0)
        {
            g.FillRectangle(Brushes.Gray, x0, y0, size, size);
            Pen yellowPen = new Pen(Color.Yellow, 3);
            double top = yax.Max();
            int right = xax.Max();
            int left = Math.Max(xax.Min(), right - 100);
            for (int i=left+1; i < right; i++)
            {
                Point point1 = new Point(x0 + ((xax[i-1]-left)*size / (right - left)), y0+size-(int)(yax[i-1] * size / top));
                Point point2 = new Point(x0 + ((xax[i]  -left)*size / (right - left)), y0+size-(int)(yax[i] * size / top));
                g.DrawLine(yellowPen, point1, point2);
            }
        }

        public void DrawChartPopulation(System.Windows.Forms.DataVisualization.Charting.Chart chart, int[] xax, float[] Scoreyax, float[] Appleyax) 
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            int right = xax.Max();
            int left = Math.Max(xax.Min(), right - 100);
            for (int i = left; i < right; i++)
            {
                chart.Series[0].Points.AddXY(xax[i], Scoreyax[i]);
                chart.Series[1].Points.AddXY(xax[i], Appleyax[i]);
            }

        }

        public void DrawChartGeneration(Graphics g, Snake[] snakes, int size = 200, int x0 = 0, int y0 = 0)
        {
            g.FillRectangle(Brushes.Gray, x0, y0, size, size);
            Pen orangePen = new Pen(Color.Orange, 3);
            double top = snakes[0].score;
            for (int i = 1; i < snakes.Length; i++)
            {
                Point point1 = new Point(x0 + (int)((float)(i - 1) / snakes.Length * size), y0 + (int)(snakes[i - 1].score * size / top));
                Point point2 = new Point(x0 + (int)((float)i       / snakes.Length * size), y0 + (int)(snakes[i]    .score * size / top));
                //g.DrawLine(orangePen, point1, point2);
            }
        }
    }
}
