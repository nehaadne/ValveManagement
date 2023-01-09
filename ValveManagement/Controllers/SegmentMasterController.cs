using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Common.Models;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentMasterController : ControllerBase
    {
        private readonly ILogger logger;
        public ISegmentMasterRepository segmentMasterRepository;

        public SegmentMasterController(IConfiguration configuartion, ILoggerFactory loggerFactory, ISegmentMasterRepository segmentMaster)
        {
            this.logger = loggerFactory.CreateLogger<SegmentMasterController>();
            this.segmentMasterRepository = segmentMaster;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(string.Format($"SegmentMasterController-GetAll:Calling GetAll."));
            var segment = await segmentMasterRepository.GetAll();
            if (segment.Count == 0)
            {
                baseResponseStatus.StatusCode = StatusCodes.Status404NotFound.ToString();
                baseResponseStatus.StatusMessage = "Data not found";
            }
            else
            {
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = "All Data feached Successfully";
                baseResponseStatus.ResponseData = segment;
            }
            return Ok(baseResponseStatus);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(string.Format($"SegmentMasterController-GetById:Calling GetById."));
            var segment = await segmentMasterRepository.GetById(id);
            if (segment == null)
            {
                baseResponseStatus.StatusCode = StatusCodes.Status404NotFound.ToString();
                baseResponseStatus.StatusMessage = "Data not found";
            }
            else
            {
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = "All Data feached Successfully";
                baseResponseStatus.ResponseData = segment;
            }
            return Ok(baseResponseStatus);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SegmentMasterModel model)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"SegmentMasterController-Add:Calling By Add action."));
            if (segmentMasterRepository != null)
            {
                var Execution = await segmentMasterRepository.Add(model);
                if (Execution == -1)
                {
                    var returnmsg = string.Format($"Record Is Already saved With ID ");
                    logger.LogDebug(returnmsg);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = returnmsg;
                    return Ok(baseResponseStatus);
                }
                else if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record added successfully.." );
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("SegmentMasterController-Add:Calling By Add action."));
                    baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg;
                    baseResponseStatus.ResponseData = Execution;
                    return Ok(baseResponseStatus);
                }
                else
                {
                    var rtnmsg1 = string.Format("Error while Adding");
                    logger.LogError(rtnmsg1);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg1;
                    return Ok(baseResponseStatus);
                }

            }
            else
            {
                var returnmsg = string.Format("Record added successfully..");
                logger.LogDebug(returnmsg);
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = returnmsg;
                return Ok(baseResponseStatus);
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(SegmentMasterModel model)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"SegmentMasterController-Update:Calling By Update action."));
            if (segmentMasterRepository != null)
            {
                var Execution = await segmentMasterRepository.Update(model);
                if (Execution == -1)
                {
                    var returnmsg = string.Format($"Record Is Already saved With ID {model.Id}");
                    logger.LogDebug(returnmsg);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = returnmsg;
                    return Ok(baseResponseStatus);
                }
                else if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record update successfully..");
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("SegmentMasterController-Update:Calling By Update action."));
                    baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg;
                    baseResponseStatus.ResponseData = Execution;
                    return Ok(baseResponseStatus);
                }
                else
                {
                    var rtnmsg1 = string.Format("Error while Adding");
                    logger.LogError(rtnmsg1);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = rtnmsg1;
                    return Ok(baseResponseStatus);
                }

            }
            else
            {
                var returnmsg = string.Format("Record added successfully..");
                logger.LogDebug(returnmsg);
                baseResponseStatus.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponseStatus.StatusMessage = returnmsg;
                return Ok(baseResponseStatus);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            BaseResponseStatus baseResponse = new BaseResponseStatus();
            logger.LogDebug(string.Format("SegmentMasterController-Delete:Calling By Delete action"));
            if (id != null)
            {
                var Execution = await segmentMasterRepository.Delete(id);

                if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record Deleted successfully..");
                    logger.LogDebug(rtnmsg);
                    baseResponse.StatusCode = StatusCodes.Status200OK.ToString();
                    baseResponse.StatusMessage = rtnmsg;
                    baseResponse.ResponseData = Execution;
                    return Ok(baseResponse);
                }
                else
                {
                    var rtnmsg = string.Format("Error while Deleting");
                    logger.LogDebug(rtnmsg);
                    baseResponse.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponse.StatusMessage = rtnmsg;
                    return Ok(baseResponse);
                }
            }
            else
            {
                var rtnmsg = string.Format("Record Deleted successfully..");
                logger.LogDebug(rtnmsg);
                baseResponse.StatusCode = StatusCodes.Status200OK.ToString();
                baseResponse.StatusMessage = rtnmsg;
                return Ok(baseResponse);
            }
        }
    }
}
