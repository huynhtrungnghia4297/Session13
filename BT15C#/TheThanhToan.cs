public class TheThanhToan
{
    public string SoThe { get; set; }

    public string ChuThe { get; set; }
    public string NgayHetHan { get; set; }
    public string MaPin { get; set; }

    public TheThanhToan(string soThe, string chuThe, string ngayHetHan, string maPin)
    {
        this.SoThe = soThe;
        this.ChuThe = chuThe;
        this.NgayHetHan = ngayHetHan;
        this.MaPin = maPin;

    }
    public override string ToString()
    {
        return $"Số thẻ: {SoThe}, Chủ thẻ: {ChuThe}, Hạn: {NgayHetHan}";
    }


}