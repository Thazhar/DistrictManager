using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistrictAPITest.Dtos
{
    public class StoreReadDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int DistrictId { get; set; }
    }
}
