using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentService
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        #region 添加信息
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="department">参数实体类</param>
        /// <returns></returns>
        public int InsDepartment(T_Department department)
        {
            db.T_Department.InsertOnSubmit(department);
            db.SubmitChanges();
            if (department.Dt_ID == 0)
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
        /// <param name="Dt_Code">编号</param>
        /// <returns></returns>
        public int FalseDelClear(string Dt_Code)
        {
            int result = 0;
            IEnumerable<T_Department> query = from s in db.T_Department where s.Dt_Clear == 1 && s.Dt_Code == Dt_Code select s;
            foreach (T_Department dm in query)
            {
                dm.Dt_Clear = 0;
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
            IEnumerable<T_Department> query = from s in db.T_Department where s.Dt_Clear == 1 select s;
            foreach (T_Department emp in query)
            {
                emp.Dt_Clear = 0;
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
        public IQueryable SelDepartment()
        {
            var query = (from s in db.T_Department
                         where s.Dt_Clear == 1
                         select s);
            return query;
        } 
        #endregion

        #region 根据编号查询信息
        /// <summary>
        /// 根据编号查询信息
        /// </summary>
        /// <param name="Dt_Code">编号</param>
        /// <returns></returns>
        public T_Department SelDepartmentByCode(string Dt_Code)
        {
            IQueryable<T_Department> query = (from s in db.T_Department
                                              where s.Dt_Clear == 1 && s.Dt_Code == Dt_Code
                                              select s);
            return query.First();
        }
        #endregion
    }
}
