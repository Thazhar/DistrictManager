using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class DistrictsReadDto
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int SellerId { get; set; }
    }
}
