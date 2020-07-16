using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DistrictAPITest.Data
{
    public class SqlStoreRepo : IStoreRepo
    {
        private readonly CentricaDbContext _context;

        public SqlStoreRepo(CentricaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Store> GetAllStores()
        {
            return _context.Store.FromSqlRaw("SELECT * FROM store").ToList<Store>();
        }

        public Store GetStoreById(int id)
        {
            return _context.Store
                .FromSqlRaw("SELECT * FROM store WHERE store_id = @Id", new SqlParameter("@Id", id)).FirstOrDefault();
        }

        public IEnumerable<Store> GetStoresByDistrictId(int id)
        {
            return _context.Store.FromSqlRaw("SELECT * FROM store WHERE district_id = @Id", new SqlParameter("@Id", id))
                .ToList<Store>();
        }

        public void CreateStore(Store dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("INSERT INTO store (store_name, district_id) VALUES (@StoreName, @DistrictId)",
                new SqlParameter("@StoreName", dis.StoreName), new SqlParameter("@DistrictId", dis.DistrictId));
        }

        public void UpdateStore(int id, Store dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("UPDATE store SET store_name = @StoreName, district_id = @DistrictId WHERE store_id = @StoreId",
                new SqlParameter("@StoreName", dis.StoreName), new SqlParameter("@DistrictId", dis.DistrictId), new SqlParameter("@StoreId", id));
        }

        public void DeleteStore(Store dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("DELETE FROM store WHERE store_id = @StoreId",
                new SqlParameter("@StoreId", dis.StoreId));
        }
    }
}
