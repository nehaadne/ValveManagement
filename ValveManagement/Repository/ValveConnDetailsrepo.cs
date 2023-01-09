using Dapper;
using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Repository
{
    public class ValveConnDetailsrepo : IValveConnDetailsRepo
    {
        private readonly DapperContext _context;
        public ValveConnDetailsrepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddValveConn(ValveConnectionDetailsModel valveConnectionDetailsModel)
        {
            valveConnectionDetailsModel.CreatedDate = DateTime.Now;
            valveConnectionDetailsModel.IsDeleted = false;
            int result = 0;
            var query = @"insert into tblvalveconnectiondetails(ValveConnectionId,PipeDiameter,ConnectionNo,Remark,YojanaId,NetworkId,Timestamp,IsDeleted,CreatedBy,CreatedDate)
                        values(@ValveConnectionId,@PipeDiameter,@ConnectionNo,@Remark,@YojanaId,@NetworkId,@Timestamp,@IsDeleted,@CreatedBy,@CreatedDate)";


            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionDetailsModel);
                return result;
            }
        }

        public async Task<int> DeleteValveCo(ValveConnectionDetailsModel valveConnectionDetailsModel)
        {
            valveConnectionDetailsModel.ModifiedDate = DateTime.Now;


            int result = 0;
            var query = @"UPDATE tblvalveconnectiondetails 
                        SET	IsDeleted = 1, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate 
                        WHERE Id = @Id AND IsDeleted = 0";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionDetailsModel);
                return result;
            }
        }

        public async Task<List<ValveConnectionDetailsModel>> GetAllValveCo()
        {
            var query = "select * from tblvalveconnectiondetails WHERE  IsDeleted = 0";
            using (var connection = _context.CreateConnection())
            {
                var valveConnectionDetailsModel = await connection.QueryAsync<ValveConnectionDetailsModel>(query);
                return valveConnectionDetailsModel.ToList();
            }
        }

        public async Task<ValveConnectionDetailsModel> GetById(long Id)
        {
            var query = @"select * from tblvalveconnectiondetails where Id=@Id  and IsDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var valveConnectionDetailsModel = await connection.QueryAsync<ValveConnectionDetailsModel>(query, new { Id = Id });
                return valveConnectionDetailsModel.FirstOrDefault();
            }
        }

        public async Task<int> UpdateValveCo(ValveConnectionDetailsModel valveConnectionDetailsModel)
        {
            valveConnectionDetailsModel.ModifiedDate = DateTime.Now;

            int result = 0;
            var query = @"update tblvalveconnectiondetails set ValveConnectionId=@ValveConnectionId,PipeDiameter=@PipeDiameter,ConnectionNo=@ConnectionNo,Remark=@Remark,
                         YojanaId=@YojanaId,NetworkId=@NetworkId,ModifiedBy=@ModifiedBy,ModifiedDate=@Modifieddate,Timestamp=@ModifiedDate
                          where Id=@Id and IsDeleted=0 ";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, valveConnectionDetailsModel);
                return result;
            }
        }
    }
}
