﻿using DataAccess_VendorManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model_VendorManagement;
using Model_VendorManagement.Requests;
using System;
using System.Reflection;

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
                vendorDetails.VendorName = vendorDetailsRequest.VendorName;
                vendorDetails.IsActive = true;
                vendorDetails.AddressLine1 = vendorDetailsRequest.AddressLine1;
                vendorDetails.AddressLine2 = vendorDetailsRequest.AddressLine2;
                vendorDetails.City = vendorDetailsRequest.City;
                vendorDetails.State = vendorDetailsRequest.State;
                vendorDetails.PostalCode = vendorDetailsRequest.PostalCode;
                vendorDetails.Country = vendorDetailsRequest.Country;
                vendorDetails.TelePhone1 = vendorDetailsRequest.TelePhone1;
                vendorDetails.TelePhone2 = vendorDetailsRequest.TelePhone2;
                vendorDetails.VendorEmail = vendorDetailsRequest.VendorEmail;
                vendorDetails.VendorWebsite = vendorDetailsRequest.VendorWebsite;

            

            await dbContextAccess.VendorDetails.AddAsync(vendorDetails);
            await dbContextAccess.SaveChangesAsync();
            return Ok(vendorDetails);

        }

       


        [HttpPut]
        [Route("editvendor/{id:guid}")]
        public async Task<IActionResult> UpdatePersonDetails([FromRoute] Guid id, VendorDetailsRequest updatevendorDetails)
        {
            if (updatevendorDetails != null)
            {
                var vendorDetails = await dbContextAccess.VendorDetails.FirstOrDefaultAsync(x => x.Id == id);

                if (vendorDetails != null)
                {

                    vendorDetails.VendorName = updatevendorDetails.VendorName;
                    vendorDetails.IsActive = true;
                    vendorDetails.AddressLine1 = updatevendorDetails.AddressLine1;
                    vendorDetails.AddressLine2 = updatevendorDetails.AddressLine2;
                    vendorDetails.City = updatevendorDetails.City;
                    vendorDetails.State = updatevendorDetails.State;
                    vendorDetails.PostalCode = updatevendorDetails.PostalCode;
                    vendorDetails.Country = updatevendorDetails.Country;
                    vendorDetails.TelePhone1 = updatevendorDetails.TelePhone1;
                    vendorDetails.TelePhone2 = updatevendorDetails.TelePhone2;
                    vendorDetails.VendorEmail = updatevendorDetails.VendorEmail;
                    vendorDetails.VendorWebsite = updatevendorDetails.VendorWebsite;

                    dbContextAccess.VendorDetails.Update(vendorDetails);
                    await dbContextAccess.SaveChangesAsync();
                }

                return Ok(vendorDetails);
            }
            else
            {
                return BadRequest("Not available");
            }
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
        [Route("/vendor/vendordetails/{userId}")]
        public async Task<IActionResult> DetailOfVendor([FromRoute] Guid userId)
        {
            bool person = dbContextAccess.VendorDetails.Any(x => x.Id == userId && x.IsActive == true);
            if (person)
            {
                var list = dbContextAccess.VendorDetails.Where(x => x.Id==userId);
                if (list.Count() > 0)
                {
                    
                    return Ok(await list.ToListAsync());
                }
                return Ok("No Record found");
            }
            else
            {
                return BadRequest("Invalid User");
            }

        }
    }
}
