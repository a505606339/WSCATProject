using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BuyService
    {
        CodingHelper ch = new CodingHelper();
        public DataTable SelBuyDataTable()
        {
            string sql = "select * from T_Buy where Buy_Clear=1";
            SqlDataAdapter dapter = new SqlDataAdapter(sql, DbHelperSQL.connectionString);
            DataSet ds = new DataSet();
            dapter.Fill(ds, "T_Buy");
            return ds.Tables[0];
        }
        public DataTable SelBuyDataTableToCheck()
        {
            string sql = @"select 
buy.Buy_ID as ID,
Buy_Code as 编号,
Buy_Date as 单据日期,
(case 
when Buy_PurchaseStatus=1 then '36352D175E2F'
else '2A502D175E2F' end
) as 单据状态,
Buy_SupplierName as 供应商,
su.Su_Bank as 结算账户,
--结算账户，本次付款，总金额
tbd.Buy_AmountMoney as 总金额,
Buy_SalesMan as 业务员,
buy.Buy_Remark as 备注
from T_Buy buy
left join T_BuyDetail tbd on buy.Buy_Code=tbd.Buy_ID
left join T_Supplier su on buy.Buy_SupplierCode=su.Su_Code";
            SqlDataAdapter dapter = new SqlDataAdapter(sql, DbHelperSQL.connectionString);
            DataSet ds = new DataSet();
            dapter.Fill(ds, "T_Buy");
            return ch.DataTableReCoding(ds.Tables[0]);
        }
        public DataTable SelBuyByCodeDataTable(string code)
        {
            string sql = string.Format("select * from T_Buy where Buy_Clear=1 and Buy_Code={0}", code);
            SqlDataAdapter dapter = new SqlDataAdapter(sql, DbHelperSQL.connectionString);
            DataSet ds = new DataSet();
            dapter.Fill(ds, "T_Buy");
            return ds.Tables[0];
        }
        public List<Buy> SelBuyByCode(string code)
        {
            List<Buy> list = new List<Buy>();
            string sql = string.Format("select * from T_Buy where Buy_Clear=1 and Buy_Code={0}", code);
            SqlDataReader read = DbHelperSQL.ExecuteReader(sql);
            while (read.Read())
            {
                Buy buy = new Buy()
                {
                    Buy_ID = Convert.ToInt32(read["Buy_ID"]),
                    Buy_Code = read["Buy_Code"].ToString(),
                    Buy_Date = Convert.ToDateTime(read["Buy_Date"])
                };
                list.Add(buy);
            }
            return list;
        }
    }
}
