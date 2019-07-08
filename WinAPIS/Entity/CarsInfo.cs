using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 车辆信息表
    /// </summary>
    public class CarsInfo
    {
        public int CarID { get; set; }

        public string License { get; set; }
        
        public string Brand { get; set; }

        public string Color { get; set; }

        public int CarTypeID { get; set; }

        public int UserID { get; set; }


    }
}