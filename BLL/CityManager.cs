using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using HelperUtility.Encrypt;
using System.Data;

namespace BLL
{
    public class CityManager
    {
        private readonly CityService dal = new CityService();

        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int City_ID)
        {
            return dal.Exists(City_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(City model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(City model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int City_ID)
        {

            return dal.Delete(City_ID);
        }
        /// <summary>
        /// 删除一条数据 
        /// </summary>
        public bool DeleteList(string City_IDlist)
        {
            return dal.DeleteList(HelperUtility.Validate.RegexValidate.SafeLongFilter(City_IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public City GetModel(int City_ID)
        {

            return dal.GetModel(City_ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<City> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<City> DataTableToList(DataTable dt)
        {
            List<City> modelList = new List<City>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                City model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        // 分页获取数据列表
                //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        #region ExtensionMethod
        
        /// <summary>
        /// 根据code更新数据 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByCode(City model)
        {
            model.City_Name = XYEEncoding.strCodeHex(model.City_Name);
            model.City_Code = XYEEncoding.strCodeHex(model.City_Code);
            model.City_ParentId = XYEEncoding.strCodeHex(model.City_ParentId);
            return dal.UpdateByCode(model);
        }

        /// <summary>
        /// 根据code删除数据
        /// </summary>
        /// <param name="City_Code"></param>
        /// <returns></returns>
        public bool DeleteByCode(string City_Code)
        {
            return dal.DeleteByCode(XYEEncoding.strCodeHex(City_Code));
        }

        #endregion

    }
}
