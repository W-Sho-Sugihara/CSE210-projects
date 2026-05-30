class Order(Customer customer)
{
    private Customer _customer = customer;
    private List<Product> _products = [];
    public void AddProduct(Product item)
    {
        _products.Add(item);
    }
    public float TotalCost()
    {
        float sum = 0;
        foreach(var product in _products)
        {
            sum += product.TotalCost();
        }
        
        return sum + ShippingCost();
    }
    public int ShippingCost()
    {
        if (_customer.CustomerInUSA()){
            return 15;
        }
        else
        {
            return 35;
        }
    }
    public void DisplayPackingLabel()
    {
        foreach (var product in _products)
        {
            Console.WriteLine($"Name: {product.GetName()}, ID: {product.GetId()}");
        }
    }

    public void DisplayShippingLabel()
    {
        Console.WriteLine(_customer.GetName());
        Console.WriteLine(_customer.GetFullAddress());
    }
}