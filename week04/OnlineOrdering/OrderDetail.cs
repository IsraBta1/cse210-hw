public class OrderDetail
{
    private Product _product;
    private int _quantity;
    private decimal _unitPrice;

    public OrderDetail(Product product, int quantity)
    {
        _product = product;
        _quantity = quantity;
        _unitPrice = product.Price;
    }

    public Product Product => _product;
    public int Quantity => _quantity;
    public decimal UnitPrice => _unitPrice;
    public decimal Subtotal => _unitPrice * _quantity;
}
