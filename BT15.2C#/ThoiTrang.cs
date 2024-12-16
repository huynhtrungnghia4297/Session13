public class ThoiTrang : SanPham
{
    private double giamGiaTheoMua;
    public double GiamGiaTheoMua
    {
        get { return giamGiaTheoMua; }
        set { giamGiaTheoMua = value; }
    }
    public ThoiTrang(
        string maSanPham,
        string tenSanPham,
        double giaGoc,
        double giamGiaTheoMua
    ) : base(maSanPham, tenSanPham, giaGoc)
    {
        this.giamGiaTheoMua = giamGiaTheoMua;
    }
    public override double TinhGiaBan()
    {
        return this.GiaGoc - (GiaGoc * GiamGiaTheoMua / 100);
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Giảm giá theo mùa: {GiamGiaTheoMua}%");
    }
}