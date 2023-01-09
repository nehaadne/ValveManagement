using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IYojanaRepository
    {
        public Task<int> AddYojana(YojanaMasterModel yojanaMasterModel);
        public Task<int> UpdateYojana(YojanaMasterModel yojanaMasterModel);
        public Task<int> DeleteYojana(YojanaMasterModel yojanaMasterModel);
        public Task<YojanaMasterModel> GetById(long Id);
        public Task<List<YojanaMasterModel>> GetAllYojana();

    }
}
