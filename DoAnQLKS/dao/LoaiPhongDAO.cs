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
    public class LoaiPhongDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<LoaiPhong> getList()
        {
            //SELECT * FROM NhanVien
            List<LoaiPhong> list = db.LoaiPhongs.ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public LoaiPhong getRow(string maloai)
        {
            if (maloai == null)
            {
                return null;
            }
            else
            {
                return db.LoaiPhongs.Find(maloai);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.LoaiPhongs.Count();
        }
        //Thêm mẫu tin
        public void Insert(LoaiPhong lp)
        {
            db.LoaiPhongs.Add(lp);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(LoaiPhong lp)
        {
            db.Entry(lp).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(LoaiPhong lp)
        {
            db.LoaiPhongs.Remove(lp);
            db.SaveChanges();
        }
    }
}
