using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastCommonMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(leastCommonMultiple(49, 35));

            Console.ReadLine();
        }

        private static Dictionary<int, int> divisorCounter(List<int> list)
        {
            Dictionary<int, int> dc = new Dictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!dc.ContainsKey(list[i]))
                {
                    dc.Add(list[i], 1);
                }

                else
                    dc[list[i]]++;
            }

            return dc;
        }

        private static int leastCommonMultiple(int v1, int v2)
        {
            int result = 1;

            foreach (var item1 in divisorCounter(primeFactor(v1)))
            {
                foreach (var item2 in divisorCounter(primeFactor(v2)))
                {
                    if (item1.Key == item2.Key)
                    {
                        result *= Convert.ToInt32(Math.Pow(item1.Key, findMinValue(item1.Value, item2.Value)));
                    }
                }
            }

            return result;
        }

        private static int findMinValue(int v1, int v2)
        {
            if (v1 <= v2)
                return v1;
            else
                return v2;
        }

        private static List<int> primeFactor(int v)
        {
            List<int> primeFactors = new List<int>();

            int i = 1;

            while (v != 1)
            {
                int divisor = generatePrimeNumber(i)[generatePrimeNumber(i).Count - 1];

                if (v % divisor == 0)
                {
                    primeFactors.Add(divisor);
                    v /= divisor;
                }

                else
                    i++;
            }

            return primeFactors;
        }

        private static List<int> generatePrimeNumber(int v)
        {
            List<int> numList = new List<int>();

            for (int i = 2; true; i++)
            {
                if (checkPrime(i))
                {
                    if (numList.Count < v)
                        numList.Add(i);
                    else
                        break;
                }
            }

            return numList;
        }

        private static bool checkPrime(int v)
        {
            for (int i = 2; i < v; i++)
            {
                if (v % i == 0)
                    return false;
            }

            return true;
        }
    }
}
