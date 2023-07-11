using DataAccess_VendorManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model_VendorManagement;
using Model_VendorManagement.Requests;

namespace VendorManagement.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VendorDetailsController : Controller
    {
        private readonly DbContextAccess dbContextAccess;

        public VendorDetailsController(DbContextAccess dbContextAccess)
        {
            this.dbContextAccess = dbContextAccess;
        }
        [HttpGet]
        public async Task<IActionResult> GetLiftFunctionDetails()
        {
            return Ok(await dbContextAccess.VendorDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> InsertVendorDetails(VendorDetailsRequest vendorDetailsRequest)
        {

            VendorDetails vendorDetails = new VendorDetails();
            vendorDetails.Id = new Guid();
            vendorDetails.VendorName= vendorDetailsRequest.VendorName;
            vendorDetails.IsActive = true;
            vendorDetails.AddressLine1= vendorDetailsRequest.AddressLine1;
            vendorDetails.AddressLine2 = vendorDetailsRequest.AddressLine2;
            vendorDetails.City= vendorDetailsRequest.City;
            vendorDetails.State= vendorDetailsRequest.State;
            vendorDetails.PostalCode= vendorDetailsRequest.PostalCode;
            vendorDetails.Country= vendorDetailsRequest.Country;
            vendorDetails.TelePhone1=vendorDetailsRequest.TelePhone1;
            vendorDetails.TelePhone2 = vendorDetailsRequest.TelePhone2;
            vendorDetails.VendorEmail= vendorDetailsRequest.VendorEmail;
            vendorDetails.VendorWebsite= vendorDetailsRequest.VendorWebsite;



            await dbContextAccess.VendorDetails.AddAsync(vendorDetails);
            await dbContextAccess.SaveChangesAsync();
            return Ok(vendorDetails);

        } 

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteVendorDetails([FromRoute] Guid id)
        {
            var functionDetail = dbContextAccess.VendorDetails.FirstOrDefault(x => x.Id == id);
            if (functionDetail != null)
            {
                functionDetail.IsActive = false;
                dbContextAccess.VendorDetails.Update(functionDetail);
                await dbContextAccess.SaveChangesAsync();
            }
            return Ok(functionDetail);
        }

        [HttpGet]
        [Route("/vendor/vendordetails")]
        public async Task<IActionResult> DetailOfVendor([FromHeader] Guid userId)
        {
            bool person = dbContextAccess.VendorDetails.Any(x => x.Id == userId);
            if (person)
            {
                var list = dbContextAccess.VendorDetails.Where(x => x.Id == userId);
                if (list.Count() > 0)
                {
                    return Ok(await list.ToListAsync());
                }
                return Ok("No History record found");
            }
            else
            {
                return BadRequest("Invalid User");
            }

        }
    }
}
