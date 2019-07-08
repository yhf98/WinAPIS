using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OW.Operation.OW.Model
{
    public class Msg
    {
        //登录状态
        public int status { get; set; }

        //登录提示
        public string message { get; set; }

        //登录跳转地址
        public string action { get; set; }
    }
}