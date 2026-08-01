public class Customer
{
    private string _id;
    private string _name;
    private string _email;
    private Address _address;
    private decimal _frequentDiscount;

    public Customer(string id, string name, string email, Address address, decimal frequentDiscount = 0m)
    {
        _id = id;
        _name = name;
        _email = email;
        _address = address;
        _frequentDiscount = frequentDiscount;
    }

    public string Id => _id;
    public string Name => _name;
    public string Email => _email;
    public Address Address => _address;
    public decimal FrequentDiscount => _frequentDiscount;

    public bool LivesInUSA()
    {
        return _address != null && _address.IsInUSA();
    }

    public virtual decimal GetDiscount()
    {
        return _frequentDiscount;
    }
}
