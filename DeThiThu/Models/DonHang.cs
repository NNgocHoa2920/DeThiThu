using System.ComponentModel.DataAnnotations;

namespace DeThiThu.Models
{
    public class DonHang
    {
        [Key]
        public string MaDH {  get; set; }
        public string TenDonHang {  get; set; }
        public DateTime NgayDatHang { get; set; }
        public KhachHang ? KhachHang {  get; set; }

    }
}
