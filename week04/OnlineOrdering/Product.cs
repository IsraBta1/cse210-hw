public class Product
{
    private string _id;
    private string _name;
    private decimal _price;
    private int _stock;

    public Product(string id, string name, decimal price, int stock)
    {
        _id = id;
        _name = name;
        _price = price;
        _stock = stock;
    }

    public string Id => _id;
    public string Name => _name;
    public decimal Price => _price;
    public int Stock => _stock;

    public bool ReduceStock(int quantity)
    {
        if (quantity <= 0)
        {
            return false;
        }

        if (_stock < quantity)
        {
            return false;
        }

        _stock -= quantity;
        return true;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity > 0)
        {
            _stock += quantity;
        }
    }
}
