namespace AutoService
{
    public class Auto
    {
        public List<AutoElement>
            elementsInAuto = new List<AutoElement>(); // Тут должны быть перечислены ВСЕ детали -

        // - которые есть в машине, та деталь которую надо будет заменить на сервисе, написана в List не будет!
        public bool IsEngineMissing { get; set; }
        public bool IsRadioMissing { get; set; }
        public bool IsWheelMissing { get; set; }
        public bool IsHeadlightsMissing { get; set; }
        public bool IsCarbureatorMissing { get; set; }
        public static int AutoId { get; set; }

        public Auto(bool isEngineMissing, bool isCarbureatorMissing, bool isRadioMissing, bool isWheelMissing,
            bool isHeadlightsMissing, int autoId)
        {
            IsEngineMissing = isEngineMissing;
            IsRadioMissing = isRadioMissing;
            IsWheelMissing = isWheelMissing;
            IsHeadlightsMissing = isHeadlightsMissing;
            IsCarbureatorMissing = isCarbureatorMissing;
            AutoId = autoId;
        }

        // Константы для ID деталей
        public const int EngineId = 2;
        public const int RadioId = 4;
        public const int WheelId = 1;
        public const int CarbureatorId = 5;
        public const int HeadlightsId = 3;

        public const int EnginePrice = 30000;
        public const int RadioPrice = 7000;
        public const int WheelPrice = 3000;
        public const int CarbureatorPrice = 24000;
        public const int HeadlightsPrice = 15000;


        public void CheckMissingParts(List<AutoElement> existingParts)
        {
            // Проверяем отсутствие каждой критичной детали
            IsEngineMissing = !elementsInAuto.Exists(p => p.elementID == EngineId);
            IsRadioMissing = !elementsInAuto.Exists(p => p.elementID == RadioId);
            IsWheelMissing = !elementsInAuto.Exists(p => p.elementID == WheelId);
            IsCarbureatorMissing = !elementsInAuto.Exists(p => p.elementID == CarbureatorId);
            IsHeadlightsMissing = !elementsInAuto.Exists(p => p.elementID == HeadlightsId);
        }
    }
}
