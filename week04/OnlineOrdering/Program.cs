using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - US Customer
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "KB001", 49.99f, 1));
        order1.AddProduct(new Product("Mouse", "MS002", 29.99f, 2));
        order1.AddProduct(new Product("Monitor", "MN003", 199.99f, 1));

        // Display
        Console.WriteLine("=================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("=================================");
        Console.WriteLine("\n-- Shipping Label --");
        order1.DisplayShippingLabel();
        Console.WriteLine("\n-- Packing Label --");
        order1.DisplayPackingLabel();
        Console.WriteLine($"\nTotal Cost: ${order1.TotalCost():F2}");

        // Order 2 - International Customer
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Doe", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "HP001", 79.99f, 1));
        order2.AddProduct(new Product("Webcam", "WC002", 59.99f, 2));

        // Display
        Console.WriteLine("\n=================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("=================================");
        Console.WriteLine("\n-- Shipping Label --");
        order2.DisplayShippingLabel();
        Console.WriteLine("\n-- Packing Label --");
        order2.DisplayPackingLabel();
        Console.WriteLine($"\nTotal Cost: ${order2.TotalCost():F2}");

    }
}