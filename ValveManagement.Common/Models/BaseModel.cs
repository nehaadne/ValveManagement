using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValveManagement.Common.Models
{
    public abstract class BaseModel
    {
        //public abstract string Key { get; }
        //[Required(ErrorMessage = "Created by is required")]
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Boolean IsDeleted { get; set; }
        public string CreatedDateFormatdate
        {
            get
            {
                DateTime tmp;
                DateTime.TryParse(CreatedDate.ToString(), out tmp);
                return tmp.ToString("yyyy-MM-dd hh:mm:ss tt");
            }
        }
        public string ModifiedDateFormatdate
        {
            get
            {
                DateTime tmp;
                DateTime.TryParse(ModifiedDate.ToString(), out tmp);
                return tmp.ToString("yyyy-MM-dd hh:mm:ss tt");
            }
        }
        public class DeleteObj
        {
            public long Id { get; set; }
            public long ModifiedBy { get; set; }
            public DateTime ModifiedDate { get; set; }
            //  public string lan { get; set; }
        }
    }
}
