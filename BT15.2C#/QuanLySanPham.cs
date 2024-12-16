public class QuanLySanPham
{
    private List<SanPham> danhSachSanPham = new List<SanPham>();

    public void ThemSanPham(SanPham sanPham)
    {
        if (danhSachSanPham.Any(x => x.MaSanPham == sanPham.MaSanPham))
        {
            Console.WriteLine($"Sản phẩm với mã {sanPham.MaSanPham} đã tồn tại. Không thể thêm!");
            return;
        }

        danhSachSanPham.Add(sanPham);
        Console.WriteLine($"Sản phẩm {sanPham.TenSanPham} (Mã: {sanPham.MaSanPham}) đã được thêm thành công!");

    }

    public void HienThiSanPham()
    {
        if (danhSachSanPham.Count == 0)
        {
            Console.WriteLine("Danh sách sản phẩm trống.");
            return;
        }

        Console.WriteLine("Danh sách sản phẩm:");
        foreach (var sp in danhSachSanPham)
        {
            sp.displayInfo();
            Console.WriteLine("------------");
        }
    }

    public double TinhTongDoanhThu()
    {
        return danhSachSanPham.Sum(sp => sp.TinhGiaBan());
    }

    public void XoaSanPham(string maSanPham)
    {
        var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
        if (sanPham != null)
        {
            danhSachSanPham.Remove(sanPham);
            Console.WriteLine("Sản phẩm đã được xóa thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sản phẩm với mã đã nhập.");
        }
    }
}