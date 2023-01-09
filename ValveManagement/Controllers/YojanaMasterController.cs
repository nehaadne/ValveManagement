using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YojanaMasterController : ControllerBase
    {
        private readonly IYojanaRepository yojanaRepository;
        public YojanaMasterController(IYojanaRepository yojanaRepository)
        {
            this.yojanaRepository = yojanaRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddYojana(YojanaMasterModel yojanaMasterModel)
        {
            var result = await yojanaRepository.AddYojana(yojanaMasterModel);
            if (result > 0)
            {
                return StatusCode(200, "Data Added Successfully..!");
            }
            else
                return StatusCode(404, "Something is wrong...!");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateYojana(YojanaMasterModel yojanaMasterModel)
        {
            var result = await yojanaRepository.UpdateYojana(yojanaMasterModel);
            if (result > 0)
            {
                return StatusCode(200, "Data Updated Successfully...!");
            }
            else
                return StatusCode(404, "Record Not Updated");

        }
        [HttpGet]
        public async Task<IActionResult> GetAllYojana()
        {
            try
            {
                var yojanaMasterModel = await yojanaRepository.GetAllYojana();
                return Ok(yojanaMasterModel);
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
                var result = await yojanaRepository.GetById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteYojana(YojanaMasterModel yojanaMasterModel)
        {
            var result = await yojanaRepository.DeleteYojana(yojanaMasterModel);
            if (result > 0)
            {
                return StatusCode(200, "Data deleted Successfully...!");
            }
            else
                return StatusCode(404, "Record Not Deleted");

        }




    }
}
