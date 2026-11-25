class Address
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _state;
    private readonly string _country;

    public string Street => _street;
    public string City => _city;
    public string State => _state;
    public string Country => _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", System.StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
