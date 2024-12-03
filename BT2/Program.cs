internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager manager = new ProductManager();

        bool isRuning = true;
        while (isRuning)
        {
            Console.WriteLine("\n----------Product Manager----------");
            Console.WriteLine("1. Thêm sản phẩm:");
            Console.WriteLine("2. Tìm kiếm sản phẩm theo tên");
            Console.WriteLine("3. Cập nhật thông tin sản phẩm");
            Console.WriteLine("4. Xóa sản phẩm khỏi danh sách");
            Console.WriteLine("5. Hiển thị danh sách sản phẩm kèm tổng giá trị kho hàng");
            Console.WriteLine("6. Hiển thị sản phẩm theo giá bán tăng dần");
            Console.WriteLine("7. Hiển thị sản phẩm theo tên sản phẩm");
            Console.WriteLine("8. Hiển thị sản phẩm theo tên cuối của sản phẩm");
            Console.WriteLine("9. Hiển thị tất cả Orders");
            Console.WriteLine("10. Tạo order đơn hàng");
            Console.WriteLine("11. Xác nhận đơn hàng");
            Console.WriteLine("12. Xóa đơn hàng");
            Console.WriteLine("13. Exit");



            Console.WriteLine("Please enter your number:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    // Thêm sản phẩm
                    manager.AddProduct();
                    break;

                case 2:
                    // Tìm kiếm sản phẩm theo tên
                    Console.WriteLine("Search product by name:");
                    manager.SearchProductByName();
                    break;

                case 3:
                    // Cập nhật thông tin sản phẩm
                    Console.WriteLine("Update product scores:");
                    manager.UpdateProduct();

                    break;


                case 4:
                    // Xóa product
                    Console.WriteLine("Delete product:");
                    manager.DeleteProduct();
                    break;

                case 5:
                    // Hiển thị danh sách sản phẩm kèm tổng giá trị kho hàng
                    manager.DisplayAllProduct();
                    break;


                case 6:

                    // Hiển thị sản phẩm theo giá bán tăng dần
                    manager.DisplayProductsSortedByPrice();
                    break;

                case 7:
                    // Hiển thị sản phẩm theo tên sản phẩm
                    manager.DisplayProductsSortedByName();
                    break;

                case 8:
                    // Hiển thị sản phẩm theo tên cuối của sản phẩm
                    manager.DisplayStudentsSortedByLastName();
                    break;

                case 9:
                    //Hiển thị tất cả Orders
                    manager.DisplayAllOrder();
                    break;

                case 10:
                    //Tạo order đơn hàng
                    Console.WriteLine("Add order:");

                    manager.AddOrder();
                    break;

                case 11:
                    //Xác nhận đơn hàng
                    Console.WriteLine("Update order:");

                    manager.UpdateOrderStatus();
                    break;

                case 12:
                    //Xóa đơn hàng
                    Console.WriteLine("Delete order:");

                    manager.DeleteOrder();
                    break;
                case 13:

                    isRuning = false;
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter from 1-9");
                    break;
            }
        }
    }
}