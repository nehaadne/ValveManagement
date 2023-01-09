using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IValveConnDetailsRepo
    {
        public Task<int> AddValveConn(ValveConnectionDetailsModel valveConnectionDetailsModel);
        public Task<int> UpdateValveCo(ValveConnectionDetailsModel valveConnectionDetailsModel);
        public Task<int> DeleteValveCo(ValveConnectionDetailsModel valveConnectionDetailsModel);
        public Task<ValveConnectionDetailsModel> GetById(long Id);
        public Task<List<ValveConnectionDetailsModel>> GetAllValveCo();

    }
}
