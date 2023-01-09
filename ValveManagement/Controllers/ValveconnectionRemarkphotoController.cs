using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using static ValveManagement.Common.Models.BaseModel;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValveconnectionRemarkphotoController : ControllerBase
    {
        private readonly IValveconnectionRemarkphotoAsyncRepository _valveconnectionRemarkphotoAsyncRepository;
        public ValveconnectionRemarkphotoController(IValveconnectionRemarkphotoAsyncRepository valveconnectionRemarkphotoAsyncRepository)
        {
            _valveconnectionRemarkphotoAsyncRepository = valveconnectionRemarkphotoAsyncRepository;
        }   
        [HttpPost("Add")]
        public async Task<IActionResult> Add(ValveconnectionremarkphotoModel valveremarkphotomodel)
        {
           var result =await _valveconnectionRemarkphotoAsyncRepository.AddValveConnectionRemarkPhoto(valveremarkphotomodel);   
            if(result>0)
            {
                return StatusCode(200, $"Record Added Successfully with Id {result}");
            }
            else
            {
                return StatusCode(404, "something is wrong");
            }

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ValveconnectionremarkphotoModel valveremarkphotomodel)
        {
            var result = await _valveconnectionRemarkphotoAsyncRepository.UpdateValveConnectionRemarkPhoto(valveremarkphotomodel);
            if (result > 0)
            {
                return StatusCode(200, $"Record Updated Successfully");
            }
            else
            {
                return StatusCode(404, "something is wrong");
            }

        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _valveconnectionRemarkphotoAsyncRepository.GetValveConnectionRemarkPhotoById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, "something is wrong");
            }

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _valveconnectionRemarkphotoAsyncRepository.GetAllValveConnectionRemarkPhoto();
            if (result.Count() != 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, "something is wrong");
            }

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteObj deleteobj)
        {
            var result = await _valveconnectionRemarkphotoAsyncRepository.DeleteValveConnectionRemarkPhoto(deleteobj);
             if (result > 0)
              {
                return StatusCode(200, $"Record Deleted Successfully");
              }
            else
            {
                return StatusCode(404, "something is wrong");
            }

        }
    }
}
