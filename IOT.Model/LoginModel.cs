using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    //管理员表
    public class LoginModel
    {
        public int Lid			 { get; set; }
        public string Lname		 { get; set; }
        public string Lpass		 { get; set; }
        public string Lportrait	 { get; set; }
        public int Lrid { get; set; }
        public string Rname { get; set; }
    }
    //角色表
    public class Roles
    {
        public int Rid		 { get; set; }
        public string Rname	 { get; set; }
        public int Rstate	 { get; set; }
    }
    //用户表
    public class UserModel
    {
        public int Uid     { get; set; }
        public string Uname   { get; set; }
        public string Upwd    { get; set; }
        public string Upwds { get; set; }
        public decimal UBalance { get; set; }
    }
}
