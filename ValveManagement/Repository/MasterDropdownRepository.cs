using Dapper;
using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Repository
{
    public class MasterDropdownRepository : IMasterDropdownRepository
    {
        private readonly DapperContext _context;
        public MasterDropdownRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<segmaster>> GetAllSegment(int TankId)
        {
            var query = @"select s.SegmentId,s.TankId,sm.SegmentName
                          from tbltanksegmentassignment s
                          join tbltankinfo t on t.Id=s.TankId
                          join tblsegmentmaster sm on sm.Id=s.SegmentId
                          where TankId=@TankId";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<segmaster>(query,new { TankId });
                return result.ToList();

            }
        }

        public async Task<List<TankInfoModel>> GetAllTank()
        {
            var query = @"select Id,tankName from tbltankinfo where isDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<TankInfoModel>(query);
                return result.ToList();

            }
        }
    }
}
