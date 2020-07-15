using System.Collections.Generic;
using DistrictAPITest.Models;

namespace DistrictAPITest.Data
{
    public interface ISellerRepo
    {
        IEnumerable<Seller> GetAllSellers();
        Seller GetSellerById(int id);
        void CreateSeller(Seller dis);
        void UpdateSeller(int id, Seller dis);
        void DeleteSeller(Seller dis);
    }
}
