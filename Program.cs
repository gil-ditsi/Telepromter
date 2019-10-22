using System;
using System.Collections.Generic;
using System.IO;

namespace Telepromter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var lines = ReadFrom("sampleQuotes.txt");
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

        }

        static IEnumerable<string> ReadFrom(string file){
            string line;
            using (StreamReader reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

    }
}
