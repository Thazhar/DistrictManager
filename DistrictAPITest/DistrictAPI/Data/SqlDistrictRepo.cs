using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DistrictAPITest.Data
{
    public class SqlDistrictRepo : IDistrictRepo
    {
        private readonly CentricaDbContext _context;

        public SqlDistrictRepo(CentricaDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<District> GetAllDistricts()
        {
            //return _context.Districts.ToList(); //TODO: Change to SQL
            return _context.Districts.FromSqlRaw("SELECT * FROM district").ToList<District>();
        }

        public District GetDistrictById(int id)
        {
            //return _context.Districts.FirstOrDefault(p => p.DistrictId == id); //TODO: Change to SQL
            return _context.Districts
                .FromSqlRaw("SELECT * FROM district WHERE district_id = @Id", new SqlParameter("@Id", id)).FirstOrDefault();
        }

        public void CreateDistrict(District dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            //_context.Districts.Add(dis);
            _context.Database.ExecuteSqlRaw("INSERT INTO district (district_name, seller_id) VALUES (@DistrictName, @SellerId)",
                new SqlParameter("@DistrictName", dis.DistrictName) , new SqlParameter("@SellerId", dis.SellerId));
        }

        public void UpdateDistrict(int id, District dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Database.ExecuteSqlRaw("UPDATE district SET district_name = @DistrictName, seller_id = @SellerId WHERE district_id = @DistrictId",
                new SqlParameter("@DistrictName", dis.DistrictName), new SqlParameter("@SellerId", dis.SellerId), new SqlParameter("@DistrictId", id));
        }

        public void DeleteDistrict(District dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            //_context.Districts.Remove(dis);
            _context.Database.ExecuteSqlRaw("DELETE FROM district WHERE district_id = @DistrictId",
                new SqlParameter("@DistrictId", dis.DistrictId));
        }
    }
}
