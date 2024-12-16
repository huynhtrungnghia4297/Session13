public class ThanhToanTienMat : IThanhToan
{

    private QuanLyLichSuGiaoDich lichSuGiaoDich;

    public ThanhToanTienMat(QuanLyLichSuGiaoDich lichSuGiaoDich)
    {
        this.lichSuGiaoDich = lichSuGiaoDich;
    }
    public bool ThanhToan(double soTien)
    {
        Console.WriteLine($"Thanh toán {soTien} bằng tiền mặt thành công");
        lichSuGiaoDich.LuuGiaoDich(new GiaoDich
        {
            SoThe = "Không áp dụng",
            SoTien = soTien,
            LoaiThanhToan = "Tiền mặt",
            ThoiGian = DateTime.Now,
            KetQua = true
        });

        return true;
    }
}