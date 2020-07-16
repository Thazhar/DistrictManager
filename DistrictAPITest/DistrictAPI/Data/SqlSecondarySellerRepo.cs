using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DistrictAPITest.Data
{
    public class SqlSecondarySellerRepo : ISecondarySellerRepo
    {
        private readonly CentricaDbContext _context;

        public SqlSecondarySellerRepo(CentricaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SecondarySeller> GetSecondarySellersByDistrictId(int id)
        {
            return _context.SecondarySeller
                .FromSqlRaw("SELECT * FROM secondary_seller WHERE district_id = @Id", new SqlParameter("@Id", id))
                .ToList<SecondarySeller>();
        }

        public SecondarySeller GetSecondarySellerByKey(int sellerId, int districtId)
        {
            return _context.SecondarySeller
                .FromSqlRaw("SELECT * FROM secondary_seller WHERE seller_id = @SellerId AND district_id = @DistrictId", new SqlParameter("@SellerId", sellerId), new SqlParameter("@DistrictId", districtId)).FirstOrDefault();
        }

        public void CreateSecondarySeller(SecondarySeller dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw(
                "INSERT INTO secondary_seller (seller_id, district_id) VALUES (@SellerId, @DistrictId)",
                new SqlParameter("@SellerId", dis.SellerId), new SqlParameter("@DistrictId", dis.DistrictId));
        }

        public void DeleteSecondarySeller(SecondarySeller dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("DELETE from secondary_seller WHERE seller_id = @SellerId AND district_id = @DistrictId",
                new SqlParameter("@SellerId", dis.SellerId), new SqlParameter("@DistrictId", dis.DistrictId));
        }
    }
}
