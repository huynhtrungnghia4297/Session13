using System.Text.Json;

public class QuanLyThe
{
    private string filePath = "danhsachthe.json";

    private List<TheThanhToan> danhSachThe;

    public QuanLyThe()
    {
        if (File.Exists(filePath))
        {
            danhSachThe = LoadFromFile();
        }
        else
        {
            danhSachThe = new List<TheThanhToan>();
        }
    }
    public TheThanhToan TimThe(string soThe)
    {
        return danhSachThe.FirstOrDefault(the => the.SoThe == soThe);
    }
    public void ThemThe(TheThanhToan the)
    {
        var theTonTai = danhSachThe.FirstOrDefault(t => t.SoThe == the.SoThe);
        if (theTonTai != null)
        {
            Console.WriteLine($"Thẻ {the.SoThe} đã tồn tại trong hệ thống. Không thể thêm thẻ trùng.");
        }
        else
        {
            danhSachThe.Add(the);
            Console.WriteLine($"Thẻ {the.SoThe} đã được thêm thành công.");
            SaveToFile();
        }
    }

    public void HienThiDanhSachThe()
    {
        danhSachThe = LoadFromFile();

        Console.WriteLine("Danh sách thẻ:");
        if (danhSachThe.Count == 0)
        {
            Console.WriteLine("Không có thẻ nào trong hệ thống.");
        }
        else
        {
            foreach (var the in danhSachThe)
            {
                Console.WriteLine(the);
            }
        }
    }

    public bool KiemTraMaPin(string soThe, string maPin)
    {
        var isExists = danhSachThe.FirstOrDefault(x => x.SoThe == soThe);
        if (isExists != null && isExists.MaPin == maPin)
        {
            Console.WriteLine("Mã PIN chính xác");
            return true;
        }
        else
        {
            Console.WriteLine("Thẻ không hợp lệ hoặc sai mã PIN");
            return false;
        }
    }

    public void XoaThe(string soThe)
    {
        var the = danhSachThe.FirstOrDefault(x => x.SoThe == soThe);
        if (the != null)
        {
            danhSachThe.Remove(the);
            Console.WriteLine("Thẻ đã được xóa thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy thẻ để xóa!");
        }
    }
    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(danhSachThe, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    private List<TheThanhToan> LoadFromFile()
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TheThanhToan>>(json) ?? new List<TheThanhToan>();
    }
}