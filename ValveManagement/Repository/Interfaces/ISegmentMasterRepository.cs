using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface ISegmentMasterRepository
    {
        public Task<List<SegmentMasterModel>> GetAll();
        public Task<SegmentMasterModel> GetById(long Id);
        public Task<long> Add(SegmentMasterModel model);
        public Task<long> Update(SegmentMasterModel model);
        public Task<long> Delete(long id);
    }
}
