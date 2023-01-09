using Microsoft.Graph;

namespace ValveManagement.Models
{
    public class SegmentMasterModel
    {
        public long Id { get; set; }
        public string? SegmentName { get; set; }
        public string? StartPoints { get; set; }
        public string? EndPoints { get; set; }
        public string? Midpoints { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long Modifiedby { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool isDeleted { get; set; }
        public DateTime Timestamp { get; set; }

    }
   
}
