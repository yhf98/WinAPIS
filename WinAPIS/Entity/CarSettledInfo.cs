using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 车辆入驻 
    /// </summary>
    public class CarSettledInfo
    {
        public int SettleID { get; set; }

        public DateTime SettledDate { get; set; }

        public int CarID { get; set; }
    }
}