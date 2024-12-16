public class ThucPham : SanPham
{

    private double phiVanChuyen;
    public double PhiVanChuyen
    {
        get { return phiVanChuyen; }
        set { phiVanChuyen = value; }
    }
    public ThucPham(
        string maSanPham,
        string tenSanPham,
        double giaGoc,
        double phiVanChuyen
    ) : base(maSanPham, tenSanPham, giaGoc)
    {
        this.phiVanChuyen = phiVanChuyen;
    }
    public override double TinhGiaBan()
    {
        return GiaGoc + PhiVanChuyen;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Phí vận chuyển: {PhiVanChuyen}%");
    }
}