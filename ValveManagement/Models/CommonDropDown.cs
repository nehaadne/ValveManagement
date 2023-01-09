namespace ValveManagement.Models
{
    public class CommonDropDown
    {
    }
    public class DistrictDropDown
    {
        public long Id { get; set; }
        public string DistrictName { get; set; }

    }
    public class TalukaDropDown
    {
        public long Id { get; set; }
        public string TalukaName { get; set; }
        public long DistrictId { get; set; }

    }
    public class VillageDropDown
    {
        public long Id { get; set; }
        public string VillageName { get; set; }
        public long TalukaId { get; set; }
        public long DistrictId { get; set; }
        public int IsTown { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TVCode { get; set; }

    }
}
