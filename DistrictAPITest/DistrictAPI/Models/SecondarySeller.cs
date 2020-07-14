using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistrictAPITest.Models
{
    [Table("secondary_seller")]
    public partial class SecondarySeller
    {
        [Column("seller_id")]
        public int SellerId { get; set; }
        [Column("district_id")]
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        [InverseProperty("SecondarySeller")]
        public virtual District District { get; set; }
        [ForeignKey(nameof(SellerId))]
        [InverseProperty("SecondarySeller")]
        public virtual Seller Seller { get; set; }
    }
}
