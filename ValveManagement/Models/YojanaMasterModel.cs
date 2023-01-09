namespace ValveManagement.Models
{
    public class YojanaMasterModel
    {

        public long Id { get; set; }
        public string YojanaName { get; set; }
        public long DistrictId { get; set; }
        public long TalukaId { get; set; }
        public long VillageId { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
