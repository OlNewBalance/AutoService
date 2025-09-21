namespace AutoService
{
    public class AutoElement
    {
        public int ElementId;
        public string ElementName;
        public int ElementPrice;

        public AutoElement(int id, int price, string name)
        {
            ElementId = id;
            ElementPrice = price;
            ElementName = name;
        }
    }
}
