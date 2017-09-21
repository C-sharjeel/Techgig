using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace CodeChef
{
    class Program
    {
        static void Main(string[] args)
        {
            //T is number of test cases 
            int T = Convert.ToInt32(Console.ReadLine());

            //Solve for CFRTEST
            Run runner = new CFRTEST();
            
            for (int i = 0; i < T; i++)
            {
                runner.run();
            }
            Console.ReadLine();
        }
    }
}
