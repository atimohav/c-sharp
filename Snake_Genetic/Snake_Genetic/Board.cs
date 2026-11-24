using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Genetic
{
    internal class Board //поле змеи
    {
        private Snake snake;
        private int[] apple = new int[2];

        public Board(Snake snake)
        {
            this.snake = snake;
            genapple();
        }
        private void genapple()
        {
            do
            {
                apple[0] = RND.GetInt(0, GlobalVar.BoardSize);
                apple[1] = RND.GetInt(0, GlobalVar.BoardSize);
            } while (snake.body[0, 0] == apple[0] && snake.body[0, 1] == apple[1]);
        }
        public void dostep()
        {
            if (snake.lifetime >= snake.timerem) snake.lifeline = false;
            if (snake.lifeline == false) return;
            int[,] observation = new int[8, 3];

            int x = snake.body[0, 0];
            int y = snake.body[0, 1];
            int ax = apple[0];
            int ay = apple[1];
            int sx = ax - x;
            int sy = ay - y;

            //поиск яблока {
            //север
            if (sy > 0 && Math.Abs(sx) < Math.Abs(sy)) observation[0, 0] = sy;
            //север-восток
            if (sx > 0 && sy > 0) observation[1, 0] = sx+sy;
            //восток
            if (sx > 0 && Math.Abs(sx) > Math.Abs(sy)) observation[2, 0] = sx;
            //юг-восток
            if (sx > 0 && sy < 0) observation[3, 0] = sx-sy;
            //юг
            if (sy < 0 && Math.Abs(sx) < Math.Abs(sy)) observation[4, 0] = -sy;
            //юг-запад
            if (sx < 0 && sy < 0) observation[5, 0] = -sx-sy;
            //запад
            if (sx < 0 && Math.Abs(sx) > Math.Abs(sy)) observation[6, 0] = -sx;
            //север-запад
            if (sx < 0 && sy > 0) observation[7, 0] = -sx+sy;
            //поиск яблока }
            //поиск стен {
            //север
            observation[0, 1] = (GlobalVar.BoardSize - y);
            //север-восток
            observation[1, 1] = Math.Min(GlobalVar.BoardSize - x, GlobalVar.BoardSize - y);
            //восток
            observation[2, 1] = (GlobalVar.BoardSize - x);
            //юг-восток
            observation[3, 1] = Math.Min(GlobalVar.BoardSize - x, y + 1);
            //юг
            observation[4, 1] = (y + 1);
            //юг-запад
            observation[5, 1] = Math.Min(x + 1, y + 1);
            //запад
            observation[6, 1] = (x + 1);
            //север-запад
            observation[7, 1] = Math.Min(x + 1, GlobalVar.BoardSize - y);
            //поиск стен }
            //поиск хвоста {
            for (int i = 1; i < snake.length; i++)
            {
                int bx = snake.body[i, 0] - x;
                int by = snake.body[i, 1] - y;
                //север
                if (bx == 0 && by > 0) if (observation[0, 2] == 0 || observation[0, 2] > by) observation[0, 2] = by;
                //север-восток
                if (bx == by && bx > 0) if (observation[1, 2] == 0 || observation[1, 2] > bx) observation[1, 2] = bx;
                //восток
                if (by == 0 && bx > 0) if (observation[2, 2] == 0 || observation[2, 2] > bx) observation[2, 2] = bx;
                //юг-восток
                if (bx == -by && bx > 0) if (observation[3, 2] == 0 || observation[3, 2] > bx) observation[3, 2] = bx;
                //юг
                if (bx == 0 && by < 0) if (observation[4, 2] == 0 || observation[4, 2] > -by) observation[4, 2] = -by;
                //юг-запад
                if (bx == by && bx < 0) if (observation[5, 2] == 0 || observation[5, 2] > -bx) observation[5, 2] = -bx;
                //запад
                if (by == 0 && bx < 0) if (observation[6, 2] == 0 || observation[6, 2] > -bx) observation[6, 2] = -bx;
                //север-запад
                if (bx == -by && bx < 0) if (observation[7, 2] == 0 || observation[7, 2] > -bx) observation[7, 2] = -bx;
            }
            //поиск хвоста }
            for (int i = 0; i < 24; i++)
            {
                if (observation[i / 3, i % 3] != 0) snake.input[i] = 1 / observation[i / 3, i % 3];
                else snake.input[i] = 0;
            }
            snake.Think();
            int bestdir = 0;
            for (int i = 1; i < 4; i++) if (snake.output[i] > snake.output[bestdir]) bestdir = i;
            int status = 0;
            int[] dir = new int[2];
            if (bestdir == 0) dir = new int[2] { 0, 1 };
            else if (bestdir == 1) dir = new int[2] { 1, 0 };
            else if (bestdir == 2) dir = new int[2] { 0, -1 };
            else dir = new int[2] { -1, 0 };
            int x0 = snake.body[0,0];
            int y0 = snake.body[0,1];
            status = snake.move(dir, apple);
            int x1 = snake.body[0, 0];
            int y1 = snake.body[0, 1];
            if (status == 0)
            {
                snake.lifeline = false;
            }
            else
            {
                snake.lifetime++;
                snake.lifeline = true;
                snake.score += Math.Max((x1-x0)+(y1-y0),0);
            }
            if (status == 2)
            {
                genapple();
                snake.score += snake.timerem*Math.Pow(1 + snake.length - Snake.InitLength, 1);
                snake.timerem += Snake.BonusTimeApple;
            }
        }

        public void FillGrid(bool iscur, int[,] grid)
        {
            int scale = 1;
            if (iscur == true) scale = 10;
            if (snake.lifeline == true)
            {
                for (int i = 0; i < snake.length; i++)
                {
                    if (snake.body[i, 0] < GlobalVar.BoardSize && snake.body[i, 1] < GlobalVar.BoardSize && snake.body[i, 0] >= 0 && snake.body[i, 1] >= 0)
                    {
                        if (grid[snake.body[i, 0], snake.body[i, 1]] != 1 && grid[snake.body[i, 0], snake.body[i, 1]] < 10) grid[snake.body[i, 0], snake.body[i, 1]] = 2*scale;
                    }
                }
                if (grid[apple[0], apple[1]] < 10) grid[apple[0], apple[1]] = 1*scale;
            }
        }
    }
}
