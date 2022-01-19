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
    public class NhanVienDAO
    {
        QLKSDbContext db = new QLKSDbContext();
        //Trả về danh sách
        public List<NhanVien> getList()
        {
            //SELECT * FROM NhanVien
            List<NhanVien> list = db.NhanViens.ToList();
            return list;
        }
        //Truy vấn và trả về 1 mẫu tin
        public NhanVien getRow(string manv)
        {
            if (manv == null)
            {
                return null;
            }
            else
            {
                return db.NhanViens.Find(manv);
            }
        }
        //Truy vấn và trả về số mẫu tin
        public int getCount()
        {
            return db.NhanViens.Count();
        }
        //Thêm mẫu tin
        public void Insert(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }
        //Sửa mẫu tin
        public void Update(NhanVien nv)
        {
            db.Entry(nv).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa mẫu tin
        public void Delete(NhanVien nv)
        {
            db.NhanViens.Remove(nv);
            db.SaveChanges();
        }
    }
}
