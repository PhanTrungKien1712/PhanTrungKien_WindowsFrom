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
    public class PhongDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<PhongLoaiPhong> getList()
        {
            List<PhongLoaiPhong> list = db.Phongs.Join(
                db.LoaiPhongs,
                Phong => Phong.MaLoai,
                LoaiPhong => LoaiPhong.MaLoai,
                (Phong, LoaiPhong) => new PhongLoaiPhong
                {
                    MaP = Phong.MaP,
                    TenP = Phong.TenP,
                    TenLoai = LoaiPhong.TenLoai,
                    DienTich = Phong.DienTich,
                    GiaThue = Phong.GiaThue
                }
                ).ToList();
            return list;
        }

        public List<PhongLoaiPhong> getList(string maloai)
        {
            List<PhongLoaiPhong> list = db.Phongs.Join(
                db.LoaiPhongs,
                Phong => Phong.MaLoai,
                LoaiPhong => LoaiPhong.MaLoai,
                (Phong, LoaiPhong) => new PhongLoaiPhong
                {
                    MaP = Phong.MaP,
                    TenP = Phong.TenP,
                    MaLoai = LoaiPhong.MaLoai,
                    TenLoai = LoaiPhong.TenLoai,
                    DienTich = Phong.DienTich,
                    GiaThue = Phong.GiaThue
                }
                ).Where(m => m.MaLoai == maloai)
                .ToList();
            return list;
        }

        //Truy vấn và trả về 1 mẫu tin
        public Phong getRow(string map)
        {
            if (map == null)
            {
                return null;
            }
            else
            {
                return db.Phongs.Find(map);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.Phongs.Count();
        }
        //Thêm mẫu tin
        public void Insert(Phong p)
        {
            db.Phongs.Add(p);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(Phong p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(Phong p)
        {
            db.Phongs.Remove(p);
            db.SaveChanges();
        }
    }
}
