using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnQLKS.models;
using System.Data.SqlClient; //Provider SQL Sever

namespace DoAnQLKS.dao
{
    public class ThuePhongDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<ThuePhongKhachHang> getList()
        {
            List<ThuePhongKhachHang> list = db.ThuePhongs.Join(
                db.KhachHangs,                
                ThuePhong => ThuePhong.MaKH,
                KhachHang => KhachHang.MaKH,
                (ThuePhong, KhachHang) => new ThuePhongKhachHang
                {
                    MaThue = ThuePhong.MaThue,
                    TenKH = KhachHang.TenKH,
                    MaP = ThuePhong.MaP,
                    NgayVao = ThuePhong.NgayVao,
                    NgayRa = ThuePhong.NgayRa,
                    DatCoc = ThuePhong.DatCoc,
                }
                ).ToList();
            return list;
        }
        public List<ThuePhongKhachHang> getList(string makh)
        {
            List<ThuePhongKhachHang> list = db.ThuePhongs.Join(
                db.KhachHangs,
                ThuePhong => ThuePhong.MaKH,
                KhachHang => KhachHang.MaKH,
                (ThuePhong, KhachHang) => new ThuePhongKhachHang
                {
                    MaThue = ThuePhong.MaThue,
                    TenKH = KhachHang.TenKH,
                    MaP = ThuePhong.MaP,
                    NgayVao = ThuePhong.NgayVao,
                    NgayRa = ThuePhong.NgayRa,
                    DatCoc = ThuePhong.DatCoc,
                }
                ).Where(m => m.MaKH == makh)
                .ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public ThuePhong getRow(string mathue)
        {
            if (mathue == null)
            {
                return null;
            }
            else
            {
                return db.ThuePhongs.Find(mathue);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.ThuePhongs.Count();
        }
        //Thêm mẫu tin
        public void Insert(ThuePhong tp)
        {
            db.ThuePhongs.Add(tp);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(ThuePhong tp)
        {
            db.Entry(tp).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(ThuePhong tp)
        {
            db.ThuePhongs.Remove(tp);
            db.SaveChanges();
        }
    }
}
