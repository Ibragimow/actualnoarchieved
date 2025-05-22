namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MaterialProduct
    {
        public int MaterialProductID { get; set; }

        public int? MaterialID { get; set; }

        public int? ProductID { get; set; }

        public double? MaterialQuantity { get; set; }

        public virtual Material Material { get; set; }

        public virtual Product Product { get; set; }
    }
}
