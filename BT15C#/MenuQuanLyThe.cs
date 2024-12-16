using System;

public class MenuQuanLyThe
{
    private QuanLyThe quanLyThe;

    public MenuQuanLyThe(QuanLyThe quanLyThe)
    {
        this.quanLyThe = quanLyThe;
    }

    public void ShowMenu()
    {
        Console.WriteLine("1. Thêm thẻ");
        Console.WriteLine("2. Xem danh sách thẻ");
        Console.WriteLine("3. Xóa thẻ");
        Console.WriteLine("4. Quay lại");

        string subChoice = Console.ReadLine();
        switch (subChoice)
        {
            case "1":
                ThemThe();
                break;
            case "2":
                quanLyThe.HienThiDanhSachThe();
                break;
            case "3":
                XoaThe();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                break;
        }
    }

    private void ThemThe()
    {
        Console.Write("Nhập số thẻ: ");
        string soThe = Console.ReadLine();
        Console.Write("Nhập tên chủ thẻ: ");
        string chuThe = Console.ReadLine();
        Console.Write("Nhập ngày hết hạn (MM/YY): ");
        string ngayHetHan = Console.ReadLine();
        Console.Write("Nhập mã PIN: ");
        string maPin = Console.ReadLine();

        TheThanhToan the = new TheThanhToan(soThe, chuThe, ngayHetHan, maPin);
        quanLyThe.ThemThe(the);
    }

    private void XoaThe()
    {
        Console.Write("Nhập số thẻ cần xóa: ");
        string soThe = Console.ReadLine();
        quanLyThe.XoaThe(soThe);
    }
}
