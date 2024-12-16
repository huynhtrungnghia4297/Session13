using System.Text.Json;

public class QuanLyLichSuGiaoDich
{
    private string filePath = "lichsu_giaodich.json";
    private List<GiaoDich> danhSachGiaoDich;

    public QuanLyLichSuGiaoDich()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            danhSachGiaoDich = JsonSerializer.Deserialize<List<GiaoDich>>(json) ?? new List<GiaoDich>();
        }
        else
        {
            danhSachGiaoDich = new List<GiaoDich>();
        }
    }

    public void LuuGiaoDich(GiaoDich giaoDich)
    {
        danhSachGiaoDich.Add(giaoDich);
        string json = JsonSerializer.Serialize(danhSachGiaoDich, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public void XemLichSu()
    {
        if (danhSachGiaoDich.Count == 0)
        {
            Console.WriteLine("Chưa có giao dịch nào.");
            return;
        }

        Console.WriteLine("Lịch sử giao dịch:");
        foreach (var giaoDich in danhSachGiaoDich)
        {
            Console.WriteLine($"- Số thẻ: {giaoDich.SoThe}, Số tiền: {giaoDich.SoTien}, Loại: {giaoDich.LoaiThanhToan}, Thời gian: {giaoDich.ThoiGian}, Kết quả: {(giaoDich.KetQua ? "Thành công" : "Thất bại")}");
        }
    }
}
