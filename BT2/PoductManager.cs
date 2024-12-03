using Newtonsoft.Json;

class ProductManager
{
    List<Product> products = new List<Product>();
    List<Order> orders = new List<Order>();


    public string filePath = "product.json";
    private string orderFilePath = "orders.json";
    public ProductManager()
    {

        products.Add(new Product("S001", "Tivi", 2000000, 8));
        products.Add(new Product("S002", "Laptop", 13000000, 6));
        products.Add(new Product("S003", "Tủ Lạnh", 5000000, 7));
        LoadProductsFromFile();
        LoadOrdersFromFile();
    }
    public void LoadProductsFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
        }
        else
        {
            products = new List<Product>();
        }
    }
    public void LoadOrdersFromFile()
    {
        if (File.Exists(orderFilePath))
        {
            string json = File.ReadAllText(orderFilePath);
            orders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
        }
        else
        {
            orders = new List<Order>();
        }
    }
    public void saveData()
    {
        try
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }
    //Thêm mới sản phẩm
    public void AddProduct()
    {

        Console.WriteLine("Enter Product ID:");
        string product_ID = Console.ReadLine();

        Console.WriteLine("Enter Product Name:");
        string product_Name = Console.ReadLine();

        Console.WriteLine("Enter Price Product:");
        double price_Product = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Inventory Qty:");
        int inventory_Qty = Convert.ToInt32(Console.ReadLine());



        Product product = new Product(product_ID, product_Name, price_Product, inventory_Qty);

        var check = products.FirstOrDefault(s => s.productID == product.productID);
        if (check != null)
        {
            Console.WriteLine("Product with this ID already exists in the list. Please check again.");
            return; // Không cần throw exception, chỉ cần return
        }

        products.Add(product);
        saveData();
        Console.WriteLine($"Student {product.productName} added to the list.");
    }

    //Tìm kiếm sản phẩm theo tên in ra danh thông tin sản phẩm.
    public void SearchProductByName()
    {
        Console.WriteLine("Enter Product Name:");
        string _productName = Console.ReadLine();


        var product = products.FirstOrDefault(s => s.productName.Contains(_productName));
        if (product != null)
        {
            product.DisplayInfo();
        }
        else
        {
            Console.WriteLine($"Student with name {_productName} not found.");
        }
    }

    //Cập nhật sản phẩm 
    public void UpdateProduct()
    {
        Console.WriteLine("Enter Product ID:");
        string _productID = Console.ReadLine();


        var product = products.FirstOrDefault(s => s.productID == _productID);
        if (product != null)
        {
            Console.WriteLine($"Update product for {product.productName}:");
            Console.Write("New Price: ");
            product.price = double.Parse(Console.ReadLine());
            Console.Write("New Inventory Qty: ");
            product.inventoryQty = Convert.ToInt32(Console.ReadLine());

            saveData();
            Console.WriteLine("Product updated successfully!");
        }
        else
        {
            Console.WriteLine($"Product with ID {_productID} not found.");
        }
    }
    //Xóa sản phẩm trong danh sách
    public void DeleteProduct()
    {

        Console.WriteLine("Enter Product ID:");
        string _productID = Console.ReadLine();

        var product = products.FirstOrDefault(s => s.productID == _productID);
        if (product != null)
        {
            products.Remove(product);
            saveData();
            Console.WriteLine($"Product with ID {_productID} has been removed.");
        }
        else
        {
            Console.WriteLine($"Product with ID {_productID} not found.");
        }
    }
    // Hiển thị tất cả sản phẩm cùng tổng giá trị kho hàng
    public void DisplayAllProduct()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No data file found.");
                return;
            }

            var productJson = File.ReadAllText(filePath);
            products = JsonConvert.DeserializeObject<List<Product>>(productJson) ?? new List<Product>();

            if (products.Count == 0)
            {
                Console.WriteLine("No products in the list.");
                return;
            }

            Console.WriteLine("All Products:");
            foreach (var product in products)
            {
                product.DisplayInfo();
                Console.WriteLine();
            }
            Console.WriteLine($"Total value : {Product.SumAll(products)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

    //Hiển thị sản phẩm theo giá bán tăng dần (dùng order by)
    public void DisplayProductsSortedByPrice()
    {

        var productJson = File.ReadAllText(filePath);
        products = JsonConvert.DeserializeObject<List<Product>>(productJson) ?? new List<Product>();


        var sortedProducts = products.OrderBy(s => s.price).ToList();
        Console.WriteLine("Products sorted by price:");
        foreach (var product in sortedProducts)
        {
            product.DisplayInfo();
            Console.WriteLine();
        }
    }

    //Hiển thị sản phẩm theo tên (dùng order by)
    public void DisplayProductsSortedByName()
    {

        var productJson = File.ReadAllText(filePath);
        products = JsonConvert.DeserializeObject<List<Product>>(productJson) ?? new List<Product>();


        var sortedProducts = products.OrderBy(s => s.productName).ToList();
        Console.WriteLine("Products sorted by name:");
        foreach (var product in sortedProducts)
        {
            product.DisplayInfo();
            Console.WriteLine();
        }
    }

    // Hiển thị danh sách sinh viên theo tên cuối
    public void DisplayStudentsSortedByLastName()
    {

        var productJson = File.ReadAllText(filePath);
        products = JsonConvert.DeserializeObject<List<Product>>(productJson) ?? new List<Product>();


        var sortedProducts = products.OrderBy(s => s.productName.Split(' ').Last()).ToList();
        Console.WriteLine("Products sorted by name:");
        foreach (var product in sortedProducts)
        {
            product.DisplayInfo();
            Console.WriteLine();
        }
    }




    public void saveDataOrder()
    {
        try
        {
            string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(orderFilePath, json);
            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    //Tạo Order
    public void AddOrder()
    {
        Console.Write("Enter Order ID: ");
        string orderID = Console.ReadLine();

        Console.Write("Enter Product ID: ");
        string productID = Console.ReadLine();

        Console.Write("Enter Quantity Sold: ");
        int quantitySold = int.Parse(Console.ReadLine());

        Console.Write("Enter Seller Name: ");
        string sellerName = Console.ReadLine();

        var product = products.FirstOrDefault(p => p.productID == productID);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        var order = new Order(orderID, productID, quantitySold, sellerName, status: false);
        orders.Add(order);
        saveDataOrder();
        Console.WriteLine("Order added successfully but not confirmed yet!");
    }
    //Xóa đơn hàng trong danh sách
    public void DeleteOrder()
    {

        Console.WriteLine("Enter Order ID:");
        string _orderID = Console.ReadLine();

        var order = orders.FirstOrDefault(s => s.orderID == _orderID);
        if (order != null)
        {
            if (order.status)
            {
                Console.WriteLine("Cannot delete the order because it has been confirmed.");
                return;
            }
            else
            {
                orders.Remove(order);
                saveDataOrder();
                Console.WriteLine($"Order with ID {_orderID} has been removed.");
            }

        }
        else
        {
            Console.WriteLine($"Order with ID {_orderID} not found.");
        }
    }
    //Update Orderr
    public void UpdateOrderStatus()
    {
        Console.Write("Enter Order ID to confirm: ");
        string orderID = Console.ReadLine();

        var order = orders.FirstOrDefault(o => o.orderID == orderID);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        if (order.status)
        {
            Console.WriteLine("Order is already confirmed.");
            return;
        }

        var product = products.FirstOrDefault(p => p.productID == order.productID);
        if (product == null)
        {
            Console.WriteLine("Product not found for this order.");
            return;
        }

        if (product.inventoryQty >= order.sellQty)
        {
            product.inventoryQty -= order.sellQty;
            order.status = true;
            saveDataOrder();
            saveData();
            Console.WriteLine("Order confirmed and inventory updated successfully!");
        }
        else
        {
            Console.WriteLine($"Not enough inventory for product {product.productName}. Available: {product.inventoryQty}, Requested: {order.sellQty}");
        }
    }
    //show all orders
    public void DisplayAllOrder()
    {
        try
        {
            if (!File.Exists(orderFilePath))
            {
                Console.WriteLine("No data file found.");
                return;
            }

            var orderJson = File.ReadAllText(orderFilePath);
            orders = JsonConvert.DeserializeObject<List<Order>>(orderJson) ?? new List<Order>();

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders in the list.");
                return;
            }

            Console.WriteLine("All Orders:");
            foreach (var order in orders)
            {
                order.DisplayOrderInfo();
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

}