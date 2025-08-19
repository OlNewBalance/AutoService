namespace AutoService;

public class Storage()
{
    public Dictionary<int, int> _partsQuantity = new Dictionary<int, int>();
    public static List<AutoElement> _parts = new List<AutoElement>();

    public void AddPart(AutoElement part, int quantity = 1)
    {
        if (!_parts.Any(p => p.elementID == part.elementID))
        {
            _parts.Add(part);
        }

        if (_partsQuantity.ContainsKey(part.elementID))
        {
            _partsQuantity[part.elementID] += quantity;
        }
        else
        {
            _partsQuantity[part.elementID] = quantity;
        }
    }

    public bool TryGetPart(int partId, out AutoElement part)
    {
        part = _parts.FirstOrDefault(p => p.elementID == partId);
        if (part == null || !_partsQuantity.ContainsKey(partId) || _partsQuantity[partId] <= 0)
        {
            return false;
        }

        _partsQuantity[partId]--;
        return true;
    }
}
