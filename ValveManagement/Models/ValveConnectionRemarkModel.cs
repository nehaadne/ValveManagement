namespace ValveManagement.Models
{
    public class ValveConnectionRemarkModel
    {
        public int Id { get; set; }
        public long ValveConnectionId { get; set; }
        public bool IsIllegelAction { get; set; }
        public string Remark { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public long YojanaId { get; set; }
        public long NetworkId { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
