using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample
{
    internal class SudokuSolver
    {

        public static void rec(ref int[,] field, ref List<int[,]> res)
        {
            int emptyi = -1;
            int emptyj = -1;
            for (int i = 0; i < 9 && emptyi == -1; i++)
            {
                for (int j = 0; j < 9 && emptyj == -1; j++)
                {
                    if (field[i,j] == -1)
                    {
                        emptyi = i;
                        emptyj = j;
                        break;
                    }
                }
            }

            if (emptyj == -1 || emptyj == -1)
            {
                // 回答の表示(Mainで表示できなかったため要修正)
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write("{0} ", field[i, j]);
                    }
                    Console.WriteLine();
                }
                res.Add(field);
                return;
            }
            // 空きマスに入れられる数字を探す
            bool[] number = Enumerable.Repeat<bool>(true, 10).ToArray();

            for (int i = 0; i < 9; i++)
            {
                // 同じ列にあるか
                if (field[emptyi, i] != -1) number[field[emptyi, i]] = false;
                // 同じ行にあるか
                if (field[i, emptyj] != -1) number[field[i, emptyj]] = false;

                // 同じブロックにあるか
                int bi = emptyi / 3 * 3 + 1;
                int bj = emptyj / 3 * 3 + 1;
                for (int di = bi - 1; di <= bi + 1; di++)
                {
                    for (int dj = bj - 1; dj <= bj + 1; dj++)
                    {
                        if (field[di, dj] != -1) number[field[di, dj]] = false;
                    }
                }
            }

            for (int v = 1; v <= 9; v++)
            {
                if (!number[v]) continue;
                field[emptyi, emptyj] = v;
                rec(ref field, ref res);
            }

            field[emptyi, emptyj] = -1;
        }

        static void Main(string[] args)
        {
            // 盤面を二次元配列に格納、-1は未定
            int[,] field = new int[9,9];

            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == '*')
                    {
                        field[i,j] = -1;
                        continue;
                    }
                    int num = (int)Char.GetNumericValue(line[j]);
                    field[i,j] = num;   
                }
            }
            List<int[,]> res = new List<int[,]>();
            rec(ref field, ref res);

            int[,] ans = new int[9,9];
            ans = res[0];
            /* for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0} ", ans[i, j]); 
                }
                Console.WriteLine();
            } */
        }
    }
}
