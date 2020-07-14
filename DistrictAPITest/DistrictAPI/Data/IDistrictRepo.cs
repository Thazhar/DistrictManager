using System.Collections.Generic;
using DistrictAPITest.Models;

namespace DistrictAPITest.Data
{
    public interface IDistrictRepo
    {
        bool SaveChanges();
        IEnumerable<District> GetAllDistricts();
        District GetDistrictById(int id);
        void CreateDistrict(District dis);
        void UpdateDistrict(District dis);
        void DeleteDistrict(District dis);
    }
}
