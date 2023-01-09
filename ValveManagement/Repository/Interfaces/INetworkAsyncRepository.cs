using ValveManagement.Models;
using static ValveManagement.Common.Models.BaseModel;

namespace ValveManagement.Repository.Interfaces
{
    public interface INetworkAsyncRepository
    {
        Task<long> AddNewNetwork(NetworkMasterModel networkmodel);
        Task<int> UpdateNetwork(NetworkMasterModel networkmodel);
        Task<int> DeleteNetwork(NetworkMasterModel networkmodel);
        Task<List<NetworkMasterModel>> GetAllNetworks();
        Task<NetworkMasterModel> GetNetworkById(long id);
    }
}
