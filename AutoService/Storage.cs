namespace AutoService;

public class Storage()
{
    public Dictionary<int, int> PartsQuantity = new Dictionary<int, int>();
    public List<AutoElement> Parts = new List<AutoElement>();

    public void AddPart(AutoElement part, int quantity = 1)
    {
        if (!Parts.Any(p => p.ElementId == part.ElementId))
        {
            Parts.Add(part);
        }

        if (PartsQuantity.ContainsKey(part.ElementId))
        {
            PartsQuantity[part.ElementId] += quantity;
        }
        else
        {
            PartsQuantity[part.ElementId] = quantity;
        }
    }

    public bool TryGetPart(int partId, out AutoElement part)
    {
        part = Parts.FirstOrDefault(p => p.ElementId == partId);
        if (part == null || !PartsQuantity.ContainsKey(partId) || PartsQuantity[partId] <= 0)
        {
            return false;
        }

        PartsQuantity[partId]--;
        return true;
    }
}
