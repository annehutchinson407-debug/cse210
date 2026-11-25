using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Address address1 = new Address("123 Maple Street", "Haiku", "Hawaii", "USA");
        Customer customer1 = new Customer("Max Mustermann", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("Canvas", "CV-104", 1.00m, 3),
            new Product("Pencilcase", "PC-208", 0.15m, 2)
        };
        Order order1 = new Order(customer1, products1);

        Address address2 = new Address("45 King Street", "Honolulu", "Hawaii", "USA");
        Customer customer2 = new Customer("Taylor Morgan", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Teapot", "TP-315", 0.20m, 1),
            new Product("LAdder", "LD-420", 12.00m, 2),
            new Product("Freezer", "FZ-522", 2.00m, 1)
        };
        Order order2 = new Order(customer2, products2);

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total price: ${order.GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}
