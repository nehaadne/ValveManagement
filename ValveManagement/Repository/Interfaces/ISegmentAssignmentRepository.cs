using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface ISegmentAssignmentRepository
    {
        public Task<int> AddSegment(TankInfoModel tankInfoModel);
        public Task<int> Update(TankInfoModel tankInfoModel);
    }
}
