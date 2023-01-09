using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValvesegmentController : ControllerBase
    {
        private readonly IvalveSegmentRepository valveSegmentRepository;
        public ValvesegmentController(IvalveSegmentRepository valveSegmentRepository)
        {
            this.valveSegmentRepository = valveSegmentRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var valvesegmentassignment = await valveSegmentRepository.GetAll();
                return Ok(valvesegmentassignment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddYojana(valvesegmentassignment valvesegmentassignment)
        {
            var result = await valveSegmentRepository.AddValveSeg(valvesegmentassignment);
            if (result > 0)
            {
                return StatusCode(200, "Data Added Successfully..!");
            }
            else
                return StatusCode(404, "Something is wrong...!");

        }



    }
}
