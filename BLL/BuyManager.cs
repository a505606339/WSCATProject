using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BuyManager
    {
        BuyService bs = new BuyService();
        public DataTable SelBuyDataTable()
        {
            return bs.SelBuyDataTable();
        }
        public DataTable SelBuyDataTableToCheck()
        {
            return bs.SelBuyDataTableToCheck();
        }
        public DataTable SelBuyByCodeDataTable(string code)
        {
            return bs.SelBuyByCodeDataTable(code);
        }
        public List<Buy> SelBuyByCode(string code)
        {
            return bs.SelBuyByCode(code);
        }

        /// <summary>
        /// 批量增加多条数据到销售单
        /// </summary>
        /// <param name="buyValues">主单数据,数量为22个字段</param>
        /// <param name="detailList">从单数据,商品的信息.17个字段</param>
        /// <returns>受影响的行数</returns>
        public int AddBatch(Buy buy, List<BuyDetail> buyDetail)
        {
            if (buy==null)
            {
                return 0;
            }
            if (buyDetail.Count() < 1)
            {
                return 0;
            }
            StringBuilder sb;
            List<string> sqlList = new List<string>();
            sb = new StringBuilder();
            sb.Append("insert into T_Buy(");
            sb.Append("Buy_Code,Buy_Date,");
            sb.Append("Buy_SupplierCode,Buy_SupplierName,Buy_PurchaseStatus,Buy_AuditStatus,");
            sb.Append("Buy_PurchaserID,Buy_SalesMan,Buy_Operation,Buy_AuditMan,Buy_Remark,Buy_Clear,Buy_IsPay,Buy_PayMethod,");
            sb.Append("Buy_IsPutSto,Buy_Class");
            sb.Append(") values ('");
            sb.Append(buy.Buy_Code + "','" + buy.Buy_Date + "','" + buy.Buy_suppliercode + "','"
                + buy.Buy_suppliername + "'," + buy.Buy_PurchaseStatus + "," + buy.Buy_AuditStatus + ",'"
                + buy.Buy_PurchaserID + "','" + buy.Buy_SalesMan + "','" + buy.Buy_Operation + "','"
                + buy.Buy_AuditMan + "','" + buy.Buy_Remark + "'," + buy.Buy_Clear + ","
                + buy.Buy_IsPay + "," + buy.Buy_PayMethod + "," + buy.Buy_IsPutSto + ",'"
                + buy.Buy_class + "')");
            sqlList.Add(sb.ToString());

            foreach (BuyDetail value in buyDetail)
            {
                sb = new StringBuilder();
                sb.Append("insert into T_BuyDetail(");
                sb.Append("Buy_LineCode,Buy_StockCode,Buy_StockName,Buy_Code,Buy_MaID,Buy_MaName,");
                sb.Append("Buy_Model,Buy_Unit,Buy_CurNumber,Buy_DiscountAPrice,");
                sb.Append("Buy_Discount,Buy_DiscountBPrice,Buy_AmountMoney,Buy_Clear,Buy_Remark");
                sb.Append(") values ('");
                sb.Append(value.Buy_LineCode + "','" + value.Buy_StockCode + "','" + 
                    value.Buy_StockName + "','" + value.Buy_Code + "','"+ value.Buy_MaID + "','" + 
                    value.Buy_MaName + "','" + value.Buy_Model + "','" + value.Buy_Unit + "','" + 
                    value.Buy_CurNumber + "','" + value.Buy_DiscountAPrice + "','" + value.Buy_Discount + "','" + 
                    value.Buy_DiscountBPrice + "','" + value.Buy_AmountMoney + "'," + value.Buy_Clear + ",'" +
                    value.Buy_Remark + "')");
                sqlList.Add(sb.ToString());
            }
            try
            {
                int influenceRow = bs.AddBatch(sqlList);
                return influenceRow;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
