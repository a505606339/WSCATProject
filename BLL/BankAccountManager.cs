using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BankAccountManager
    {
        BankAccountService bas = new BankAccountService();

        #region 添加信息
        /// <summary>
        /// 添信息
        /// </summary>
        /// <param name="tba">参数实体类</param>
        /// <returns></returns>
        public int InsBankAccount(T_BankAccount tba)
        {
            return bas.InsBankAccount(tba);
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
            return bas.FalseDelClear(Ba_Code);
        }
        #endregion

        #region 全部删除
        /// <summary>
        /// 全部删除
        /// </summary>
        /// <returns></returns>
        public int FalseALLDelClear()
        {
            return bas.FalseALLDelClear();
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
            return bas.UpdateBA(BA);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IQueryable SelBankAccount(bool isSelState)
        {
            return bas.SelBankAccount(isSelState);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public IQueryable SelBankAccount()
        {
            return bas.SelBankAccount();
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
            return bas.SelBankAccountByCode(Ba_Code);
        }
        #endregion
    }
}
