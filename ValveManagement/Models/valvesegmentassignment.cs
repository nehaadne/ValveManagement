namespace ValveManagement.Models
{
    public class valvesegmentassignment
    {
        public int Id { get; set; }
        public int ValveId { get; set; }
        public int SegmentId { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public int CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
