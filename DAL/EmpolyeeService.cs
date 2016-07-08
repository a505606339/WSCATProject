using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpolyeeService
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        DepartmentService department = new DepartmentService();
        #region 添加人员信息
        /// <summary>
        /// 添加人员信息
        /// </summary>
        /// <param name="empolyee">参数实体类</param>
        /// <returns></returns>
        public int InsEmpolyee(T_Empolyee empolyee)
        {
            db.T_Empolyee.InsertOnSubmit(empolyee);
            db.SubmitChanges();
            if (empolyee.Emp_ID == 0)
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
        /// <param name="code">客户编码</param>
        /// <returns></returns>
        public int FalseDelClear(string code)
        {
            int result = 0;
            IEnumerable<T_Empolyee> query = from s in db.T_Empolyee where s.Emp_Clear == 1 && s.Emp_Code == code select s;
            foreach (T_Empolyee emp in query)
            {
                emp.Emp_Clear = 0;
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
            IEnumerable<T_Empolyee> query = from s in db.T_Empolyee where s.Emp_Clear == 1 && s.Emp_Enable == 1 select s;
            foreach (T_Empolyee emp in query)
            {
                emp.Emp_Clear = 0;
            }
            result = query.Count();
            db.SubmitChanges();
            return result;
        }
        #endregion

        #region 根据工号修改信息
        /// <summary>
        /// 根据工号修改信息
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int UpdateEmpolyee(T_Empolyee emp)
        {
            var query = db.T_Empolyee.SingleOrDefault(s => s.Emp_Code == emp.Emp_Code);
            if (query == null)
            {
                return 0;
            }
            query.Emp_Name = emp.Emp_Name;
            query.Emp_CardCode = emp.Emp_CardCode;
            query.Emp_Phone = emp.Emp_Phone;
            query.Emp_Card = emp.Emp_Card;
            query.Emp_Birthday = emp.Emp_Birthday;
            query.Emp_Email = emp.Emp_Email;
            query.Emp_School = emp.Emp_School;
            query.Emp_Bank = emp.Emp_Bank;
            query.Emp_OpenBank = emp.Emp_OpenBank;
            query.Emp_Entry = emp.Emp_Entry;
            query.Emp_Depid = emp.Emp_Depid;
            query.Emp_Education = emp.Emp_Education;
            query.Emp_Sex = emp.Emp_Sex;
            query.Emp_Enable = emp.Emp_Enable;
            query.Emp_State = emp.Emp_State;
            query.Emp_Clear = emp.Emp_Clear;
            db.SubmitChanges();
            return 1;
        } 
        #endregion

        #region 根据工号查询信息
        /// <summary>
        /// 根据工号查询信息
        /// </summary>
        /// <param name="Emp_Code">工号</param>
        /// <returns></returns>
        public T_Empolyee SelEmpolyeeByCode(string Emp_Code)
        {
            IQueryable<T_Empolyee> query = (from s in db.T_Empolyee
                                            where s.Emp_Clear == 1 && s.Emp_Enable == 1 && s.Emp_Code == Emp_Code
                                            select s);
            return query.First();
        }
        #endregion

        #region 查询所有信息
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="isflag">是否显示禁用：true显示所有禁用状态的信息，false仅显示未禁用状态的信息</param>
        /// <returns></returns>
        public IQueryable SelEmpolyee(bool isflag)
        {
            var query = from s in db.T_Empolyee
                        where s.Emp_Clear == 1
                        select new
                        {
                            工号 = XYEEncoding.strHexDecode(s.Emp_Code),
                            姓名 = XYEEncoding.strHexDecode(s.Emp_Name),
                            卡号 = XYEEncoding.strHexDecode(s.Emp_CardCode),
                            所属部门 = department.SelDepartmentByCode(XYEEncoding.strHexDecode(s.Emp_Depid)).Dt_Name,
                            性别 = XYEEncoding.strHexDecode(s.Emp_Sex),
                            身份证号 = XYEEncoding.strHexDecode(s.Emp_Card),
                            联系电话 = XYEEncoding.strHexDecode(s.Emp_Phone),
                            银行卡号 = XYEEncoding.strHexDecode(s.Emp_Bank),
                            开户行 = XYEEncoding.strHexDecode(s.Emp_OpenBank),
                            生日 = s.Emp_Birthday,
                            邮箱 = XYEEncoding.strHexDecode(s.Emp_Email),
                            最高学历 = XYEEncoding.strHexDecode(s.Emp_Education),
                            毕业学校 = XYEEncoding.strHexDecode(s.Emp_School),
                            入职时间 = s.Emp_Entry,
                            禁用状态 = s.Emp_Enable == 1 ? "未禁用" : "禁用",
                            就职状态 = s.Emp_State == 1 ? "在职" : "离职"
                        };
            if (isflag == false)
            {
                return query.Where(c => c.禁用状态 == "未禁用");
            }
            return query;
        }
        #endregion
    }
}