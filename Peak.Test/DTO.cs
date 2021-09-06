using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak.Test
{
    public class DTO : ICloneable
    {
        public int PropInt { get; set; }
        public DateTime PropDateTime { get; set; }
        public string PropStr { get; set; }
        public int RowId { get; set; }

        public DTO(string propStr, int propInt, DateTime propDateTime)
        {
            this.PropInt = propInt;
            this.PropDateTime = propDateTime;
            this.PropStr = propStr;
        }

        public DTO(string propStr, int propInt, DateTime propDateTime, int rowId):this(propStr, propInt, propDateTime)
        {
            this.RowId = rowId;
        }

        public object Clone()
        {
            return new DTO(this.PropStr, this.PropInt, this.PropDateTime);
        }
    }
}
