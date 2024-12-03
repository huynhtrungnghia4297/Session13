class Order
{
    public string orderID;
    public string productID;
    public int sellQty;
    public string customerName;
    public bool status;

    public Order(string orderID, string productID, int sellQty, string customerName, bool status)
    {
        this.orderID = orderID;
        this.productID = productID;
        this.sellQty = sellQty;
        this.customerName = customerName;
        this.status = status;
    }

    public void DisplayOrderInfo()
    {
        Console.WriteLine($"Order ID: {orderID}");
        Console.WriteLine($"Product ID: {productID}");
        Console.WriteLine($"Quantity Sold: {sellQty}");
        Console.WriteLine($"Seller Name: {customerName}");
        Console.WriteLine($"Order Status: {status}");

    }
}