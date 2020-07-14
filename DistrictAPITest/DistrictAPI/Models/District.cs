using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistrictAPITest.Models
{
    [Table("district")]
    public partial class District
    {
        public District()
        {
            //SecondarySeller = new HashSet<SecondarySeller>();
            //Store = new HashSet<Store>();
        }

        [Key]
        [Column("district_id")]
        public int DistrictId { get; set; }
        [Required]
        [Column("district_name")]
        [StringLength(255)]
        public string DistrictName { get; set; }
        [Column("seller_id")]
        public int SellerId { get; set; }
        /*
        [ForeignKey(nameof(SellerId))]
        [InverseProperty("District")]
        public virtual Seller Seller { get; set; }
        [InverseProperty("District")]
        public virtual ICollection<SecondarySeller> SecondarySeller { get; set; }
        [InverseProperty("District")]
        public virtual ICollection<Store> Store { get; set; }
        */
    }
}
