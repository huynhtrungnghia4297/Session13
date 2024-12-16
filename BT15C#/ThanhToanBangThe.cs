public class ThanhToanBangThe : IThanhToan
{
    private QuanLyThe quanLyThe;
    private QuanLyLichSuGiaoDich lichSuGiaoDich;

    public ThanhToanBangThe(QuanLyThe quanLyThe, QuanLyLichSuGiaoDich lichSuGiaoDich)
    {
        this.quanLyThe = quanLyThe;
        this.lichSuGiaoDich = lichSuGiaoDich;
    }

    public bool ThanhToan(double soTien)
    {
        Console.WriteLine("Nhập số thẻ");
        string soThe = Console.ReadLine();

        Console.WriteLine("Nhập mã PIN");
        string maPin = Console.ReadLine();

        if (quanLyThe.KiemTraMaPin(soThe, maPin))
        {
            Console.WriteLine($"Thanh toán {soTien} bằng thẻ thành công!");
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich
            {
                SoThe = soThe,
                SoTien = soTien,
                LoaiThanhToan = "Thẻ",
                ThoiGian = DateTime.Now,
                KetQua = true
            });
            return true;
        }
        else
        {
            Console.WriteLine("Thanh toán thất bại!");
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich
            {
                SoThe = soThe,
                SoTien = soTien,
                LoaiThanhToan = "Thẻ",
                ThoiGian = DateTime.Now,
                KetQua = false
            });
            return false;
        }

    }
}