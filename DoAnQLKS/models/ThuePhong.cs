namespace DoAnQLKS.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuePhong")]
    public partial class ThuePhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuePhong()
        {
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        [StringLength(10)]
        public string MaThue { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(10)]
        public string MaP { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVao { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayRa { get; set; }

        public double DatCoc { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Phong Phong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
