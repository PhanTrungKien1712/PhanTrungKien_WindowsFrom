namespace DoAnQLKS.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            ThuePhongs = new HashSet<ThuePhong>();
        }

        [Key]
        [StringLength(10)]
        public string MaP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenP { get; set; }

        [StringLength(10)]
        public string MaLoai { get; set; }

        public double DienTich { get; set; }

        public int GiaThue { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuePhong> ThuePhongs { get; set; }
    }
}
