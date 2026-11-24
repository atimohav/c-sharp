using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Threading;

namespace Snake_Genetic
{
    public static class GlobalFunc
    {
        public static float minmax(float x, float min, float max)
        {
            return Math.Max(min, Math.Min(x, max));
        }
    }
    public static class GlobalVar
    {
        public static int BoardSize = 15;
        public static int Scale = 20;
        public static float MutationChance = 0.1f;
        public static float MutationStrength = 0.1f;
        public static int Mu = 15;
        public static int Lambda = 225;
        public static int LazyTime = 300;
        public static int WorkTime = 100;
        public static int MaxSpeed = 1000;
        public static int MinSpeed = 1;
        public static int CurSpeed = 1;
        public static int CountsPerTick = 1;
        public static int CurSnake = 0;
        public static bool ShowAllSnakes = false;
    }

    public static class RND
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> random = new ThreadLocal<Random>(
            () => new Random(Interlocked.Increment(ref seed)));

        public static int GetInt(int min, int maxEx) =>
            random.Value.Next(min, maxEx);

        public static float GetFloat(float min, float max) =>
            (float)random.Value.NextDouble() * (max - min) + min;

        public static double GetDouble(double min, double max) =>
            random.Value.NextDouble() * (max - min) + min;

        public static double Gaussian(float mean, float stdDev)
        {
            double uniform1 = 1.0 - GetDouble(0, 1);
            double uniform2 = 1.0 - GetDouble(0, 1);
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(uniform1)) *
                                   Math.Sin(2.0 * Math.PI * uniform2);
            return mean + stdDev * randStdNormal;
        }
    }

    public class SnakeComparerScore : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Snake a = (Snake)y;
            Snake b = (Snake)x;
            return new CaseInsensitiveComparer().Compare(a.score, b.score);
        }
    }
    public class SnakeComparerApple : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Snake a = (Snake)y;
            Snake b = (Snake)x;
            return new CaseInsensitiveComparer().Compare(a.length, b.length);
        }
    }



    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Screen());
        }
    }
}
