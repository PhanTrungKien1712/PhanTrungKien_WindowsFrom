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
    public class ThanhToanDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<ThanhToanThuePhong> getList()
        {
            List<ThanhToanThuePhong> list = db.ThanhToans.Join(
               db.ThuePhongs,
               ThanhToan => ThanhToan.MaThue,
               ThuePhong => ThuePhong.MaThue,
               (ThanhToan, ThuePhong) => new ThanhToanThuePhong
               {
                   MaTT = ThanhToan.MaTT,
                   MaThue = ThuePhong.MaThue,
                   Tien = ThanhToan.Tien,
                   HTTT = ThanhToan.HTTT,
                   GhiChu = ThanhToan.GhiChu,
                   NgayTT = ThanhToan.NgayTT
               }
               ).ToList();
            return list;
        }
        public List<ThanhToanThuePhong> getList(string mathue)
        {
            //SELECT * FROM SinhVien
            List<ThanhToanThuePhong> list = db.ThanhToans.Join(
                db.ThuePhongs,
               ThanhToan => ThanhToan.MaThue,
               ThuePhong => ThuePhong.MaThue,
               (ThanhToan, ThuePhong) => new ThanhToanThuePhong
               {
                   MaTT = ThanhToan.MaTT,
                   MaThue = ThuePhong.MaThue,
                   Tien = ThanhToan.Tien,
                   HTTT = ThanhToan.HTTT,
                   GhiChu = ThanhToan.GhiChu,
                   NgayTT = ThanhToan.NgayTT
               }
                ).Where(m => m.MaThue == mathue)
                .ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public ThanhToan getRow(string matt)
        {
            if (matt == null)
            {
                return null;
            }
            else
            {
                return db.ThanhToans.Find(matt);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.ThanhToans.Count();
        }
        //Thêm mẫu tin
        public void Insert(ThanhToan tt)
        {
            db.ThanhToans.Add(tt);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(ThanhToan tt)
        {
            db.Entry(tt).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(ThanhToan tt)
        {
            db.ThanhToans.Remove(tt);
            db.SaveChanges();
        }
    }
}
