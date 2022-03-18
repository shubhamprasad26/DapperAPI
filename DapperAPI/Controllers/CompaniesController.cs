using DapperAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        public readonly ICompanyRepository _repos;

        public CompaniesController(ICompanyRepository repo)
        {
            _repos = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetallCompanies()
        {
            try
            {
                var comp = await _repos.GetCompanies();
                return Ok(comp);

            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
