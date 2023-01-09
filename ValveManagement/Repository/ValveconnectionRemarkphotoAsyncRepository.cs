using Dapper;
using ValveManagement.Common.Context;
using ValveManagement.Common.Models;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using static ValveManagement.Common.Models.BaseModel;

namespace ValveManagement.Repository
{
    public class ValveconnectionRemarkphotoAsyncRepository : IValveconnectionRemarkphotoAsyncRepository
    {
        private readonly DapperContext _context;

        public ValveconnectionRemarkphotoAsyncRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<long> AddValveConnectionRemarkPhoto(ValveconnectionremarkphotoModel valveremarkphoto)
        {
            // Id, ValveConnectionId, ImagePath, ImageName, YojanaId, NetworkId, IsDeleted, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Timestamp
            valveremarkphoto.CreatedDate=DateTime.Now;
            valveremarkphoto.IsDeleted = false;


            var qeury = @"insert into tblvalveconnectionremarkphoto(ValveConnectionId, ImagePath, ImageName, 

                     YojanaId, NetworkId, IsDeleted, CreatedBy, CreatedDate)

                     values(@ValveConnectionId,@ImagePath,@ImageName,@YojanaId,@NetworkId,@IsDeleted,@CreatedBy,@CreatedDate);select last_insert_id();";

            using(var connection=_context.CreateConnection())
            {
                var result=await connection.QuerySingleAsync<long>(qeury,valveremarkphoto);

                return result;

            }
        }

        public async Task<int> DeleteValveConnectionRemarkPhoto(DeleteObj deleteobj)
        {
            deleteobj.ModifiedDate=DateTime.Now;    

            var query = @"update tblvalveconnectionremarkphoto set 

            IsDeleted=1,ModifiedBy=@ModifiedBy, 

            ModifiedDate=@ModifiedDate,Timestamp=@ModifiedDate where Id=@Id ";

            using(var connection=_context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,deleteobj);  


                return result;
            }
        }

        public async Task<List<ValveconnectionremarkphotoModel>> GetAllValveConnectionRemarkPhoto()
        {
            var query = @"select * from tblvalveconnectionremarkphoto where IsDeleted=0";
            using(var connection=_context.CreateConnection())
            {
                var result=await connection.QueryAsync<ValveconnectionremarkphotoModel>(query);   

                return result.ToList(); 


            }
        }

        public async Task<ValveconnectionremarkphotoModel> GetValveConnectionRemarkPhotoById(long id)
        {
            var query = @"select * from tblvalveconnectionremarkphoto where Id=@Id and IsDeleted=0";
            using (var connection=_context.CreateConnection())
            {
                var result=await connection.QueryAsync<ValveconnectionremarkphotoModel>(query,new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<int> UpdateValveConnectionRemarkPhoto(ValveconnectionremarkphotoModel valveremarkphoto)
        {
            valveremarkphoto.ModifiedDate=DateTime.Now;

            var query = @"update tblvalveconnectionremarkphoto set

                   ValveConnectionId=@ValveConnectionId,ImagePath=@ImagePath,

                  ImageName=@ImageName,YojanaId=@YojanaId,NetworkId=@NetworkId,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate,

                      Timestamp=@ModifiedDate where Id=@Id and IsDeleted=0";

            using(var connection= _context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,valveremarkphoto);
                return result;

            }
        }
    }

}
