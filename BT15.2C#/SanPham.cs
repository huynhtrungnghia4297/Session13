public abstract class SanPham
{
    private string maSanPham;
    public string MaSanPham
    {
        get { return maSanPham; }
        set { maSanPham = value; }
    }

    private string tenSanPham;
    public string TenSanPham
    {
        get { return tenSanPham; }
        set { tenSanPham = value; }
    }

    private double giaGoc;
    public double GiaGoc
    {
        get { return giaGoc; }
        set { giaGoc = value; }
    }

    public SanPham(string maSanPham, string tenSanPham, double giaGoc)
    {
        this.maSanPham = maSanPham;
        this.tenSanPham = tenSanPham;
        this.giaGoc = giaGoc;
    }
    public abstract double TinhGiaBan();

    public virtual void displayInfo()
    {
        Console.WriteLine($"Mã Sản Phẩm: {maSanPham}");
        Console.WriteLine($"Tên Sản Phẩm: {tenSanPham}");
        Console.WriteLine($"Giá gốc: {giaGoc} VND");
        Console.WriteLine($"Giá bán: {TinhGiaBan()} VND");
    }
}
