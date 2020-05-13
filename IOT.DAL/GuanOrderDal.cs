using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Model;
using System.Data;
using System.Data.SqlClient;
namespace IOT.DAL
{
    public class GuanOrderDal
    {
        //显示订单列表
        public List<GuanOrderModel> GuanOrderList( )
        {
            string sql = "select *,(OrderInfo.Count*OrderInfo.UnitPrice) heji from OrderInfo join GuanProduct on OrderInfo.PId=GuanProduct.Pid join UserLogin on OrderInfo.UId=UserLogin.Uid join ShopType on GuanProduct.Ptype=ShopType.Sid join Brand on GuanProduct.Ppinpai=Brand.Bid join Store on GuanProduct.PstoreId=Store.Stid";
            return DBHelper.GetToList<GuanOrderModel>(sql);
        }
        //查看
        public GuanOrderModel GuanOrderxiang(int id)
        {
            string sql = "select *,(OrderInfo.Count*OrderInfo.UnitPrice) heji from OrderInfo join GuanProduct on OrderInfo.PId=GuanProduct.Pid join UserLogin on OrderInfo.UId=UserLogin.Uid join ShopType on GuanProduct.Ptype=ShopType.Sid join Brand on GuanProduct.Ppinpai=Brand.Bid join Store on GuanProduct.PstoreId=Store.Stid where OrderInfo.OId=" + id;
            return DBHelper.GetToList<GuanOrderModel>(sql).FirstOrDefault();
        }
    }
}
