namespace AutoService
{
    public class AutoService
    {
        private int _lastAutoId = 0;
        private Random _random = new Random();
        
        public const int _penalty = 2500;
        public const int _workCost = 20000;
        public const int AutoQueue = 10;

        Storage _storage;
        public int Balance = 100000;
        public int ToAddRadio = 0;
        public int ToAddWheel = 0;
        public int ToAddEngine = 0;
        public int ToAddHeadlights = 0;
        public int ToAddCarbureator = 0;

        public AutoService()
        {
            _storage = new Storage();
        }


        public List<AutoElement> ElementsStorage = new List<AutoElement>()
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

        public Queue<Auto> QueueOfAuto = new Queue<Auto>();

        public void AutosRenderer(int countToAdd)
        {
            for (int i = 0; i < countToAdd; i++)
            {
                var newAuto = new Auto(
                    isEngineMissing: _random.Next(2) == 1,
                    isCarbureatorMissing: _random.Next(2) == 1,
                    isRadioMissing: _random.Next(2) == 1,
                    isWheelMissing: _random.Next(2) == 1,
                    isHeadlightsMissing: _random.Next(2) == 1,
                    autoId: ++_lastAutoId // Теперь ID будут уникальными
                );

                QueueOfAuto.Enqueue(newAuto); // Ключевое добавление!
            }

            Console.WriteLine($"Добавлено машин: {countToAdd}"); // Для отладки
        }

        public void AutoElementsRenderer(int elementId, int countToAdd)
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
    }
}
