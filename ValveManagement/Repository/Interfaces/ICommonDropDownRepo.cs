using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface ICommonDropDownRepo
    {
        public Task<List<DistrictDropDown>> GetAllDistrict();
        public Task<List<TalukaDropDown>> GetAllTaluka();
        public Task<List<VillageDropDown>> GetAllVillage();

    }
}
