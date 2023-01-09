using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IValeConnectionRemarkRepo
    {
        public Task<int> AddValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel);
        public Task<int> UpdateValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel);
        public Task<int> DeleteValveConnRemark(ValveConnectionRemarkModel valveConnectionRemarkModel);
        public Task<ValveConnectionRemarkModel> GetById(long Id);
        public Task<List<ValveConnectionRemarkModel>> GetAllValveConnRemark();

    }
}
