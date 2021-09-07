using System;

namespace Peak.Test
{
    public class Dto : ICloneable
    {
        public int PropInt { get; set; }
        public DateTime PropDateTime { get; set; }
        public string PropStr { get; set; }
        public int RowId { get; set; }

        public Dto(string propStr, int propInt, DateTime propDateTime)
        {
            this.PropInt = propInt;
            this.PropDateTime = propDateTime;
            this.PropStr = propStr;
        }

        // Response
        public Dto(string propStr, int propInt, DateTime propDateTime, int rowId):this(propStr, propInt, propDateTime)
        {
            this.RowId = rowId;
        }

        public object Clone()
        {
            return new Dto(this.PropStr, this.PropInt, this.PropDateTime);
        }
    }
}
