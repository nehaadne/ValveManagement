using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonDDController : ControllerBase
    {
        private readonly ICommonDropDownRepo commonDropDownRepo;
        public CommonDDController(ICommonDropDownRepo commonDropDownRepo)
        {
            this.commonDropDownRepo = commonDropDownRepo;
        }
        [HttpGet("GetAllDistrict")]
        public async Task<IActionResult> GetAllDistrict()
        {
            try
            {
                var districtDropDown = await commonDropDownRepo.GetAllDistrict();
                return Ok(districtDropDown);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetAllTaluka")]
        public async Task<IActionResult> GetAllTaluka()
        {
            try
            {
                var talukaDropDown = await commonDropDownRepo.GetAllTaluka();
                return Ok(talukaDropDown);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAllVillage")]
        public async Task<IActionResult> GetAllVillage()
        {
            try
            {
                var villageDropDown = await commonDropDownRepo.GetAllVillage();
                return Ok(villageDropDown);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
