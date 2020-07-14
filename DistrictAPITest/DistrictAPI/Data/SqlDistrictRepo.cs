using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistrictAPITest.Models;

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
            return _context.Districts.ToList(); //TODO: Change to SQL
        }

        public District GetDistrictById(int id)
        {
            return _context.Districts.FirstOrDefault(p => p.DistrictId == id); //TODO: Change to SQL
        }

        public void CreateDistrict(District dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Districts.Add(dis);
        }

        public void UpdateDistrict(District dis)
        {
            //Nothing
        }

        public void DeleteDistrict(District dis)
        {
            if (dis == null)
            {
                throw new ArgumentNullException(nameof(dis));
            }

            _context.Districts.Remove(dis);
        }
    }
}
