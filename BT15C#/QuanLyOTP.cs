public class QuanLyOTP
{
    private Dictionary<string, string> danhSachOTP;

    public QuanLyOTP()
    {
        danhSachOTP = new Dictionary<string, string>();
    }

    public string TaoOTP(string soThe)
    {
        string otp = new Random().Next(1000, 9999).ToString();

        if (danhSachOTP.ContainsKey(soThe))
        {
            danhSachOTP[soThe] = otp;
        }
        else
        {
            danhSachOTP.Add(soThe, otp);
        }

        return otp;
    }

    public bool XacThucOTP(string soThe, string otp)
    {
        if (danhSachOTP.ContainsKey(soThe) && danhSachOTP[soThe] == otp)
        {
            danhSachOTP.Remove(soThe);
            return true;
        }
        return false;
    }
}