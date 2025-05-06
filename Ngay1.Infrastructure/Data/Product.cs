namespace Ngay1.Infrastructure.Data
{
	public abstract class SanPham
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Ten { get; set; } = string.Empty;
		public bool KichHoat { get; set; } = true;

		public abstract string LayThongTin();
	}

	public class DienThoai : SanPham
	{
		public double? KhoiLuong { get; set; }
		public override string LayThongTin() => $"[Điện thoại] {Ten} - {KhoiLuong}kg";
	}

	public class PhanMem : SanPham
	{
		public double? DungLuongMB { get; set; }
		public override string LayThongTin() => $"[Phần mềm] {Ten} - {DungLuongMB}MB";
	}
}