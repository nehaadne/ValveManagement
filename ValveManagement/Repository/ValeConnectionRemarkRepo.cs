using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using Dapper;

namespace ValveManagement.Repository
{
    public class ValeConnectionRemarkRepo : IValeConnectionRemarkRepo
    {
        private readonly DapperContext _context;
        public ValeConnectionRemarkRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
           valveConnectionRemarkModel.CreatedDate = DateTime.Now;
            valveConnectionRemarkModel.IsDeleted = false;
            int result = 0;
            var query = @"insert into tblvalveconnectionremark(ValveConnectionId,IsIllegelAction,Remark,Latitude,Longitude,YojanaId,NetworkId,IsDeleted,CreatedBy,CreatedDate,Timestamp)
                        values(@ValveConnectionId,@IsIllegelAction,@Remark,@Latitude,@Longitude,@YojanaId,@NetworkId,@IsDeleted,@CreatedBy,@CreatedDate,@Timestamp)";


            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionRemarkModel);
                return result;
            }
        }

        public async Task<int> DeleteValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
            valveConnectionRemarkModel.ModifiedDate = DateTime.Now;


            int result = 0;
            var query = @"UPDATE tblvalveconnectionremark 
                        SET	IsDeleted = 1, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate 
                        WHERE Id = @Id AND IsDeleted = 0";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionRemarkModel);
                return result;
            }
        }
    

    public async Task<List<ValveConnectionRemarkModel>> GetAllValveConnRemark()
        {
            var query = "select * from tblvalveconnectionremark WHERE  IsDeleted = 0";
            using (var connection = _context.CreateConnection())
            {
                var valveConnectionRemarkModel = await connection.QueryAsync<ValveConnectionRemarkModel>(query);
                return valveConnectionRemarkModel.ToList();
            }
        }

        public async Task<ValveConnectionRemarkModel> GetById(long Id)
        {
            var query = @"select * from tblvalveconnectionremark where Id=@Id  and IsDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var valveConnectionRemarkModel = await connection.QueryAsync<ValveConnectionRemarkModel>(query, new { Id = Id });
                return valveConnectionRemarkModel.FirstOrDefault();
            }
        }

        public async Task<int> UpdateValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel)
        {
            valveConnectionRemarkModel.ModifiedDate = DateTime.Now;

            int result = 0;
            var query = @"update tblvalveconnectionremark set ValveConnectionId=@ValveConnectionId,IsIllegelAction=@IsIllegelAction,Remark=@Remark,Latitude=@Latitude,
                          Longitude=@Longitude,YojanaId=@YojanaId,NetworkId=@NetworkId,
                          ModifiedBy=@ModifiedBy,ModifiedDate=@Modifieddate,Timestamp=@ModifiedDate
                          where Id=@Id and IsDeleted=0 ";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionRemarkModel);
                return result;
            }
            throw new NotImplementedException();
        }
    }
}
