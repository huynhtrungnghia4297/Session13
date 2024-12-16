public class ThanhToanOnline : IThanhToan
{
    private QuanLyOTP quanLyOTP;
    private QuanLyThe quanLyThe;
    private QuanLyLichSuGiaoDich lichSuGiaoDich;
    public ThanhToanOnline(QuanLyOTP quanLyOTP, QuanLyThe quanLyThe, QuanLyLichSuGiaoDich lichSuGiaoDich)
    {
        this.quanLyOTP = quanLyOTP;
        this.quanLyThe = quanLyThe;
        this.lichSuGiaoDich = lichSuGiaoDich;

    }

    public bool ThanhToan(double soTien)
    {
        Console.WriteLine($"Bạn đang thanh toán {soTien} qua phương thức online.");

        Console.Write("Nhập số thẻ: ");
        string soThe = Console.ReadLine();

        TheThanhToan theThanhToan = quanLyThe.TimThe(soThe);
        if (theThanhToan == null)
        {
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich { SoThe = soThe, SoTien = soTien, LoaiThanhToan = "Online", ThoiGian = DateTime.Now, KetQua = false });
            Console.WriteLine("Số thẻ không tồn tại!");
            return false;
        }

        Console.Write("Nhập mã PIN: ");
        string maPin = Console.ReadLine();
        if (!quanLyThe.KiemTraMaPin(soThe, maPin))
        {
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich { SoThe = soThe, SoTien = soTien, LoaiThanhToan = "Online", ThoiGian = DateTime.Now, KetQua = false });
            Console.WriteLine("Mã PIN không đúng!");
            return false;
        }

        string otp = quanLyOTP.TaoOTP(soThe);
        Console.WriteLine($"Mã OTP đã được gửi: {otp} (Giả lập gửi qua SMS/Email)");

        Console.Write("Nhập mã OTP: ");
        string nhapOTP = Console.ReadLine();
        if (quanLyOTP.XacThucOTP(soThe, nhapOTP))
        {
            Console.WriteLine("Thanh toán online thành công!");
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich { SoThe = soThe, SoTien = soTien, LoaiThanhToan = "Online", ThoiGian = DateTime.Now, KetQua = true });
            return true;
        }
        else
        {
            Console.WriteLine("Thanh toán thất bại do mã OTP không hợp lệ!");
            lichSuGiaoDich.LuuGiaoDich(new GiaoDich { SoThe = soThe, SoTien = soTien, LoaiThanhToan = "Online", ThoiGian = DateTime.Now, KetQua = false });
            return false;
        }
    }
}