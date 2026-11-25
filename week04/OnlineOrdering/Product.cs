class Product
{
    private readonly string _name;
    private readonly string _productId;
    private readonly decimal _price;
    private readonly int _quantity;

    public string Name => _name;
    public string ProductId => _productId;
    public decimal Price => _price;
    public int Quantity => _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}
