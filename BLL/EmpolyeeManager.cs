using DAL;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class EmpolyeeManager
    {
        EmpolyeeService es = new EmpolyeeService();
        #region 添加人员信息
        /// <summary>
        /// 添加人员信息
        /// </summary>
        /// <param name="empolyee"></param>
        /// <returns></returns>
        public int InsEmpolyee(T_Empolyee empolyee)
        {
            return es.InsEmpolyee(empolyee);
        }
        #endregion
        #region
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="code">客户编码</param>
        /// <returns></returns>
        public int FalseDelClear(string code)
        {
            return es.FalseDelClear(code);
        }
        #endregion
        #region
        /// <summary>
        /// 全部删除
        /// </summary>
        /// <returns></returns>
        public int FalseALLDelClear()
        {
            return es.FalseALLDelClear();
        }
        #endregion
        public int UpdateEmpolyee(T_Empolyee emp)
        {
            return es.UpdateEmpolyee(emp);
        }
        #region 根据工号查询信息
            /// <summary>
            /// 根据工号查询信息
            /// </summary>
            /// <param name="Emp_Code">工号</param>
            /// <returns></returns>
        public T_Empolyee SelEmpolyeeByCode(string Emp_Code)
        {
            return es.SelEmpolyeeByCode(Emp_Code);
        }
        #endregion
        #region 查询所有信息
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="isflag">是否显示禁用：true显示包含禁用状态的信息，false仅显示未禁用状态的信息</param>
        /// <returns></returns>
        public IQueryable SelEmpolyee(bool isflag)
        {
            return es.SelEmpolyee(isflag);
        }
        #endregion
    }
}