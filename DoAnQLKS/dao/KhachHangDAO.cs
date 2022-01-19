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
    public class KhachHangDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<KhachHang> getList()
        {
            //SELECT * FROM KhachHang
            List<KhachHang> list = db.KhachHangs.ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public KhachHang getRow(string makh)
        {
            if (makh == null)
            {
                return null;
            }
            else
            {
                return db.KhachHangs.Find(makh);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.KhachHangs.Count();
        }
        //Thêm mẫu tin
        public void Insert(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(KhachHang kh)
        {
            db.Entry(kh).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(KhachHang kh)
        {
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
        }
    }
}
