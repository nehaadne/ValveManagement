using ValveManagement.Common.Context;
using ValveManagement.Models;
using ValveManagement.Repository.Interfaces;
using Dapper;

namespace ValveManagement.Repository
{
    public class CommonDropDownRepo : ICommonDropDownRepo
    {
        private readonly DapperContext _context;
        public CommonDropDownRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<DistrictDropDown>> GetAllDistrict()
        {
            var query = "select Id, DistrictName from tbldistrict where IsDeleted = 0";
            using (var connection = _context.CreateConnection())
            {
                var districtDropDowns = await connection.QueryAsync<DistrictDropDown>(query);
                return districtDropDowns.ToList();
            }
        }

        public async Task<List<TalukaDropDown>> GetAllTaluka()
        {
            var query = "select Id,TalukaName,DistrictId from tbltaluka where IsDeleted=0"; 
            using (var connection = _context.CreateConnection())
            {
                var talukaDropDowns = await connection.QueryAsync<TalukaDropDown>(query);
                return talukaDropDowns.ToList();
            }
        }

        public async Task<List<VillageDropDown>> GetAllVillage()
        {
            var query = "select Id,VillageName,TalukaId,DistrictId,IsTown,Latitude,Longitude,TVCode from tblvillage where IsDeleted=0";
            using (var connection = _context.CreateConnection())
            {
                var villageDropDowns = await connection.QueryAsync<VillageDropDown>(query);
                return villageDropDowns.ToList();
            }
        }
    }
}


