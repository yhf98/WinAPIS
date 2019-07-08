using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WinAPIS.Entity;

namespace OW.Operation.OW.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : Recharge
    {      
        public string UserName { get; set; }

        public string UserPhone { get; set; }

        public string UserSex { get; set; }

        public string Usersfz { get; set; }

        public int UserTypeID { get; set; }
    }
}