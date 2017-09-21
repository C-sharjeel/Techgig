using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeChef
{
    public class CFRTEST : Run
    {
        int n;
        int []d;

        public void run(){
            n = Convert.ToInt32(Console.ReadLine());
            d = Array.ConvertAll(Console.ReadLine().Split(' ').ToArray(),Int32.Parse);
            int result = solve(n, d);
            Console.WriteLine(result);
        }

        private int solve(int n, int[] d)
        {
            int result = 0;
            int []count = new int[101];
            //initialize count to 0
            for (int i = 0; i < n; i++)
                count[i]=0;

            //count instance of each day requested
            for (int i = 0; i < n; i++)
                    count[d[i]]++;
            //count only those days which have been requested once
            for (int i = 1; i <= 100; i++)
            {
                if (count[i] >= 1)
                    result++;
            }
  
            return result;
        }
    }
}
