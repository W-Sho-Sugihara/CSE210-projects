using System.Data;

class Address(string street, string city, string stateProvince, string country)       
{
    private string _street = street;
    private string _city = city;
    private string _stateProvince = stateProvince;
    private string _country = country;

    public bool AddressInUSA()
    {
        return _country == "USA";
    }
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}