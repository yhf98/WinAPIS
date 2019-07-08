using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAPIS.DBH
{
   public class DataServer
    {
        public static bool AddCar(string type,string name,string sex,string phone,string sfz,string money)
        {
            try
            {
                int i = 0;
                if(type=="会员车辆")
                {
                    type = i.ToString();
                }
                string sql = "INSERT INTO UserInfo (UserName,UserPhone,UserSex,Usersfz,UserTypeID,Rechargemoney)VALUES("+name+","+sex+","+phone+","+sfz+ "," + type + "," + money+"); ";
              
                return DBHelper.GetBoool(sql);
            }
            catch(Exception e)
            {
                MessageBox.Show("添加失败！");
                return false;
            }
           
            
        }

    }
}
