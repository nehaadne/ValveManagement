using Dapper;
using System.Data.Common;
using ValveManagement.Common.Context;
using ValveManagement.Common.Models;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using static ValveManagement.Common.Models.BaseModel;

namespace ValveManagement.Repository
{
    public class NetworkMasterAsyncRepository:INetworkAsyncRepository
    {
        private readonly DapperContext _dappercontext;
        public NetworkMasterAsyncRepository(DapperContext dappercontext)
        {
            _dappercontext = dappercontext;
        }

        public async Task<long> AddNewNetwork(NetworkMasterModel networkmodel)
        {
            //Id,NetworkName,YojanaId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted,Timestamp

            long id = 0;
            networkmodel.IsDeleted = false;
            networkmodel.CreatedDate = DateTime.Now;
            //Id,CategoryName,M_CategoryName,createdBy,createdDate,modifiedBy,modifiedDate,isDeleted
            var query = @"insert into tblnetworkmaster

              (NetworkName,YojanaId,CreatedBy,CreatedDate,IsDeleted)

               values(@NetworkName,@YojanaId,@CreatedBy,@CreatedDate,@IsDeleted);select last_insert_id();";

            using (var connection = _dappercontext.CreateConnection())
            {
              
               
                var result = await connection.QueryAsync<long>(query, networkmodel);

                return result.FirstOrDefault();

            }

        }

        public async Task<int> DeleteNetwork(NetworkMasterModel networkmodel)
        {
            networkmodel.ModifiedDate= DateTime.Now;

            var query = @"update tblnetworkmaster set IsDeleted=1,
              ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate,Timestamp=@ModifiedDate where Id=@Id";


            using(var connection= _dappercontext.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query, networkmodel);

                return result;  
            }

        }

        public async Task<List<NetworkMasterModel>> GetAllNetworks()
        {
            var query = @"select * from tblnetworkmaster where IsDeleted=0";
            using(var connection = _dappercontext.CreateConnection())
            {
                var networkmodel = await connection.QueryAsync<NetworkMasterModel>(query);

                return networkmodel.ToList();

            }
        }

        public async Task<NetworkMasterModel> GetNetworkById(long id)
        {
            var query = @"select * from tblnetworkmaster where Id=@Id and IsDeleted=0";
            using(var connection = _dappercontext.CreateConnection())
            {
                var result=await connection.QueryAsync<NetworkMasterModel>(query, new {Id=id});

                return result.FirstOrDefault();
            }
        }

        public async Task<int> UpdateNetwork(NetworkMasterModel networkmodel)
        {
            networkmodel.ModifiedDate = DateTime.Now;

            var query = @"update tblnetworkmaster set NetworkName=@NetworkName,YojanaId=@YojanaId,

                 ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate,Timestamp=@ModifiedDate where Id=@Id and IsDeleted=0";

            using(var connection=_dappercontext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, networkmodel);

                return result;

            }

        }
    }
}
