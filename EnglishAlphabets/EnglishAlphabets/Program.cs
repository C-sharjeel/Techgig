using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishAlphabets
{
    class Program
    {
        static string[][] matrix;
        static string word;
        static int size; 
        static int word_count(string[][] input1,string input2)
        {
            matrix = input1;
            word = input2;
            size = matrix[0].Length-1;

            int wordCount =0;
            #region scan horizontal
            for (int i = 0; i < input1[0].Length; i++)
            {
                bool match = true;
                int word_pos = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    doCheck(i, j, ref word_pos, out match, ref wordCount);
                }
            }
            #endregion

            #region vertical horizontal
            for (int i = 0; i < input1[0].Length; i++)
            {
                bool match = true;
                int word_pos = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    doCheck(j, i, ref word_pos, out match, ref wordCount);
                }
            }
            #endregion

            #region scan diagonal up

            for (int k = size; k >= 0; k--)
            {
                int i = size; int j = k;
                bool match = true;
                int word_pos = 0;
                while(i>=k && j<=size)
                {
                    doCheck(i, j, ref word_pos, out match, ref wordCount);
                    i--; j++;
                }
            }
            for (int k = 0; k <= size-1; k++)
            {
                int i = k; int j = 0;
                bool match = true;
                int word_pos = 0;
                while (i >=0 && j <= k)
                {
                    doCheck(i, j, ref word_pos, out match, ref wordCount);
                    i--; j++;
                }
            }
            #endregion

            #region scan diagonal down
            for (int k = size; k >= 0; k--)
            {
                int i = 0; int j = k;
                bool match = true;
                int word_pos = 0;
                while (i <= size && j <= size)
                {
                    doCheck(i, j, ref word_pos, out match, ref wordCount);
                    i++; j++;
                }
            }
            for (int k = 1; k <=size; k++)
            {
                int i = k; int j = 0;
                bool match = true;
                int word_pos = 0;
                while (i <= size && j <= k)
                {
                    doCheck(i, j, ref word_pos, out match, ref wordCount);
                    i++; j++;
                }
            }
            #endregion
            return wordCount;
        }

        public static void doCheck(int i,int j,ref int word_pos,out bool match,ref int wordCount){
            
            if (word[word_pos].ToString() == matrix[i][j])
            {
                word_pos++;
                match = true;
            }
            else
            {
                match = false;
                word_pos = 0;
                if (word[word_pos].ToString() == matrix[i][j])
                {
                    word_pos++;
                    match = true;
                }
            }
            if (word_pos == word.Length && match)
            {
                wordCount++;
                word_pos = 0;
                match = false;
            }
        }
        static void Main(String[] args)
        {
            int output;
            int ip1_rows = 0;
            int ip1_cols = 0;
            ip1_rows = Convert.ToInt32(Console.ReadLine());
            ip1_cols = Convert.ToInt32(Console.ReadLine());
            string[][] ip1 = new string[ip1_rows][];
            for (int ip1_i = 0; ip1_i < ip1_rows; ip1_i++)
            {
                ip1[ip1_i] = Console.ReadLine().Split(' ');

            }
            string ip2;
            ip2 = Console.ReadLine();
            output = word_count(ip1, ip2);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
