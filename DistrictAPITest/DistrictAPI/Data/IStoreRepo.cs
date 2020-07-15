using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;

namespace DistrictAPITest.Data
{
    public interface IStoreRepo
    {
        IEnumerable<Store> GetAllStores();
        Store GetStoreById(int id);
        void CreateStore(Store dis);
        void UpdateStore(int id, Store dis);
        void DeleteStore(Store dis);
    }
}
