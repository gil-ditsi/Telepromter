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
            RunTeleprompter().Wait();
        }
        private static async Task RunTeleprompter(){
            var config = new TelePromterConfig();
            var displayTask = ShowTeleprompter(config);

            var speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);
        }
        private static async Task ShowTeleprompter(TelePromterConfig config){
            
            var lines = ReadFrom("sampleQuotes.txt");
            foreach (var item in lines)
            {
                Console.Write(item);
                if(!string.IsNullOrWhiteSpace(item)){
                   await Task.Delay(config.DelayInMilliseconds);
                }
            }
            config.SetDone();
        }
        private static async Task GetInput(TelePromterConfig config){
            Action work = () =>
            {
                do{
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '>')
                    {
                        config.UpdateDelay(-10);
                    }
                    else if (key.KeyChar == '<'){
                        config.UpdateDelay(10);
                    }
                    else if (key.KeyChar == 'X' || key.KeyChar == 'x')
                    {
                        config.SetDone();
                    }
                } while (!config.Done);
            };
            await Task.Run(work);
        }
        static IEnumerable<string> ReadFrom(string file){
            
            string line;
            using (StreamReader reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(' ');
                    var lineLenght = 0;

                    foreach (var item in words)
                    {
                        yield return item + " ";
                        lineLenght += item.Length + 1;
                        if (lineLenght > 70){
                            yield return Environment.NewLine;
                            lineLenght = 0;
                        }
                    }
                    yield return Environment.NewLine;
                }
            }
            
        }

    }
}
