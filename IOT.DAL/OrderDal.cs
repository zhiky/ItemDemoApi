using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using IOT.Model;


namespace IOT.DAL
{
    public class OrderDal
    {
        //添加订单
        public OrderModel AddOrder(int id, string OrderNo)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;
            //执行存储过程
            string sql = string.Format("exec sp_AddOrder {0},'{1}',@Code1 out,@Msg1 out", id, OrderNo);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            //定义实体类
            OrderModel s = new OrderModel();
            s.Code1 = Convert.ToInt32(pCode.Value);
            s.Msg1 = (pMsg.Value).ToString();
            return s;
        }

        //显示订单列表
        public OrderPageInfor OrderList(int Uid,int currentPage,int PageSize)
        {
            if (currentPage < 1) currentPage = 1; //防止当前页小于1 
            //定义输出参数
            var pTotalCount = new SqlParameter("TotalCount", SqlDbType.Int);
            var pShopsnum = new SqlParameter("Shopsum", SqlDbType.Int);
            var pPricesum = new SqlParameter("Pricesum", SqlDbType.Int);
            var pBalabcesum = new SqlParameter("Balancesum", SqlDbType.Int);

            //定义输出参数方向
            pTotalCount.Direction = ParameterDirection.Output;
            pShopsnum.Direction = ParameterDirection.Output;
            pPricesum.Direction = ParameterDirection.Output;
            pBalabcesum.Direction = ParameterDirection.Output;

            //执行存储过程
            string sql = string.Format("exec sp_ShowOrder '{0}','{1}','{2}',@TotalCount out,@Shopsum out,@Pricesum out,@Balancesum out",Uid,currentPage,PageSize);
            var resault = DBHelper.GetToList<OrderModel>(sql, new[] {pTotalCount,pShopsnum,pPricesum,pBalabcesum });

            var p = new OrderPageInfor();
            //定义分页类
            p.orderModels = resault;
            //总记录数
            p.TotalCount = Convert.ToInt32(pTotalCount.Value);
            //每页记录数
            p.PageSize = PageSize;
            //计算总页数
            if (p.TotalCount == 0)
            {
                p.TotalPage = 1;
            }
            else
            if (p.TotalCount % p.PageSize == 0)
            {
                p.TotalPage = p.TotalCount / p.PageSize;
            }
            else
            {
                p.TotalPage = p.TotalCount / p.PageSize + 1;
            }
            p.CurrentPage = currentPage; //当前页
            //防止当前页大于总页数
            if (p.CurrentPage > p.TotalPage)
            {
                return OrderList(Uid, p.TotalPage, p.PageSize); //再查一遍
            }
            if (pShopsnum.Value.ToString() != "")
            {
                p.ShopNum = Convert.ToInt32(pShopsnum.Value); //购买成功商品总数
            }
            if (pPricesum.Value.ToString() != "")
            {
                p.PriceSum = Convert.ToInt32(pPricesum.Value); //合计金额
            }
            if (pBalabcesum.Value.ToString() != "")
            {
                p.Balancesum = Convert.ToInt32(pBalabcesum.Value); //账户余额
            }
            return p;

        }
        //退货功能
        public Return Returns(int id)
        {
            //定义输出参数
            var pCode = new SqlParameter("Code1", SqlDbType.Int);
            var pMsg = new SqlParameter("Msg1", SqlDbType.VarChar);
            pMsg.Size = 50;
            //定义输出参数方向
            pCode.Direction = ParameterDirection.Output;
            pMsg.Direction = ParameterDirection.Output;

            //执行存储过程
            string sql = string.Format("exec sp_TurnBackOrder '{0}',@Code1 out,@Msg1 out", id);
            var resault = DBHelper.ExecuteNonQuery(sql, new[] { pCode, pMsg });

            var d = new Return();
            d.Code = Convert.ToInt32(pCode.Value);
            d.Msg = Convert.ToString(pMsg.Value);

            return d;
        }
    }
}
