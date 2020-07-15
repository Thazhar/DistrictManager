using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class SecondarySellerCreateDto
    {
        [Column("seller_id")]
        public int SellerId { get; set; }
        [Column("district_id")]
        public int DistrictId { get; set; }
    }
}
