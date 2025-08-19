namespace AutoService
{
    public class AutoElement
    {
        public int elementID { get; set; }
        public string elementName { get; }
        public int elementPrice { get; }

        public AutoElement(int id, int price, string name)
        {
            elementID = id;
            elementPrice = price;
            elementName = name;
        }
    }
}
