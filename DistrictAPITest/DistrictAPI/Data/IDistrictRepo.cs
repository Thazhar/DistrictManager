using System.Collections.Generic;
using DistrictAPITest.Models;

namespace DistrictAPITest.Data
{
    public interface IDistrictRepo
    {
        IEnumerable<District> GetAllDistricts();
        District GetDistrictById(int id);
        void CreateDistrict(District dis);
        void UpdateDistrict(int id, District dis);
        void DeleteDistrict(District dis);
    }
}
