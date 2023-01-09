using ValveManagement.Common.Models;

namespace ValveManagement.Models
{
    public class NetworkMasterModel
        //:BaseModel
    {
        //Id,NetworkName,YojanaId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted,Timestamp

        public int Id { get; set; }
        public string NetworkName { get; set; }
        public long YojanaId { get; set; }
        public DateTime Timestamp { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        //public override string Key => throw new NotImplementedException();
    }
}
