using System;

namespace AutoService
{
    //Список в общем деталей: двигатель, колесо, фары, карбюратор, радио
    internal class Program()
    {
        public static void Main()
        {
            Auto auto = new Auto(true,true,true,true,
                true,1);
            Storage storage = new Storage();
            MathCalcs mathCalcs = new MathCalcs();
            AutoService autoService = new AutoService();
            AutoChecker autoChecker = new AutoChecker(autoService, storage);
            var game = new AutoServiceCycle(autoService, autoChecker, mathCalcs);
            game.Start();
        }
    }
}
