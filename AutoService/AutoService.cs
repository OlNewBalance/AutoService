namespace AutoService
{
    public class AutoService
    {
        static Random random = new Random();
        public static int _balance = 100000;
        private const int Penalty = 2500;
        private const int WorkCost = 20000;
        public const int AutoQueue = 10;
        private static int _lastAutoId = 0;
        public static int ToAddRadio = 0;
        public static int ToAddWheel = 0;
        public static int ToAddEngine = 0;
        public static int ToAddHeadlights = 0;
        public static int ToAddCarbureator = 0;

        public static List<AutoElement> elementsStorage = new List<AutoElement>()
        {
            new AutoElement(1, Auto.WheelPrice, "Колесо"),
            new AutoElement(2, Auto.EnginePrice, "Двигатель"),
            new AutoElement(3, Auto.HeadlightsPrice, "Фары"),
            new AutoElement(1, Auto.WheelPrice, "Колесо"),
            new AutoElement(1, Auto.WheelPrice, "Колесо"),
            new AutoElement(4, Auto.RadioPrice, "Радио"),
            new AutoElement(3, Auto.HeadlightsPrice, "Фары"),
            new AutoElement(3, Auto.HeadlightsPrice, "Фары"),
            new AutoElement(2, Auto.EnginePrice, "Двигатель"),
            new AutoElement(5, Auto.CarbureatorPrice, "Карбюратор")
        };

        public static Queue<Auto> QueueOfAuto = new Queue<Auto>();

        public static void AcceptCar(Auto car)
        {
            car.CheckMissingParts(Storage._parts);

            if (car.IsEngineMissing)
            {
                var engine = elementsStorage.FirstOrDefault(e => e.elementID == Auto.EngineId);
                if (engine != null)
                {
                    Console.WriteLine("+ У машины проблемы с двигателем!");
                    elementsStorage.Remove(engine);
                    _balance += Auto.EnginePrice + WorkCost;
                    Console.WriteLine($"Двигатель заменён! +{Auto.EnginePrice + WorkCost} руб.");
                }
                else
                {
                    _balance -= Penalty;
                    Console.WriteLine($"Нет двигателя на складе! Штраф {-Penalty} руб.");
                }
            }

            if (car.IsWheelMissing)
            {
                Console.WriteLine("+ У машины проблемы с колесом!");
                var wheel = elementsStorage.FirstOrDefault(e => e.elementID == Auto.WheelId);
                if (wheel != null)
                {
                    elementsStorage.Remove(wheel);
                    _balance += Auto.WheelPrice + WorkCost;
                    Console.WriteLine($"Колесо заменено! +{Auto.WheelPrice + WorkCost} руб.");
                }
                else
                {
                    _balance -= Penalty;
                    Console.WriteLine($"Нет колеса на складе! Штраф {-Penalty} руб.");
                }
            }

            if (car.IsRadioMissing)
            {
                Console.WriteLine("+ У машины проблемы с радио!");
                var radio = elementsStorage.FirstOrDefault(e => e.elementID == Auto.RadioId);
                if (radio != null)
                {
                    elementsStorage.Remove(radio);
                    _balance += Auto.RadioPrice + WorkCost;
                    Console.WriteLine($"Радио заменено! +{Auto.RadioPrice + WorkCost} руб.");
                }
                else
                {
                    _balance -= Penalty;
                    Console.WriteLine($"Нет радио на складе! Штраф {-Penalty} руб.");
                }
            }

            if (car.IsCarbureatorMissing)
            {
                Console.WriteLine("+ У машины проблемы с карбюратором!");
                var carbureator = elementsStorage.FirstOrDefault(e => e.elementID == Auto.CarbureatorId);
                if (carbureator != null)
                {
                    elementsStorage.Remove(carbureator);
                    _balance += Auto.CarbureatorPrice + WorkCost;
                    Console.WriteLine($"Карбюратор заменён! +{Auto.CarbureatorPrice + WorkCost} руб.");
                }
                else
                {
                    _balance -= Penalty;
                    Console.WriteLine($"Нет карбюратора на складе! Штраф {-Penalty} руб.");
                }
            }

            if (car.IsHeadlightsMissing)
            {
                Console.WriteLine("+ У машины проблемы с фарами!");
                var headlights = elementsStorage.FirstOrDefault(e => e.elementID == Auto.HeadlightsId);
                if (headlights != null)
                {
                    elementsStorage.Remove(headlights);
                    _balance += Auto.HeadlightsPrice + WorkCost;
                    Console.WriteLine($"Фары замены! +{Auto.HeadlightsPrice + WorkCost} руб.");
                }
                else
                {
                    _balance -= Penalty;
                    Console.WriteLine($"Нет фар на складе! Штраф {-Penalty} руб.");
                }
            }
            // Аналогично для других деталей
        }

        public static void AutosRenderer(int countToAdd)
        {
            for (int i = 0; i < countToAdd; i++)
            {
                var newAuto = new Auto(
                    isEngineMissing: random.Next(2) == 1,
                    isCarbureatorMissing: random.Next(2) == 1,
                    isRadioMissing: random.Next(2) == 1,
                    isWheelMissing: random.Next(2) == 1,
                    isHeadlightsMissing: random.Next(2) == 1,
                    autoId: ++_lastAutoId // Теперь ID будут уникальными
                );

                QueueOfAuto.Enqueue(newAuto); // Ключевое добавление!
            }

            Console.WriteLine($"Добавлено машин: {countToAdd}"); // Для отладки
        }

        public static void AutoElementsRenderer(int elementId, int countToAdd)
        {
            if (elementId == Auto.WheelId)
            {
                for (int i = 0; i < countToAdd; i++)
                {
                    var newElement = new AutoElement(1, Auto.WheelPrice, "Колесо");
                }
            }
            else if (elementId == Auto.EngineId)
            {
                for (int i = 0; i < countToAdd; i++)
                {
                    var newElement = new AutoElement(2, Auto.EnginePrice, "Двигатель");
                }
            }
            else if (elementId == Auto.HeadlightsId)
            {
                for (int i = 0; i < countToAdd; i++)
                {
                    var newElement = new AutoElement(3, Auto.HeadlightsPrice, "Фары");
                }
            }
            else if (elementId == Auto.RadioId)
            {
                for (int i = 0; i < countToAdd; i++)
                {
                    var newElement = new AutoElement(4, Auto.RadioPrice, "Радио");
                }
            }
            else if (elementId == Auto.CarbureatorId)
            {
                for (int i = 0; i < countToAdd; i++)
                {
                    var newElement = new AutoElement(5, Auto.CarbureatorPrice, "Карбюратор");
                }
            }
        }

        public static int ExpensesCalc(int addRadio, int addWheel, int addCarbureator, int addEngine,
            int addHeadlights)
        {
            int RadioExpense = Auto.RadioPrice;
            int WheelExpense = Auto.WheelPrice;
            int EngineExpense = Auto.EnginePrice;
            int CarbureatorExpense = Auto.CarbureatorPrice;
            int HeadlightsExpense = Auto.HeadlightsPrice;

            RadioExpense *= addRadio;
            WheelExpense *= addWheel;
            CarbureatorExpense *= addCarbureator;
            EngineExpense *= addEngine;
            HeadlightsExpense *= addHeadlights;

            int expenses = RadioExpense + WheelExpense + CarbureatorExpense + EngineExpense + addHeadlights;
            return expenses;
        }
    }
}
