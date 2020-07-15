using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class SecondarySellerReadDto
    {
        public int SellerId { get; set; }
        public int DistrictId { get; set; }
    }
}
