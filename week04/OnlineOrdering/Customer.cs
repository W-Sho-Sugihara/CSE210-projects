class Customer(string name, Address address)
{
    private string _name = name;
    private Address _address = address;

    public string GetName()
    {
        return _name;
    }
    public bool CustomerInUSA()
    {
        return _address.AddressInUSA();
    }
    public string GetFullAddress()
    {
        return _address.GetFullAddress(); 
    }
}