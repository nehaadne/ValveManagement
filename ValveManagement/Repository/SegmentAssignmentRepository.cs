using Dapper;
using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Repository
{
    public class SegmentAssignmentRepository : ISegmentAssignmentRepository
    {
        private readonly DapperContext _context;
        public SegmentAssignmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddSegment(TankInfoModel tankInfoModel)
        {
            var query = @"insert into tbltankinfo (tankName, latitude, longitude, address, isDeleted, createdDate, modifiedDate, createdBy, modifiedBy, timeStamp, TankHeightInCM, TankCapcityInLiter, TankMinLevel, TankMaxLevel, TankMinQty, TankMaxQty, YojanId, NetworkId) " +
                         "values(@tankName, @latitude, @longitude, @address, 0, now(), now(), @createdBy, @modifiedBy, now(), @TankHeightInCM, @TankCapcityInLiter, @TankMinLevel, @TankMaxLevel, @TankMinQty, @TankMaxQty, @YojanId, @NetworkId);" +
                         "SELECT LAST_INSERT_ID();";
            List<SegmentAssignmentModel> seglist = new List<SegmentAssignmentModel>();
            seglist = tankInfoModel.segmentAssignments.ToList();
            using (var connection = _context.CreateConnection())
            {
                {
                    int result = await connection.QuerySingleAsync<int>(query, tankInfoModel);
                    foreach (var segments in tankInfoModel.segmentAssignments)
                    {
                        segments.TankId = result;
                        int result1 = await connection.ExecuteAsync(@"insert into tbltanksegmentassignment(TankId, SegmentId, IsDeleted, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Timestamp)
                        values (@TankId, @SegmentId, 0, @CreatedBy,now(), @ModifiedBy, now(),now());", segments);
                    }
                    return Convert.ToInt32(result);
                }


            }
        }

        public async Task<int> Update(TankInfoModel tankInfoModel)
        {
            var query = @"update tbltankinfo set tankName=@tankName, latitude= @latitude, longitude=@longitude,
                         address=@address,createdDate=now(), modifiedDate=now(), createdBy=@createdBy, 
                         modifiedBy= @modifiedBy, timeStamp=now(), TankHeightInCM=@TankHeightInCM, 
                         TankCapcityInLiter=@TankCapcityInLiter, TankMinLevel=@TankMinLevel, 
                         TankMaxLevel=@TankMaxLevel, TankMinQty=@TankMinQty, TankMaxQty=@TankMaxQty, 
                         YojanId=@YojanId, NetworkId= @NetworkId
                         where id=@id;";                       
                         
           
         
            using (var connection = _context.CreateConnection())
            {
                {
                    int result = await connection.ExecuteAsync(query, tankInfoModel);
                    foreach (var segments in tankInfoModel.segmentAssignments)
                    {
                      
                        int result1 = await connection.ExecuteAsync(@"update tbltanksegmentassignment set
                        TankId=@TankId, SegmentId=@SegmentId, CreatedBy=@CreatedBy, CreatedDate=now(),
                        ModifiedBy=@ModifiedBy, ModifiedDate=now(), Timestamp=now() where Id =@Id;",
                        segments);
                        
                    }
                    return result;
                }


            }
        }
    }
}
