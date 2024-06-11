using AutoMapper;
using BookingMeeting.Models;
using BookingMeeting.Resources;
using BookingMeeting.Services.Interfaces;
using BookingMeeting.Validators;
using Microsoft.AspNetCore.Mvc;


namespace BookingMeeting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;
        public CompaniesController(ICompanyServices companyServices, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyServices = companyServices;
        }



        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _companyServices.GetAllWithCompany();
            var companyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return Ok(companyResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesById(int id)
        {
            var companies = await _companyServices.GetCompanyById(id);
            var companyResources = _mapper.Map<Company, CompanyResource>(companies);

            return Ok(companyResources);
        }

        [HttpPost("CreatingCompany")]
        public async Task<ActionResult<CompanyResource>> CreateCompany([FromBody] SaveCompanyResource saveCompanyResource)
        {
            var validator = new SaveCompanyResourceValidator();
            
            var validationResult = await validator.ValidateAsync(saveCompanyResource);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var companyToCreate = _mapper.Map<SaveCompanyResource, Company>(saveCompanyResource);
            var newCompany = await _companyServices.CreateCompany(companyToCreate);
            var company = await _companyServices.GetCompanyById(newCompany.CompanyId);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CompanyResource>> UpdateCompany(int id , [FromBody] SaveCompanyResource saveCompanyResource)
        {

            var validator = new SaveCompanyResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveCompanyResource);

            var requestIsInvalid = id == 0 || !validatorResult.IsValid;

            if (!requestIsInvalid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var companyToUpdate = await _companyServices.GetCompanyById(id);
            if (companyToUpdate == null)
            {
                return NotFound();
            }

            var company = _mapper.Map<SaveCompanyResource, Company>(saveCompanyResource);

            await _companyServices.UpdateCompany(companyToUpdate, company);

            var updatedCompany = await _companyServices.GetCompanyById(id);
            var updatedCompanyResource = _mapper.Map<Company, CompanyResource>(updatedCompany);

            return Ok(updatedCompanyResource);
        

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCompany(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var company = await _companyServices.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            await _companyServices.DeleteCompany(company);
            return NoContent();
        }




    }
}
