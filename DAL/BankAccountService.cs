using HelperUtility.Encrypt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BankAccountService
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        #region 添加信息
        /// <summary>
        /// 添信息
        /// </summary>
        /// <param name="tba">参数实体类</param>
        /// <returns></returns>
        public int InsBankAccount(T_BankAccount tba)
        {
            db.T_BankAccount.InsertOnSubmit(tba);
            db.SubmitChanges();
            if (tba.Ba_ID == 0)
            {
                return 0;
            }
            return 1;
        }
        #endregion

        #region 假删除
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="Ba_Code">编号</param>
        /// <returns></returns>
        public int FalseDelClear(string Ba_Code)
        {
            int result = 0;
            IEnumerable<T_BankAccount> query = from s in db.T_BankAccount where s.Ba_Code == XYEEncoding.strCodeHex(Ba_Code) && s.Ba_Clear == 1 select s;
            foreach (T_BankAccount dm in query)
            {
                dm.Ba_Clear = 0;
            }
            result = query.Count();
            db.SubmitChanges();
            return result;
        }
        #endregion

        #region 全部删除
        /// <summary>
        /// 全部删除
        /// </summary>
        /// <returns></returns>
        public int FalseALLDelClear()
        {
            int result = 0;
            IEnumerable<T_BankAccount> query = from s in db.T_BankAccount where s.Ba_Clear == 1 select s;
            foreach (T_BankAccount emp in query)
            {
                emp.Ba_Clear = 0;
            }
            result = query.Count();
            db.SubmitChanges();
            return result;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IQueryable SelBankAccount()
        {
            var query = from s in db.T_BankAccount
                        where s.Ba_Clear == 1
                        select new
                        {
                            ID = s.Ba_ID,
                            编码 = XYEEncoding.strHexDecode(s.Ba_Code),
                            开户行 = XYEEncoding.strHexDecode(s.Ba_OpenBank),
                            银行账号 = XYEEncoding.strHexDecode(s.Ba_Account),
                            持卡人 = XYEEncoding.strHexDecode(s.Ba_CardHolder),
                            备注 = XYEEncoding.strHexDecode(s.Ba_Remark),
                            可用金额 = XYEEncoding.strHexDecode(s.Ba_AvailablePrice),
                            禁用状态 = XYEEncoding.strHexDecode(s.Ba_Enable == 1 ? "未禁用" : "禁用")
                        };
            return query;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IQueryable SelBankAccount(bool isSelState)
        {
            var query = from s in db.T_BankAccount
                        where s.Ba_Clear == 1
                        select new
                        {
                            ID = s.Ba_ID,
                            编码 = XYEEncoding.strHexDecode(s.Ba_Code),
                            开户行 = XYEEncoding.strHexDecode(s.Ba_OpenBank),
                            银行账号 = XYEEncoding.strHexDecode(s.Ba_Account),
                            持卡人 = XYEEncoding.strHexDecode(s.Ba_CardHolder),
                            备注 = XYEEncoding.strHexDecode(s.Ba_Remark),
                            可用金额 = XYEEncoding.strHexDecode(s.Ba_AvailablePrice),
                            禁用状态 = s.Ba_Enable == 1 ? "未禁用" : "禁用"
                        };
            if (isSelState == false)
            {
                return query.Where(c => c.禁用状态 == "未禁用");
            }
            return query;
        }
        #endregion

        #region 根据编号修改信息
        /// <summary>
        /// 根据编号修改信息
        /// </summary>
        /// <param name="BA"></param>
        /// <returns></returns>
        public int UpdateBA(T_BankAccount BA)
        {
            var query = db.T_BankAccount.SingleOrDefault(s => s.Ba_Code == XYEEncoding.strCodeHex(BA.Ba_Code));
            query.Ba_OpenBank = XYEEncoding.strCodeHex(BA.Ba_OpenBank);
            query.Ba_Account = XYEEncoding.strCodeHex(BA.Ba_Account);
            query.Ba_CardHolder = XYEEncoding.strCodeHex(BA.Ba_CardHolder);
            query.Ba_Remark = XYEEncoding.strCodeHex(BA.Ba_Remark);
            query.Ba_AvailablePrice = XYEEncoding.strCodeHex(BA.Ba_AvailablePrice);
            query.Ba_Enable = BA.Ba_Enable;
            query.Ba_Clear = BA.Ba_Clear;
            if (query == null)
            {
                return 0;
            }
            db.SubmitChanges();
            return 1;
        }
        #endregion

        #region 根据编号查询信息
        /// <summary>
        /// 根据编号查询信息
        /// </summary>
        /// <param name="Ba_Code">编号</param>
        /// <returns></returns>
        public T_BankAccount SelBankAccountByCode(string Ba_Code)
        {
            IQueryable<T_BankAccount> query = (from s in db.T_BankAccount
                                               where s.Ba_Clear == 1 && s.Ba_Code == XYEEncoding.strCodeHex(Ba_Code)
                                               select s);
            return query.First();
        }
        #endregion

        #region 查询所有信息
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>所有数据以DataTable的形式返回</returns>
//        public DataTable Sel()
//        {
//            string sql = @"select 
//Su_Code as 编码,
//Su_Name as 单位名称,
//Su_Address as 通讯地址,
//Su_EmpName as 联系人,
//Su_EmpPhone as 联系手机,
//Su_fax as 传真,
//Su_Email as 邮箱,
//Su_Credit as 信用等级,
//Su_Money as 账款额度,
//Su_Surplus as 剩余额度,
//Su_Reckoning as 月结日,
//Su_CityName as 城市,
//Su_Remark as 备注,
//(case 
//when Su_Enable=1 then '2A50591F3727' 
//else '3635591F3727' end)
//as 是否禁用
//from T_Supplier where Su_Clear=1 and Su_Enable=1";
//            SqlDataAdapter adapter = new SqlDataAdapter(sql, DbHelperSQL.connectionString);
//            DataSet ds = new DataSet();
//            adapter.Fill(ds, "T_Supplier");
//            return ds.Tables[0];
//        }
        #endregion
    }
}
