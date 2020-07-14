using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistrictAPITest.Models
{
    [Table("store")]
    public partial class Store
    {
        [Key]
        [Column("store_id")]
        public int StoreId { get; set; }
        [Required]
        [Column("store_name")]
        [StringLength(255)]
        public string StoreName { get; set; }
        [Column("district_id")]
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        [InverseProperty("Store")]
        public virtual District District { get; set; }
    }
}
