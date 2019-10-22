using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Telepromter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var lines = ReadFrom("sampleQuotes.txt");
            foreach (var item in lines)
            {
                Console.Write(item);
                if(!string.IsNullOrWhiteSpace(item)){
                    var pause = Task.Delay(200);
                    pause.Wait();
                }
            }

        }

        static IEnumerable<string> ReadFrom(string file){
            string line;
            using (StreamReader reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(' ');
                    foreach (var item in words)
                    {
                        yield return item + " ";
                    }
                    yield return Environment.NewLine;
                }
            }
        }

    }
}
