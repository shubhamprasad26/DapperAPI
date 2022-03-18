using DapperAPI.Service;
using DapperAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace DapperAPI.Repository
{
    public interface ICompanyRepository
    {
        public  Task<IEnumerable<Company>> GetCompanies();
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;

        public CompanyRepository(DapperContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "select * from Companies";

            using(var connection = _context.CreateConnection)
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
    }
}
