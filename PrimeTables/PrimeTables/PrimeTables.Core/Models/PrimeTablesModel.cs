///-----------------------------------------------------------------
///   Description: Prime Tables Model
///-----------------------------------------------------------------

namespace PrimeTables.Core.Model
{
    using System;
    using System.Linq;

    public class PrimeTablesModel : IPrimeTablesModel
    {

        // Build a Sieve of Eratosthenes.
        public bool[] MakeSieve(int max, int count)
        {
            int altCount = 0;
            int decremte = 2;
            int tCount = 0;

            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++) is_prime[i] = true;

            // Cross out multiples.
            for (int i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (is_prime[i])
                {
                    // Knock out multiples of i.
                    for (int j = i * 2; j <= max; j += i)
                    {
                        if (is_prime[j])
                        {
                            decremte++;
                        }

                        is_prime[j] = false;

                        tCount = max + 1 - decremte;

                        if (tCount == count)
                        {
                            return is_prime;
                        }
                    }

                    if (is_prime[i])
                    {
                        altCount++;
                    }

                    if (altCount == count)
                    {
                        return is_prime.Take(i + 1).ToArray();
                    }
                }
            }

            return is_prime;
        }


        public int[,] ReturnTable(int[] primes)
        {
            var count = primes.Length;
            int[,] table = new int[count+1, count+1]; ;
            int start = 0;
            // returns 2d  list, example how it looks can be seen in test

            //headers
            for (int i = 0; i < primes.Length; i++)
            {
              table[0, i+1] = primes[i];
                table[i + 1, 0] = primes[i];
            }


            for (int p = 0; p < primes.Length; p++)
            {
                for (int j = 0; j < primes.Length; j++)
                {
                    if (table[p+1, j+1] == 0)
                    {
                        table[p+1, j+1] = (primes[p] * primes[j]);
                    }

                    if (table[j+1, p+1] == 0)
                    {
                        table[j+1, p+1] = table[p, j];
                    }
                }
            }

            return table;
        }
    }
}
