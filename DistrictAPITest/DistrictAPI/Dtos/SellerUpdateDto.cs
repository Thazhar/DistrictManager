using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class SellerUpdateDto
    {
        [Required]
        [Column("seller_name")]
        [StringLength(255)]
        public string SellerName { get; set; }
    }
}
