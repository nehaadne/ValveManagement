using System.ComponentModel.DataAnnotations;

namespace ValveManagement.Models
{
    public class TankInfoModel
    {
        public int id { get; set; }
        public string? tankName { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public string? address { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public int createdBy { get; set; }
        public int modifiedby { get; set; }
        public DateTime timeStamp { get; set; }
        public Decimal TankHeightInCM { get; set; }
        public Decimal TankCapcityInLiter { get; set; }
        public Decimal TankMinLevel { get; set; }
        public Decimal TankMaxLevel { get; set; }
        public Decimal TankMinQty { get; set; }
        public Decimal TankMaxQty { get; set; }
        public long YojanId { get; set; }
        public long NetworkId { get; set; }

        public List<SegmentAssignmentModel> segmentAssignments { get; set; }

    }
}
