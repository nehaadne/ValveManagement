using Microsoft.Graph;
using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IMasterDropdownRepository
    {
        public Task<List<TankInfoModel>> GetAllTank();
        public Task<List<segmaster>> GetAllSegment(int TankId);
    }
}
