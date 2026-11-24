using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Genetic
{
    internal class Snake
    {
        public const int InitLength = 6;
        private const int InitTimeRem = 200;
        public const int BonusTimeApple = 100;

        public int length = InitLength;
        public int[,] body = new int[InitLength, 2];

        public int lifetime = 0; //возраст змейки
        public int timerem = InitTimeRem;

        public double score = 0; //счёт змейки
        public int lazyness = 0; //количествво ходов без еды
        public bool lifeline = true; //флаг жив/мёртв


        public int move(int[] dir, int[] apple)
        {
            for (int i = 0; i < length; i++) if (body[0, 0] + dir[0] == body[i, 0] && body[0, 1] + dir[1] == body[i, 1]) return 0;
            if (body[0, 0] + dir[0] == apple[0] && body[0, 1] + dir[1] == apple[1])
            {
                length++;
                int[,] newbody = new int[length, 2];
                newbody[0, 0] = body[0, 0] + dir[0];
                newbody[0, 1] = body[0, 1] + dir[1];
                for (int i = 1; i < length; i++)
                {
                    newbody[i, 0] = body[i - 1, 0];
                    newbody[i, 1] = body[i - 1, 1];
                }
                body = new int[length, 2];
                for (int i = 0; i < length; i++)
                {
                    body[i, 0] = newbody[i, 0];
                    body[i, 1] = newbody[i, 1];
                }
                return 2;
            }
            else
            {
                int[,] newbody = new int[length, 2];
                newbody[0, 0] = body[0, 0] + dir[0];
                newbody[0, 1] = body[0, 1] + dir[1];
                for (int i = 1; i < length; i++)
                {
                    newbody[i, 0] = body[i - 1, 0];
                    newbody[i, 1] = body[i - 1, 1];
                }
                for (int i = 0; i < length; i++)
                {
                    body[i, 0] = newbody[i, 0];
                    body[i, 1] = newbody[i, 1];
                }
                if (body[0, 0] < 0 || body[0, 1] < 0 || body[0, 0] >= GlobalVar.BoardSize || body[0, 1] >= GlobalVar.BoardSize) return 0;
                return 1;
            }
        }

        //Нейросеть
        public const int nsize_i = 24;
        public const int nsize_h_height = 12;
        public const int nsize_h_width = 2;
        public const int nsize_o = 4;

        public float[] input = new float[nsize_i]; //входные нейроны
        public float[,] w_i = new float[nsize_i, nsize_h_height]; //веса на вход
        public float[] b_i = new float[nsize_h_height]; //смещение на вход
        private float[,] hidden = new float[nsize_h_width,nsize_h_height]; //скрытые слои
        private float[,,] w_h = new float[nsize_h_width-1, nsize_h_height, nsize_h_height]; //веса скрытых слоёв
        private float[,] b_h = new float[nsize_h_width-1, nsize_h_height]; //смещения скрытых слоёв
        public float[,] w_o = new float[nsize_h_height, nsize_o]; //веса на выход
        public float[] b_o = new float[nsize_o]; //смещение на выход
        public float[] output = new float[nsize_o]; //выходные нейроны

        private void initbody()
        {
            body[0, 0] = RND.GetInt(0, GlobalVar.BoardSize);
            body[0, 1] = RND.GetInt(0, GlobalVar.BoardSize);
            for (int i = 1; i < length; i++)
            {
                body[i, 0] = body[0, 0];
                body[i, 1] = body[0, 1];
            }
        }
        public Snake()
        {
            length = InitLength;
            body = new int[InitLength, 2];
            lifetime = 0;
            lifeline = true;
            timerem = InitTimeRem;
            initbody();

            for (int i_h = 0; i_h < nsize_h_height; i_h++)
            {
                for (int i_i = 0; i_i < nsize_i; i_i++) w_i[i_i, i_h] = RND.GetFloat(-1, 1);
                b_i[i_h] = RND.GetFloat(-1, 1);
            }
            for (int i_hw = 0; i_hw < nsize_h_width-1; i_hw++)
            {
                for (int i_h2 = 0; i_h2 < nsize_h_height; i_h2++)
                {
                    for (int i_h1 = 0; i_h1 < nsize_h_height; i_h1++) w_h[i_hw, i_h1, i_h2] = RND.GetFloat(-1, 1);
                    b_h[i_hw, i_h2] = RND.GetFloat(-1, 1);
                }
            }
            for (int i_o = 0; i_o < nsize_o; i_o++)
            {
                for (int i_h = 0; i_h < nsize_h_height; i_h++) w_o[i_h, i_o] = RND.GetFloat(-1, 1);
                b_o[i_o] = RND.GetFloat(-1, 1);
            }
        }
        public Snake(Snake Parrent)
        {
            length = InitLength;
            body = new int[InitLength, 2];
            lifetime = 0;
            lifeline = true;
            timerem = InitTimeRem;
            initbody();

            for (int i_h = 0; i_h < nsize_h_height; i_h++)
            {
                for (int i_i = 0; i_i < nsize_i; i_i++) w_i[i_i, i_h] = Parrent.w_i[i_i, i_h];
                b_i[i_h] = Parrent.b_i[i_h];
            }
            for (int i_hw = 0; i_hw < nsize_h_width - 1; i_hw++)
            {
                for (int i_h2 = 0; i_h2 < nsize_h_height; i_h2++)
                {
                    for (int i_h1 = 0; i_h1 < nsize_h_height; i_h1++) w_h[i_hw, i_h1, i_h2] = Parrent.w_h[i_hw, i_h1, i_h2];
                    b_h[i_hw, i_h2] = Parrent.b_h[i_hw, i_h2];
                }
            }
            for (int i_o = 0; i_o < nsize_o; i_o++)
            {
                for (int i_h = 0; i_h < nsize_h_height; i_h++) w_o[i_o, i_h] = Parrent.w_o[i_o, i_h];
                b_o[i_o] = Parrent.b_o[i_o];
            }
            Mutate();
        }
        public Snake(Snake Parrent1, Snake Parrent2)
        {
            length = InitLength;
            body = new int[InitLength, 2];
            lifetime = 0;
            lifeline = true;
            timerem = InitTimeRem;
            initbody();

            for (int i_h = 0; i_h < nsize_h_height; i_h++)
            {
                for (int i_i = 0; i_i < nsize_i; i_i++)
                {
                    if (RND.GetDouble(0, 1) < 0.5f) w_i[i_i, i_h] = Parrent1.w_i[i_i, i_h];
                    else w_i[i_i, i_h] = Parrent2.w_i[i_i, i_h];
                }
                if (RND.GetDouble(0, 1) < 0.5f) b_i[i_h] = Parrent1.b_i[i_h];
                else b_i[i_h] = Parrent2.b_i[i_h];
            }
            for (int i_hw = 0; i_hw < nsize_h_width - 1; i_hw++)
            {
                for (int i_h2 = 0; i_h2 < nsize_h_height; i_h2++)
                {
                    for (int i_h1 = 0; i_h1 < nsize_h_height; i_h1++)
                    {
                        {
                            if (RND.GetDouble(0, 1) < 0.5f) w_h[i_hw, i_h1, i_h2] = Parrent1.w_h[i_hw, i_h1, i_h2];
                            else w_h[i_hw, i_h1, i_h2] = Parrent1.w_h[i_hw, i_h1, i_h2];
                        }
                        if (RND.GetDouble(0, 1) < 0.5f) b_h[i_hw, i_h2] = Parrent1.b_h[i_hw, i_h2];
                        else b_h[i_hw, i_h2] = Parrent1.b_h[i_hw, i_h2];
                    }
                }
            }
            for (int i_o = 0; i_o < nsize_o; i_o++)
            {
                for (int i_h = 0; i_h < nsize_h_height; i_h++)
                {
                    if (RND.GetDouble(0, 1) < 0.5f) w_o[i_h, i_o] = Parrent1.w_o[i_h, i_o];
                    else w_o[i_h, i_o] = Parrent2.w_o[i_h, i_o];
                }
                if (RND.GetDouble(0, 1) < 0.5f) b_o[i_o] = Parrent1.b_o[i_o];
                else b_o[i_o] = Parrent2.b_o[i_o];
            }
            Mutate();
        }

        public void Resurrect()
        {
            length = InitLength;
            body = new int[InitLength, 2];
            score = 0;
            lifetime = 0;
            lazyness = 0;
            lifeline = true;
            timerem = InitTimeRem;
            initbody();
        }
        
        public void Mutate()
        {
            for (int i_h = 0; i_h < nsize_h_height; i_h++)
            {
                for (int i_i = 0; i_i < nsize_i; i_i++) w_i[i_i, i_h] = GlobalFunc.minmax(w_i[i_i, i_h] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
                b_i[i_h] = GlobalFunc.minmax(b_i[i_h] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
            }
            for (int i_hw = 0; i_hw < nsize_h_width - 1; i_hw++)
            {
                for (int i_h2 = 0; i_h2 < nsize_h_height; i_h2++)
                {
                    for (int i_h1 = 0; i_h1 < nsize_h_height; i_h1++) w_h[i_hw, i_h1, i_h2] = GlobalFunc.minmax(w_h[i_hw, i_h1, i_h2] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
                    b_h[i_hw, i_h2] = GlobalFunc.minmax(b_h[i_hw, i_h2] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
                }
            }
            for (int i_o = 0; i_o < nsize_o; i_o++)
            {
                for (int i_h = 0; i_h < nsize_h_height; i_h++) w_o[i_h, i_o] = GlobalFunc.minmax(w_o[i_h, i_o] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
                b_o[i_o] = GlobalFunc.minmax(b_o[i_o] + RND.GetFloat(-1, 1) * GlobalVar.MutationStrength, -1, 1);
            }
        }
        private float Activation(float x) //ReLU
        {
            if (x > 0) return x;
            else return 0;
        }
        public void Think()
        {
            for (int i_h = 0; i_h < nsize_h_height; i_h++)
            {
                hidden[0, i_h] = 0;
                for (int i_i = 0; i_i < nsize_i; i_i++)
                {
                    hidden[0,i_h] += input[i_i] * w_i[i_i, i_h];
                }
                hidden[0,i_h] += b_i[i_h];
                hidden[0,i_h] = Activation(hidden[0,i_h]);
            }

            for (int i_hw = 0; i_hw < nsize_h_width - 1; i_hw++)
            {
                for (int i_h2 = 0; i_h2 < nsize_h_height; i_h2++)
                {
                    hidden[i_hw+1, i_h2] = 0;
                    for (int i_h1 = 0; i_h1 < nsize_h_height; i_h1++)
                    {
                        hidden[i_hw + 1, i_h2] += hidden[i_hw, i_h1] * w_h[i_hw, i_h1, i_h2];
                    }
                    hidden[i_hw + 1, i_h2] += b_h[i_hw, i_h2];
                    hidden[i_hw + 1, i_h2] = Activation(hidden[i_hw, i_h2]);
                }
            }


            for (int i_o = 0; i_o < nsize_o; i_o++)
            {
                output[i_o] = 0;
                for (int i_h = 0; i_h < nsize_h_height; i_h++)
                {
                    output[i_o] += hidden[nsize_h_width-1,i_h] * w_o[i_h, i_o];
                }
                output[i_o] += b_o[i_o];
                output[i_o] = Activation(output[i_o]);
            }
        }

    }
}
