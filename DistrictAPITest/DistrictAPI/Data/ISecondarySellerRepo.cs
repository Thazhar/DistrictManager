using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;

namespace DistrictAPITest.Data
{
    public interface ISecondarySellerRepo
    {
        IEnumerable<SecondarySeller> GetSecondarySellersByDistrictId(int id);
        SecondarySeller GetSecondarySellerByKey(int sellerId, int districtId);
        void CreateSecondarySeller(SecondarySeller dis);
        void DeleteSecondarySeller(SecondarySeller dis);
    }
}
