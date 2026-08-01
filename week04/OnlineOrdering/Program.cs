using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("    ONLINE ORDERING SYSTEM");
        Console.WriteLine("====================================");

        Customer customer = CreateCustomer();
        List<Product> catalog = CreateCatalog();
        Order order = new Order($"ORD-{DateTime.Now:yyyyMMddHHmmss}", DateTime.Now, customer);

        Console.WriteLine();
        Console.WriteLine("Available products:");
        ShowCatalog(catalog);

        bool addMore = true;
        while (addMore)
        {
            Console.WriteLine();
            Console.Write("Select a product number to add (1-4): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int productIndex) || productIndex < 1 || productIndex > catalog.Count)
            {
                Console.WriteLine("Invalid product number. Try again.");
                continue;
            }

            Product selectedProduct = catalog[productIndex - 1];
            Console.Write($"How many {selectedProduct.Name}s do you want to add? ");
            string quantityInput = Console.ReadLine();

            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                continue;
            }

            order.AddProduct(selectedProduct, quantity);
            Console.WriteLine($"Added {quantity} {selectedProduct.Name}(s) to the order.");

            Console.Write("Do you want to add more products? (y/n): ");
            string answer = Console.ReadLine();
            addMore = answer.Trim().ToLower() == "y";
        }

        Console.WriteLine();
        Console.WriteLine("ORDER SUMMARY");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total order cost: ${order.CalculateTotal():0.00}");

        Console.WriteLine();
        Console.WriteLine("Choose payment method:");
        Console.WriteLine("1. Card payment");
        Console.WriteLine("2. Cash payment");

        string paymentOption = Console.ReadLine();
        Payment payment = null;

        if (paymentOption == "1")
        {
            payment = new CardPayment($"TXN-{DateTime.Now:yyyyMMddHHmmss}");
        }
        else if (paymentOption == "2")
        {
            payment = new CashPayment($"CASH-{DateTime.Now:yyyyMMddHHmmss}");
        }
        else
        {
            Console.WriteLine("Invalid option. Defaulting to card payment.");
            payment = new CardPayment($"TXN-{DateTime.Now:yyyyMMddHHmmss}");
        }

        order.ProcessPayment(payment);

        Console.WriteLine();
        Console.WriteLine("Payment result: " + order.Status);
        Console.WriteLine("====================================");
    }

    static Customer CreateCustomer()
    {
        Console.Write("Customer name: ");
        string name = Console.ReadLine();

        Console.Write("Customer email: ");
        string email = Console.ReadLine();

        Console.Write("Street address: ");
        string street = Console.ReadLine();

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State/Province: ");
        string state = Console.ReadLine();

        Console.Write("Country: ");
        string country = Console.ReadLine();

        Address address = new Address(street, city, state, country);
        return new Customer($"C-{DateTime.Now:yyyyMMddHHmmss}", name, email, address);
    }

    static List<Product> CreateCatalog()
    {
        return new List<Product>
        {
            new Product("P-101", "Mechanical Keyboard", 79.99m, 10),
            new Product("P-202", "Wireless Mouse", 29.99m, 20),
            new Product("P-303", "27-inch Monitor", 249.99m, 5),
            new Product("P-404", "USB-C Hub", 39.50m, 15)
        };
    }

    static void ShowCatalog(List<Product> catalog)
    {
        for (int i = 0; i < catalog.Count; i++)
        {
            Product product = catalog[i];
            Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price:0.00} - Stock: {product.Stock}");
        }
    }
}
