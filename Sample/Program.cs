using System;

namespace Sample
{
    class Program
    {
        //public static void rec()
        static void Main(string[] args)
        {
            // 盤面を二次元配列で表し、-1で初期化する
            int[][] field = new int[9][];

            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new int[9];
                for (int j = 0; j < field[i].Length; j++)
                {
                    field[i][j] = -1;
                }
            }

        }
    }
}
