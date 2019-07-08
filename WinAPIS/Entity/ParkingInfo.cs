using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 车库表
    /// </summary>

    public class ParkingInfo
    {
        public int ParkingID { get; set; }

        public int CarID { get; set; }

        public int Status { get; set; }
    }
}