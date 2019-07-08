using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAPIS.Entity
{
   public  class Recharge
    {
        public int RechargeID { get; set; }
        public decimal Rechargemoney { get; set; }//充值金额
        public DateTime RechargeDateTime { get; set; }//到期时间
        public int CarID { get; set; }
        public int UserID { get; set; }
    }
}
