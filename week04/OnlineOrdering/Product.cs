class Product(string name, string id, float price, int quantity)
{
    private string _name = name;
    private string _id = id;
    private float _price = price;
    private int _quantity = quantity;

    public float TotalCost()
    {
        return _price * _quantity;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetId()
    {
        return _id;
    }
    public float GetPrice()
    {
        return _price;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
}