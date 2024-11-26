using System.ComponentModel.DataAnnotations;

namespace DeThiThu.Models
{
    public class KhachHang
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tuoi {  get; set; }
        public string DiaChi {  get; set; }
        public IList<DonHang> DonHangs { get; set; }
    }
}
