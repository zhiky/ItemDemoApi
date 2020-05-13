using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class LoginDal
    {
        string connStr= "Data Source=.;Initial Catalog=Lazy_e_commerce;Integrated Security=True";
        //绑定角色下拉
        public List<Roles> BandRoles()
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Roles";

                DataTable dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                var rolesLists = new List<Roles>();
                foreach (DataRow dr in dt.Rows)
                {
                    var rolesList = new Roles();
                    rolesList.Rid = Convert.ToInt32(dr["Rid"]);
                    rolesList.Rname = dr["Rname"].ToString();
                    rolesList.Rstate = Convert.ToInt32(dr["Rstate"]);
                    rolesLists.Add(rolesList);
                }
                return rolesLists;
            }
        }
        //管理员列表显示
        public List<LoginModel> LoginShow()
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select  *  from Logins join Roles on Logins.Lrid=Roles.Rid";

                DataTable dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                var loginLists = new List<LoginModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    var loginList = new LoginModel();
                    loginList.Lid = Convert.ToInt32(dr["Lid"]);
                    loginList.Lname = dr["Lname"].ToString();
                    loginList.Lpass = dr["Lpass"].ToString();
                    //loginList.Lportrait = dr["Lportrait"].ToString();
                    loginList.Lrid = Convert.ToInt32(dr["Lrid"]);
                    loginList.Rname = dr["Rname"].ToString();
                    loginLists.Add(loginList);
                }
                return loginLists;
            }
        }
        //添加管理员
        public int AddLogin(LoginModel m)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("insert into Logins values('{0}','{1}','{2}')",m.Lname, Md6Encrypt(m.Lpass),m.Lrid);
                return cmd.ExecuteNonQuery();
            }
        }
        //用户登录
        public int UserLogin(UserModel m)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("select count(1) from UserLogin where Uname='{0}' and Upwd='{1}'",m.Uname, Md6Encrypt(m.Upwd));
                return (int) cmd.ExecuteScalar();
            }
        }
        //查询用户信息
        public UserModel UserLogin(string name)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"select * from UserLogin where Uname='{name}'";
                DataTable dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                var loginLists = new List<UserModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    var loginList = new UserModel();
                    loginList.Uid = Convert.ToInt32(dr["Uid"]);
                    loginList.Uname = dr["Uname"].ToString();
                    loginList.Upwd = dr["Upwd"].ToString();
                    //loginList.Lportrait = dr["Lportrait"].ToString();
                    loginList.Upwds = Convert.ToString(dr["Upwds"]);

                    loginLists.Add(loginList);
                }
                return loginLists[0];
            }
        }
        //注册
        public int AddUser(UserModel m)
        {
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("insert into UserLogin values('{0}','{1}','{2}','{3}')", m.Uname, Md6Encrypt(m.Upwd),m.Upwds,m.UBalance);
                return cmd.ExecuteNonQuery ();
            }
        }
        //MD6加密
        /// <summary>
        /// MD6加密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Md6Encrypt(string strSource)
        {
            //把字符串放到byte数组中
            byte[] bytIn = Encoding.Default.GetBytes(strSource);
            //建立加密对象的密钥和偏移量
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥
                                                              //实例DES加密类
            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.Key = iv;
            mobjCryptoService.IV = key;
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            //实例MemoryStream流加密密文件
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            string strOut = System.Convert.ToBase64String(ms.ToArray());
            return strOut;

        }
    }
}
