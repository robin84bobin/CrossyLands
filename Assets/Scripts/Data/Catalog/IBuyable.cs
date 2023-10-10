namespace Data
{
    public interface IBuyable
    {
        string Currency { get; }
        int BuyPrice { get; }
    }
}