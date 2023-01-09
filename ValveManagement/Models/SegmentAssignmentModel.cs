namespace ValveManagement.Models
{
    public class SegmentAssignmentModel
    {
        public int Id { get; set; }
        public int  TankId { get; set; }
        public int SegmentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public class segmaster
    {
        public int TankId { get; set; }
        public int SegmentId { get; set; }     
        public string? SegmentName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
 