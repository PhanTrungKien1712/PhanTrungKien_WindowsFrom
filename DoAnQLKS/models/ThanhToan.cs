namespace DoAnQLKS.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [Key]
        [StringLength(10)]
        public string MaTT { get; set; }

        [StringLength(10)]
        public string MaThue { get; set; }

        public double Tien { get; set; }

        [Required]
        [StringLength(100)]
        public string HTTT { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTT { get; set; }

        public virtual ThuePhong ThuePhong { get; set; }
    }
}
