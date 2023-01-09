using Dapper;
using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;

namespace ValveManagement.Repository
{
    public class YojanaRepository : IYojanaRepository
    {
        private readonly DapperContext _context;
        public YojanaRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> AddYojana(YojanaMasterModel yojanaMasterModel)
        {
            yojanaMasterModel.CreatedDate = DateTime.Now;
            yojanaMasterModel.IsDeleted = false;
            int result = 0;
            var query = @"insert into tblyojnamaster(YojanaName,DistrictId,TalukaId,VillageId,CreatedBy,CreatedDate,Timestamp,IsDeleted)
                        values(@YojanaName,@DistrictId,@TalukaId,@VillageId,@CreatedBy,@CreatedDate,@Timestamp,@IsDeleted)";



            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, yojanaMasterModel);
                return result;
            }
        }

        public async Task<int> DeleteYojana(YojanaMasterModel yojanaMasterModel)
        {
            yojanaMasterModel.ModifiedDate=DateTime.Now;


            int result = 0;
            var query = @"UPDATE tblyojnamaster 
                        SET	IsDeleted = 1, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate 
                        WHERE Id = @Id AND IsDeleted = 0";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, yojanaMasterModel);
                return result;
            }
        }



        public async Task<List<YojanaMasterModel>> GetAllYojana()
        {
            var query = "select * from tblyojnamaster WHERE  IsDeleted = 0";
            using (var connection = _context.CreateConnection())
            {
                var yojanaMasterModel = await connection.QueryAsync<YojanaMasterModel>(query);
                return yojanaMasterModel.ToList();
            }
        }

        public async Task<YojanaMasterModel> GetById(long Id)
        {
            var query = @"select * from tblyojnamaster where Id=@Id  and IsDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var carModels = await connection.QueryAsync<YojanaMasterModel>(query, new { Id = Id });
                return carModels.FirstOrDefault();
            }
        }

        public async Task<int> UpdateYojana(YojanaMasterModel yojanaMasterModel)
        {
            yojanaMasterModel.ModifiedDate = DateTime.Now;
           
            int result = 0;
            var query = @"update tblyojnamaster set YojanaName=@YojanaName,DistrictId=@DistrictId,TalukaId=@TalukaId,VillageId=@VillageId,
                  
                       ModifiedBy=@ModifiedBy,ModifiedDate=@Modifieddate,Timestamp=@ModifiedDate
                          where Id=@Id and IsDeleted=0 ";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, yojanaMasterModel);
                return result;
            }
        }
    }
}

