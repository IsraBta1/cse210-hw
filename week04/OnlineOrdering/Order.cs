using System.Collections.Generic;
using System.Linq;

public class Order
{
    private string _id;
    private DateTime _date;
    private Customer _customer;
    private OrderStatus _status;
    private List<OrderDetail> _details;

    public Order(string id, DateTime date, Customer customer)
    {
        _id = id;
        _date = date;
        _customer = customer;
        _status = OrderStatus.Pending;
        _details = new List<OrderDetail>();
    }

    public string Id => _id;
    public DateTime Date => _date;
    public Customer Customer => _customer;
    public OrderStatus Status => _status;
    public IReadOnlyList<OrderDetail> Details => _details;

    public void AddProduct(Product product, int quantity)
    {
        if (product == null || quantity <= 0)
        {
            return;
        }

        _details.Add(new OrderDetail(product, quantity));
    }

    public decimal CalculateTotal()
    {
        decimal subtotal = _details.Sum(d => d.Subtotal);
        decimal shipping = _customer != null && _customer.LivesInUSA() ? 5m : 35m;
        decimal discount = _customer != null ? _customer.GetDiscount() : 0m;

        return subtotal + shipping - discount;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label\n";
        foreach (var detail in _details)
        {
            label += $"- {detail.Product.Name} ({detail.Product.Id}) x {detail.Quantity}\n";
        }

        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        if (_customer == null || _customer.Address == null)
        {
            return "Shipping Label\nCustomer data unavailable";
        }

        return $"Shipping Label\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }

    public void ProcessPayment(Payment payment)
    {
        if (payment == null)
        {
            return;
        }

        payment.Process(CalculateTotal());
        _status = payment.WasSuccessful ? OrderStatus.Paid : OrderStatus.Pending;
    }

    public void CancelOrder()
    {
        _status = OrderStatus.Cancelled;
    }
}
