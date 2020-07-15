using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DistrictAPITest.Data
{
    public class SqlSellerRepo : ISellerRepo
    {
        private readonly CentricaDbContext _context;

        public SqlSellerRepo(CentricaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Seller> GetAllSellers()
        {
            return _context.Seller.FromSqlRaw("SELECT * FROM seller").ToList<Seller>();
        }

        public Seller GetSellerById(int id)
        {
            return _context.Seller
                .FromSqlRaw("SELECT * FROM seller WHERE seller_id = @Id", new SqlParameter("@Id", id)).FirstOrDefault();
        }

        public void CreateSeller(Seller dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("INSERT INTO seller (seller_name) VALUES (@SellerName)",
                new SqlParameter("@SellerName", dis.SellerName));
        }

        public void UpdateSeller(int id, Seller dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("UPDATE seller SET seller_name = @SellerName WHERE seller_id = @SellerId",
                new SqlParameter("@SellerName", dis.SellerName), new SqlParameter("@SellerId", dis.SellerId)); ;
        }

        public void DeleteSeller(Seller dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("DELETE FROM seller WHERE seller_id = @SellerId",
                new SqlParameter("@SellerId", dis.SellerId));
        }
    }
}
