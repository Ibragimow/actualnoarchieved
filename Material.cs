namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            MaterialProducts = new HashSet<MaterialProduct>();
        }

        public int MaterialID { get; set; }

        public int? MaterialTypeID { get; set; }

        public string Type { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public double? Price { get; set; }

        public double? StockQuantity { get; set; }

        public double? MinQuantity { get; set; }

        public double? PackageQuantity { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialProduct> MaterialProducts { get; set; }

        public virtual MaterialType MaterialType { get; set; }
    }
}
