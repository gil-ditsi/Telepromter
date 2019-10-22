using System;
namespace Telepromter
{
    internal class TelePromterConfig
    {
        public int DelayInMilliseconds { get; private set; } = 200;

        public bool Done { get; private set; }  
        public void SetDone(){
            this.Done = true;
        }
        public void UpdateDelay(int increment){
            var newDelay = Math.Min(DelayInMilliseconds + increment, 1000);
            newDelay = Math.Max(newDelay, 20);
            DelayInMilliseconds = newDelay;
        }
    }
}