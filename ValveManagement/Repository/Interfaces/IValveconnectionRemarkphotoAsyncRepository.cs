using static ValveManagement.Common.Models.BaseModel;
using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IValveconnectionRemarkphotoAsyncRepository
    {
        Task<long> AddValveConnectionRemarkPhoto(ValveconnectionremarkphotoModel valveremarkphoto);
        Task<int> UpdateValveConnectionRemarkPhoto(ValveconnectionremarkphotoModel valveremarkphoto);
        Task<int> DeleteValveConnectionRemarkPhoto(DeleteObj deleteobj);
        Task<List<ValveconnectionremarkphotoModel>> GetAllValveConnectionRemarkPhoto();
        Task<ValveconnectionremarkphotoModel> GetValveConnectionRemarkPhotoById(long id);
    }
}
