internal class Program
{
    private static void Main(string[] args)
    {
        var quanLyThe = new QuanLyThe();
        var quanLyOTP = new QuanLyOTP();
        var quanLyLichSuGiaoDich = new QuanLyLichSuGiaoDich();
        var menuQuanLyThe = new MenuQuanLyThe(quanLyThe);

        var thanhToanTienMat = new ThanhToanTienMat(quanLyLichSuGiaoDich);
        var thanhToanBangThe = new ThanhToanBangThe(quanLyThe, quanLyLichSuGiaoDich);
        var thanhToanOnline = new ThanhToanOnline(quanLyOTP, quanLyThe, quanLyLichSuGiaoDich);



        while (true)
        {
            // Hiển thị menu
            Console.Clear();
            Console.WriteLine("Chào mừng bạn đến với hệ thống thanh toán:");
            Console.WriteLine("1. Thanh toán bằng tiền mặt");
            Console.WriteLine("2. Thanh toán bằng thẻ");
            Console.WriteLine("3. Thanh toán online");
            Console.WriteLine("4. Xem lịch sử giao dịch");
            Console.WriteLine("5. Quản lý thẻ");
            Console.WriteLine("6. Thoát");


            Console.Write("Vui lòng chọn chức năng: ");
            string luaChon = Console.ReadLine();

            switch (luaChon)
            {
                case "1":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienMat = Convert.ToDouble(Console.ReadLine());
                    thanhToanTienMat.ThanhToan(soTienMat);
                    break;

                case "2":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienThe = Convert.ToDouble(Console.ReadLine());
                    thanhToanBangThe.ThanhToan(soTienThe);
                    break;

                case "3":
                    Console.Write("Nhập số tiền cần thanh toán: ");
                    double soTienOnline = Convert.ToDouble(Console.ReadLine());
                    thanhToanOnline.ThanhToan(soTienOnline);
                    break;

                case "4":
                    Console.WriteLine("Lịch sử giao dịch:");
                    quanLyLichSuGiaoDich.XemLichSu();
                    break;


                case "5":
                    menuQuanLyThe.ShowMenu();
                    break;

                case "6":
                    Console.WriteLine("Thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    break;
            }

            Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
            Console.ReadKey();
        }
    }
}