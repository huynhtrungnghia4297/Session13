public class DienTu : SanPham
{
    private double thueBaoHanh;
    public double ThueBaoHanh
    {
        get { return thueBaoHanh; }
        set { thueBaoHanh = value; }
    }
    public DienTu(
        string maSanPham,
        string tenSanPham,
        double giaGoc,
        double thueBaoHanh

    ) : base(maSanPham, tenSanPham, giaGoc)
    {
        this.thueBaoHanh = thueBaoHanh;
    }

    public override double TinhGiaBan()
    {
        return this.GiaGoc + (GiaGoc * thueBaoHanh / 100);
    }
    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Thuế bảo hành: {ThueBaoHanh}%");
    }
}