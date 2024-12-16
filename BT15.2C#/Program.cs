internal class Program
{
    private static void Main(string[] args)
    {
        QuanLySanPham quanLySanPham = new QuanLySanPham();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- Hệ thống quản lý bán hàng ---");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm");
            Console.WriteLine("3. Tính tổng doanh thu dự kiến");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.Write("Vui lòng chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nChọn loại sản phẩm:");
                    Console.WriteLine("1. Điện tử");
                    Console.WriteLine("2. Thời trang");
                    Console.WriteLine("3. Thực phẩm");
                    Console.Write("Nhập lựa chọn: ");

                    string type = Console.ReadLine();

                    Console.Write("Nhập mã sản phẩm: ");
                    string maSanPham = Console.ReadLine();
                    Console.Write("Nhập tên sản phẩm: ");
                    string tenSanPham = Console.ReadLine();
                    Console.Write("Nhập giá gốc: ");
                    double giaGoc = double.Parse(Console.ReadLine());

                    if (type == "1")
                    {
                        Console.Write("Nhập thuế bảo hành (%): ");
                        double thueBaoHanh = double.Parse(Console.ReadLine());
                        quanLySanPham.ThemSanPham(new DienTu(maSanPham, tenSanPham, giaGoc, thueBaoHanh));
                    }
                    else if (type == "2")
                    {
                        Console.Write("Nhập giảm giá (%): ");
                        double giamGia = double.Parse(Console.ReadLine());
                        quanLySanPham.ThemSanPham(new ThoiTrang(maSanPham, tenSanPham, giaGoc, giamGia));
                    }
                    else if (type == "3")
                    {
                        Console.Write("Nhập phí vận chuyển: ");
                        double phiVanChuyen = double.Parse(Console.ReadLine());
                        quanLySanPham.ThemSanPham(new ThucPham(maSanPham, tenSanPham, giaGoc, phiVanChuyen));
                    }
                    else
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                    }
                    break;

                case "2":
                    quanLySanPham.HienThiSanPham();
                    break;

                case "3":
                    double tongDoanhThu = quanLySanPham.TinhTongDoanhThu();
                    Console.WriteLine($"Tổng doanh thu dự kiến: {tongDoanhThu} VND");
                    break;

                case "4":
                    Console.Write("Nhập mã sản phẩm cần xóa: ");
                    string maXoa = Console.ReadLine();
                    quanLySanPham.XoaSanPham(maXoa);
                    break;

                case "5":
                    isRunning = false;
                    Console.WriteLine("Chương trình kết thúc.");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }
}