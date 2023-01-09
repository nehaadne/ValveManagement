using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValveConnRemarkController : ControllerBase
    {
        private readonly IValeConnectionRemarkRepo valeConnectionRemarkRepo;
        public ValveConnRemarkController(IValeConnectionRemarkRepo valeConnectionRemarkRepo)
        {
            this.valeConnectionRemarkRepo = valeConnectionRemarkRepo;
        }
        [HttpPost]
        public async Task<IActionResult> AddValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
            var result = await valeConnectionRemarkRepo.AddValveConnRemark(valveConnectionRemarkModel);
            if (result > 0)
            {
                return StatusCode(200, "Data Added Successfully..!");
            }
            else
                return StatusCode(404, "Something is wrong...!");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
            var result = await valeConnectionRemarkRepo.DeleteValveConnRemark(valveConnectionRemarkModel);
            if (result > 0)
            {
                return StatusCode(200, "Data deleted Successfully...!");
            }
            else
                return StatusCode(404, "Record Not Deleted");

        }
        [HttpGet("GetAllValveConnRemark")]
        public async Task<IActionResult> GetAllValveConnRemark()
        {
            try
            {
                var valveConnectionRemarkModel = await valeConnectionRemarkRepo.GetAllValveConnRemark();
                return Ok(valveConnectionRemarkModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            try
            {
                var result = await valeConnectionRemarkRepo.GetById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("UpdateValveConnRemark")]
        public async Task<IActionResult> UpdateValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
            var result = await valeConnectionRemarkRepo.UpdateValveConnRemark(valveConnectionRemarkModel);
            if (result > 0)
            {
                return StatusCode(200, "Data Updated Successfully...!");
            }
            else
                return StatusCode(404, "Record Not Updated");

        }





    }
}
