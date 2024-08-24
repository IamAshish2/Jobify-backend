using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using jobify_Backend.Interfaces;
using jobify_Backend.Models;
using jobify_Backend.Dto.CompanyDtos;

namespace jobify_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _companyRepository.GetCompanies();
            var companyDtos = _mapper.Map<ICollection<CompanyDto>>(companies);
            return Ok(companyDtos);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            if (!_companyRepository.CompanyExists(id))
                return NotFound();

            var company = _companyRepository.GetCompany(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }

        // view all the jobs posted by 'X' company
        [HttpGet("jobs/{companyId}")]
        public IActionResult GetPostedJobs(int companyId)
        {
            if(!_companyRepository.CompanyExists(companyId)) return NotFound();
            var jobs = _companyRepository.PostedJobs(companyId);
            return Ok(jobs);
        }

        // POST: api/Companies
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            if (createCompanyDto == null)
                return BadRequest();

            var company = _mapper.Map<Company>(createCompanyDto);

            if (!_companyRepository.CreateCompany(company))
            {
                ModelState.AddModelError("", "Something went wrong while creating the company");
                return StatusCode(500, ModelState);
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] UpdateCompanyDto updateCompanyDto)
        {
            if (updateCompanyDto == null || id <= 0)
                return BadRequest();

            if (!_companyRepository.CompanyExists(id))
                return NotFound();

            var company = _mapper.Map<Company>(updateCompanyDto);
            company.CompanyId = id;

            if (!_companyRepository.UpdateCompany(company))
            {
                ModelState.AddModelError("", "Something went wrong while updating the company");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            if (!_companyRepository.CompanyExists(id))
                return NotFound();

            var company = _companyRepository.GetCompany(id);

            if (!_companyRepository.DeleteCompany(company))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the company");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
