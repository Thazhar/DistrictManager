using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class DistrictsUpdateDto
    {
        [Required]
        [Column("district_name")]
        [StringLength(255)]
        public string DistrictName { get; set; }

        [Column("seller_id")]
        public int SellerId { get; set; }
    }
}