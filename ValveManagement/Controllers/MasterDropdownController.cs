using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Common.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDropdownController : ControllerBase
    {
        private readonly ILogger logger;
        public IMasterDropdownRepository masterDropdown;

        public MasterDropdownController(IConfiguration configuartion, ILoggerFactory loggerFactory, IMasterDropdownRepository masterDropdownRepository)
        {
            this.logger = loggerFactory.CreateLogger<MasterDropdownController>();
            this.masterDropdown = masterDropdownRepository;
        }
        [HttpGet("GetAllTank")]

        public async Task<IActionResult> GetAllTank()
        {
            BaseResponseStatus responseDetails = new BaseResponseStatus();
            try
            {
                logger.LogDebug(string.Format("MasterDropdownController-GetAllTank : Calling GetAllTank"));
                var dist = await masterDropdown.GetAllTank();

                if (dist.Count == 0)
                {
                    var returnMsg = string.Format("There are not any records for getAll.");
                    logger.LogInformation(returnMsg);
                    responseDetails.StatusCode = StatusCodes.Status404NotFound.ToString();
                    responseDetails.StatusMessage = returnMsg;
                    return Ok(responseDetails);
                }
                var rtrMsg = string.Format("All  records are fetched successfully.");
                logger.LogDebug("MasterDropdownController-GetAllTank : Completed Get action all getAll records.");
                responseDetails.StatusCode = StatusCodes.Status200OK.ToString();
                responseDetails.StatusMessage = rtrMsg;
                responseDetails.ResponseData = dist;
            }
            catch (Exception ex)
            {
                //log error
                logger.LogError(ex.Message);
                var returnMsg = string.Format(ex.Message);
                logger.LogInformation(returnMsg);
                responseDetails.StatusCode = StatusCodes.Status409Conflict.ToString();
                responseDetails.StatusMessage = returnMsg;
                return Ok(responseDetails);
            }
            return Ok(responseDetails);
        }
        [HttpGet("GetAllSegment")]

        public async Task<IActionResult> GetAllSegment(int TankId)
        {
            BaseResponseStatus responseDetails = new BaseResponseStatus();
            try
            {
                logger.LogDebug(string.Format("MasterDropdownController-GetAllSegment : Calling GetAllSegment"));
                var dist = await masterDropdown.GetAllSegment(TankId);

                if (dist.Count == 0)
                {
                    var returnMsg = string.Format("There are not any records for GetAllTaluka.");
                    logger.LogInformation(returnMsg);
                    responseDetails.StatusCode = StatusCodes.Status404NotFound.ToString();
                    responseDetails.StatusMessage = returnMsg;
                    return Ok(responseDetails);
                }
                var rtrMsg = string.Format("All  records are fetched successfully.");
                logger.LogDebug("MasterDropdownController-GetAllSegment : Completed Get action all GetAllSegment records.");
                responseDetails.StatusCode = StatusCodes.Status200OK.ToString();
                responseDetails.StatusMessage = rtrMsg;
                responseDetails.ResponseData = dist;
            }
            catch (Exception ex)
            {
                //log error
                logger.LogError(ex.Message);
                var returnMsg = string.Format(ex.Message);
                logger.LogInformation(returnMsg);
                responseDetails.StatusCode = StatusCodes.Status409Conflict.ToString();
                responseDetails.StatusMessage = returnMsg;
                return Ok(responseDetails);
            }
            return Ok(responseDetails);
        }
    }
}
