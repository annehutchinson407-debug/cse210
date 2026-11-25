using System.Collections.Generic;
using System.Text;

class Order
{
    private readonly Customer _customer;
    private readonly List<Product> _products;

    public Customer Customer => _customer;
    public IReadOnlyList<Product> Products => _products;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = new List<Product>(products);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("Packing label:");

        foreach (Product product in _products)
        {
            label.AppendLine($"{product.Name} (Product ID: {product.ProductId})");
        }

        return label.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"Shipping label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}
