using System;

class Program
{
    static void Main(string[] args)
    {
        Address homeAddress = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer = new Customer("C-1001", "Alice Johnson", "alice@example.com", homeAddress, 2.50m);

        Product keyboard = new Product("P-101", "Mechanical Keyboard", 79.99m, 10);
        Product mouse = new Product("P-202", "Wireless Mouse", 29.99m, 20);
        Product monitor = new Product("P-303", "27-inch Monitor", 249.99m, 5);

        Order order1 = new Order("O-001", DateTime.Now, customer);
        order1.AddProduct(keyboard, 1);
        order1.AddProduct(mouse, 2);

        Address internationalAddress = new Address("45 Rue de l'Eglise", "Paris", "Ile-de-France", "France");
        Customer customer2 = new Customer("C-2045", "Luis Martin", "luis@example.com", internationalAddress);

        Order order2 = new Order("O-002", DateTime.Now, customer2);
        order2.AddProduct(monitor, 1);
        order2.AddProduct(mouse, 3);

        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total: ${order1.CalculateTotal():0.00}");
        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total: ${order2.CalculateTotal():0.00}");

        CardPayment cardPayment = new CardPayment("TXN-ABC-123");
        order1.ProcessPayment(cardPayment);
        Console.WriteLine($"Order 1 payment successful: {order1.Status}");
    }
}