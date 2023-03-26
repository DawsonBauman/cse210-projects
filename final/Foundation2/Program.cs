using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Widget", 1234, 10.99, 3);
        Product product2 = new Product("Gizmo", 5678, 5.99, 2);

        // Create some customers
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 High St", "Othercity", "BC", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create some orders
        Order order1 = new Order(new List<Product> { product1, product2 }, customer1);
        Order order2 = new Order(new List<Product> { product2 }, customer2);

        // Display packing labels, shipping labels, and total cost for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total cost: $" + order1.CalculateTotalCost().ToString("F2"));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total cost: $" + order2.CalculateTotalCost().ToString("F2"));

        Console.ReadLine();
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;

        foreach (Product product in products)
        {
            totalCost += product.Price * product.Quantity;
        }

        if (customer.IsUSA())
        {
            totalCost += 5.0;
        }
        else
        {
            totalCost += 35.0;
        }

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in products)
        {
            packingLabel += product.Name + " (" + product.ProductId + ")\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "";

        shippingLabel += customer.Name + "\n";
        shippingLabel += customer.Address.GetFullAddress() + "\n";

        return shippingLabel;
    }
}

class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name { get { return name; } }
    public int ProductId { get { return productId; } }
    public double Price { get { return price; } }
    public int Quantity { get { return quantity; } }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name { get { return name; } }
    public Address Address { get { return address; } }

    public bool IsUSA()
    {
        return address.IsUSA();
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
{
    this.streetAddress = streetAddress;
    this.city = city;
    this.stateProvince = stateProvince;
    this.country = country;
}

public string StreetAddress { get { return streetAddress; } }
public string City { get { return city; } }
public string StateProvince { get { return stateProvince; } }
public string Country { get { return country; } }

public string GetFullAddress()
{
    return streetAddress + ", " + city + ", " + stateProvince + ", " + country;
}

public bool IsUSA()
{
    return country == "USA";
}
}
