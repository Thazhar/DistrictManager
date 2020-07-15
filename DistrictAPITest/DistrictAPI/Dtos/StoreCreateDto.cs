using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class StoreCreateDto
    {
        [Required]
        [Column("store_name")]
        [StringLength(255)]
        public string StoreName { get; set; }
        [Column("district_id")]
        public int DistrictId { get; set; }
    }
}
