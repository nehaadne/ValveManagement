using ValveManagement.Common.Models;

namespace ValveManagement.Models
{
    public class ValveConnectionDetailsModel: BaseModel
    {
        public int Id { get; set; }
        public long ValveConnectionId { get; set; }
        public string PipeDiameter { get; set; }
        public int ConnectionNo { get; set; }
        public int Remark { get; set; }
        public int YojanaId { get; set; }
        public int NetworkId { get; set; }
        public int Timestamp { get; set; }

        //public override string Key => throw new NotImplementedException();
    }
}
