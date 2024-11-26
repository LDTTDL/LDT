using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh
{
    class HocSinh
    {
        public int MaSo { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh
            List<HocSinh> danhSachHocSinh = new List<HocSinh>
        {
            new HocSinh { MaSo = 1, Ten = "An", Tuoi = 16 },
            new HocSinh { MaSo = 2, Ten = "Anh", Tuoi = 14 },
            new HocSinh { MaSo = 3, Ten = "Thanh", Tuoi = 17 },
            new HocSinh { MaSo = 4, Ten = "Thao", Tuoi = 15 },
            new HocSinh { MaSo = 5, Ten = "Tien", Tuoi = 20 }
        };

            // a. In danh sách toàn bộ học sinh
            Console.WriteLine("Danh sach hoc sinh:");
            foreach (var hocSinh in danhSachHocSinh)
            {
                Console.WriteLine($"Ma so: {hocSinh.MaSo}, Ten: {hocSinh.Ten}, Tuoi: {hocSinh.Tuoi}");
            }

            // b. Tìm và in danh sách các học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\nHoc sinh tuoi tu 15 den 18:");
            var tuoi15Den18 = danhSachHocSinh.Where(hs => hs.Tuoi >= 15 && hs.Tuoi <= 18);
            foreach (var hocSinh in tuoi15Den18)
            {
                Console.WriteLine($"Ma so: {hocSinh.MaSo}, Ten: {hocSinh.Ten}, Tuoi: {hocSinh.Tuoi}");
            }

            // c. Tìm và in học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\nTen bat dau bang 'A':");
            var tenBatDauBangA = danhSachHocSinh.Where(hs => hs.Ten.StartsWith("A"));
            foreach (var hocSinh in tenBatDauBangA)
            {
                Console.WriteLine($"Ma so: {hocSinh.MaSo}, Ten: {hocSinh.Ten}, Tuoi: {hocSinh.Tuoi}");
            }

            // d. Tính tổng tuổi của tất cả học sinh trong danh sách
            Console.WriteLine("\nTong tuoi hoc sinh:");
            int tongTuoi = danhSachHocSinh.Sum(hs => hs.Tuoi);
            Console.WriteLine(tongTuoi);

            // e. Tìm ra học sinh có tuổi lớn nhất
            Console.WriteLine("\nTuoi lon nhat:");
            var hocSinhLonTuoiNhat = danhSachHocSinh.OrderByDescending(hs => hs.Tuoi).First();
            Console.WriteLine($"Ma so: {hocSinhLonTuoiNhat.MaSo}, Ten: {hocSinhLonTuoiNhat.Ten}, Tuoi: {hocSinhLonTuoiNhat.Tuoi}");

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra danh sách sau khi sắp xếp
            Console.WriteLine("\nDanh sach hoc sinh theo tuoi tang dan:");
            var sapXepTheoTuoi = danhSachHocSinh.OrderBy(hs => hs.Tuoi);
            foreach (var hocSinh in sapXepTheoTuoi)
            {
                Console.WriteLine($"Ma so: {hocSinh.MaSo}, Ten: {hocSinh.Ten}, Tuoi: {hocSinh.Tuoi}");
            }
        }
    }

}
