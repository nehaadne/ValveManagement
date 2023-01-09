using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValveManagement.Common.Models;
using ValveManagement.Models;
using ValveManagement.Repository;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentAssignmentController : ControllerBase
    {
        private readonly ILogger logger;
        public ISegmentAssignmentRepository segmentAssign;

        public SegmentAssignmentController(IConfiguration configuartion, ILoggerFactory loggerFactory, ISegmentAssignmentRepository segmentA)
        {
            this.logger = loggerFactory.CreateLogger<SegmentMasterController>();
            this.segmentAssign = segmentA;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSegment(TankInfoModel tankInfoModel)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"SegmentAssignmentController-AddSegment:Calling By AddSegment action."));
            if (segmentAssign != null)
            {
                var Execution = await segmentAssign.AddSegment(tankInfoModel);
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
                    var rtnmsg = string.Format("Record added successfully..");
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("SegmentAssignmentController-AddSegment:Calling By AddSegment action."));
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
        public async Task<IActionResult> Update(TankInfoModel tankInfoModel)
        {
            BaseResponseStatus baseResponseStatus = new BaseResponseStatus();
            logger.LogDebug(String.Format($"SegmentAssignmentController-Update:Calling By Update action."));
            if (segmentAssign != null)
            {
                var Execution = await segmentAssign.Update(tankInfoModel);
                if (Execution == -1)
                {
                    var returnmsg = string.Format($"Record Is Already saved With ID {tankInfoModel.id}");
                    logger.LogDebug(returnmsg);
                    baseResponseStatus.StatusCode = StatusCodes.Status409Conflict.ToString();
                    baseResponseStatus.StatusMessage = returnmsg;
                    return Ok(baseResponseStatus);
                }
                else if (Execution >= 1)
                {
                    var rtnmsg = string.Format("Record update successfully..");
                    logger.LogInformation(rtnmsg);
                    logger.LogDebug(string.Format("SegmentAssignmentController-Update:Calling By Update action."));
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
    }
}
