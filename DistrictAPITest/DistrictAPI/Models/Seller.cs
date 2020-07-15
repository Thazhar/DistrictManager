using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistrictAPITest.Models
{
    [Table("seller")]
    public partial class Seller
    {
        public Seller()
        {
            District = new HashSet<District>();
            SecondarySeller = new HashSet<SecondarySeller>();
        }

        [Key]
        [Column("seller_id")]
        public int SellerId { get; set; }
        [Required]
        [Column("seller_name")]
        [StringLength(255)]
        public string SellerName { get; set; }
        
        [InverseProperty("Seller")]
        public virtual ICollection<District> District { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<SecondarySeller> SecondarySeller { get; set; }
    }
}
