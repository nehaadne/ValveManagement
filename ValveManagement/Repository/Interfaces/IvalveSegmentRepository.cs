using ValveManagement.Models;

namespace ValveManagement.Repository.Interfaces
{
    public interface IvalveSegmentRepository
    {
        public Task<List<valvesegmentassignment>> GetAll();
        public Task<int> AddValveSeg(valvesegmentassignment valvesegmentassignment);


    }
}
