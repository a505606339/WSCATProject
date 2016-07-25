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
        public DataTable SelBuyDataTable()
        {
            string sql = "select * from T_Buy where Buy_Clear=1";
            SqlDataAdapter dapter = new SqlDataAdapter(sql, DbHelperSQL.connectionString);
            DataSet ds = new DataSet();
            dapter.Fill(ds, "T_Buy");
            return ds.Tables[0];
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
