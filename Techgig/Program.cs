using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techgig
{
    class Program
    {
        static void Main(String[] args)
        {
            string output;
            int ip1_size = 0;
            ip1_size = Convert.ToInt32(Console.ReadLine());
            int[] ip1 = new int[ip1_size];
            int ip1_item;
            for (int ip1_i = 0; ip1_i < ip1_size; ip1_i++)
            {
                ip1_item = Convert.ToInt32(Console.ReadLine());
                ip1[ip1_i] = ip1_item;
            }
            output = farms_division(ip1);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static string farms_division(int[] input1)
        {
            string ans = "no";
            int sum = 0;
            foreach (int i in input1)
            {
                sum += i;
                if (i <= 0)
                    return ans = "invalid";
            }

            if (sum % 2 != 0)
                ans = "no";
            else
            {
                int div = sum / 2;
                int subsum =input1[0];
                for (int i = 1; i < input1.Length; i++)
                { 
                    if (subsum == div){
                        ans="yes";
                        break;
                    }
                    else if (subsum > div)
                        subsum -= i;
                    subsum += input1[i];
                }
            }

            return ans;
        }
    }
}
