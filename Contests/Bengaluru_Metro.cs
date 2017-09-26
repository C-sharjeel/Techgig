using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contests
{
    public class Bengaluru_Metro : Runner
    {
        const int L1 = 0;
        const int L2 = 1;
        const int Cost = 2;
        int numOfLocalities;
        int numOfCommAgreements;
        int numOfRows;
        int numOfColumns;
        int[][] Agreements;
        

        public int Run()
        {
            int result = 0;
            numOfLocalities = Convert.ToInt32(Console.ReadLine());
            numOfCommAgreements = Convert.ToInt32(Console.ReadLine());
            numOfRows = Convert.ToInt32(Console.ReadLine());
            numOfColumns = Convert.ToInt32(Console.ReadLine());

            //Check for boundaries
            if (numOfLocalities < 3 || numOfLocalities > 1000)
                return 0;

            Agreements = new int[numOfRows][];
            for (int i = 0; i < numOfRows; i++)
            {
                Agreements[i] = new int[numOfColumns];
                Agreements[i] = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            }

            result = solve(Agreements, numOfRows, numOfLocalities, numOfCommAgreements);
            Console.WriteLine(result);
            return result;
        }

        private int solve(int[][] Agreements, int numOfRows, int numOfLocalities, int numOfCommAgreements)
        {
            int result = 0;
            int[][] CostGraph = new int[numOfLocalities+1][];
            
            //There should be least num of agreements between localities to form one complete route
            if (numOfCommAgreements < numOfLocalities - 1)
                return result = 0;

            //Initialize with no connection value of -1
            for (int i = 0; i < numOfLocalities + 1; i++)
            {
                CostGraph[i] = new int[numOfLocalities + 1];
                for (int j = 0; j < numOfLocalities + 1; j++)
                    CostGraph[i][j] = -1;
            }
            //Assign the costs in graph nodes as per provided inputs
            for (int i = 0; i < numOfLocalities; i++)
            {
                CostGraph[Agreements[i][L1]][Agreements[i][L2]] = Agreements[i][Cost];
                CostGraph[Agreements[i][L2]][Agreements[i][L1]] = Agreements[i][Cost];
            }
             
            
            //Sort (Insertion sort)
            for (int i = 1; i < numOfRows; i++)
            {
                int[] key = Agreements[i];
                int j = i - 1;
                while(j>0 && Agreements[j][Cost] > key[Cost])
                {
                    Agreements[j + 1] = Agreements[j];
                    j--;
                }
                Agreements[j + 1] = key; 
            }
            
            //Maintaining this array to check for cycles
            int[] VerticeCount = new int[numOfLocalities + 1];
            for (int i = 0; i < VerticeCount.Length; i++)
                VerticeCount[i] = 0;

            //Applying minimum cost path algorithm on the generated cost-graph (Kruskal's algorithm)
            int cost = 0;
            int startVertice = Agreements[0][L1];
            int endVertice = 0;
            for (int i = 0; i < Agreements.Length; i++)
            {
                cost += Agreements[i][Cost];
                VerticeCount[Agreements[i][L1]]++;
                VerticeCount[Agreements[i][L2]]++;
                if()
            }

                return result;
        }
    }
}
