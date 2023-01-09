using ValveManagement.Common.Models;

namespace ValveManagement.Models
{
    public class ValveconnectionremarkphotoModel:BaseModel
    {
        // Id, ValveConnectionId, ImagePath, ImageName, YojanaId, NetworkId, IsDeleted, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, Timestamp
        public long Id { get; set; }
        public long ValveConnectionId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public long YojanaId { get; set; }
        public long NetworkId { get; set; }
      
    }

}
