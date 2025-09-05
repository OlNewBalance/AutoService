using System;

namespace AutoService
{
    //Список в общем деталей: двигатель, колесо, фары, карбюратор, радио
    internal class Program()
    {
        public static void Main()
        {
            var game = new AutoServiceCycle();
            game.Start();
        }
    }
}
