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
    public class ThanhVienDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<ThanhVien> getList()
        {
            //SELECT * FROM ThanhVien
            List<ThanhVien> list = db.ThanhViens.ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public ThanhVien getRow(int? matv)
        {
            if (matv == null)
            {
                return null;
            }
            else
            {
                return db.ThanhViens.Find(matv);
            }
        }
        public ThanhVien getRow(string username)
        {
            ThanhVien tv = db.ThanhViens
                .Where(m => m.TenDangNhap == username)
                .FirstOrDefault();
            return tv;
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.ThanhViens.Count();
        }
        //Thêm mẫu tin
        public void Insert(ThanhVien tv)
        {
            db.ThanhViens.Add(tv);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(ThanhVien tv)
        {
            db.Entry(tv).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(ThanhVien tv)
        {
            db.ThanhViens.Remove(tv);
            db.SaveChanges();
        }
    }
}
