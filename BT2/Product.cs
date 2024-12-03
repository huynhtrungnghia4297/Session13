class Product
{
    public string productID;

    public string productName;

    public double price;

    public int inventoryQty;

    public Product(string productID, string productName, double price, int inventoryQty)
    {
        this.productID = productID;
        this.productName = productName;
        this.price = price;
        this.inventoryQty = inventoryQty;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Product ID: {productID}");
        Console.WriteLine($"Product Name: {productName}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Inventory QTY: {inventoryQty}");

    }

    public double SumProduct()
    {
        return price * inventoryQty;
    }
    public static double SumAll(List<Product> products)
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.SumProduct();
        }
        return total;
    }


}