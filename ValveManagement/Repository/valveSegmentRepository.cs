using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using Dapper;

namespace ValveManagement.Repository
{
    public class valveSegmentRepository : IvalveSegmentRepository
    {
        private readonly DapperContext _context;
        public valveSegmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddValveSeg(valvesegmentassignment valvesegmentassignment)
        {
            //valvesegmentassignment.CreatedDate = DateTime.Now;
            valvesegmentassignment.IsDeleted = false;
            int result = 0;
            var query = @"insert into tblvalvesegmentassignment(ValveId,SegmentId,CreatedBy,CreatedDate,Timestamp,IsDeleted)
                        values(@ValveId,@SegmentId,@CreatedBy,@CreatedDate,@Timestamp,@IsDeleted)";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valvesegmentassignment);
                return result;
            }
        }

        public async Task<List<valvesegmentassignment>> GetAll()
        {
            var query = "select Id,ValveId,SegmentId from tblvalvesegmentassignment where IsDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var valvesegmentassign = await connection.QueryAsync<valvesegmentassignment>(query);
                return valvesegmentassign.ToList();
            }
        }
    }
}
//Id, ValveId, SegmentId, IsDeleted, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Timestamp

