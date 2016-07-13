using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class BuyProcessService
    {
        /// <summary>
        /// 增加一条数据 
        /// </summary>
        public int Add(BuyProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_BuyProcess(");
            strSql.Append("BP_Code,BP_SellLineno,BP_Datetime,BP_Opt,BP_Ope,BP_Remark,BP_Clear)");
            strSql.Append(" values (");
            strSql.Append("@BP_Code,@BP_SellLineno,@BP_Datetime,@BP_Opt,@BP_Ope,@BP_Remark,@BP_Clear)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@BP_Code", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_SellLineno", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Datetime", SqlDbType.DateTime),
                    new SqlParameter("@BP_Opt", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Ope", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Remark", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Clear", SqlDbType.Int,4)};
            parameters[0].Value = model.BP_Code;
            parameters[1].Value = model.BP_SellLineno;
            parameters[2].Value = model.BP_Datetime;
            parameters[3].Value = model.BP_Opt;
            parameters[4].Value = model.BP_Ope;
            parameters[5].Value = model.BP_Remark;
            parameters[6].Value = model.BP_Clear;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 根据code更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByCode(BuyProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_BuyProcess set ");
            strSql.Append("BP_SellLineno=@BP_SellLineno,");
            strSql.Append("BP_Datetime=@BP_Datetime,");
            strSql.Append("BP_Opt=@BP_Opt,");
            strSql.Append("BP_Remark=@BP_Remark,");
            strSql.Append("BP_Clear=@BP_Clear");
            strSql.Append(" where BP_Code=@BP_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@BP_SellLineno", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Datetime", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Opt", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Remark", SqlDbType.NVarChar,512),
                    new SqlParameter("@BP_Clear", SqlDbType.Int,4),
                    new SqlParameter("@BP_Code", SqlDbType.NVarChar,512)};
            parameters[0].Value = model.BP_SellLineno;
            parameters[1].Value = model.BP_Datetime;
            parameters[2].Value = model.BP_Opt;
            parameters[3].Value = model.BP_Remark;
            parameters[4].Value = model.BP_Clear;
            parameters[4].Value = model.BP_Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据code删除一条数据 
        /// </summary>
        public bool DeleteFake(string City_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_City ");
            strSql.Append(" where City_Code=@City_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@City_Code", SqlDbType.NVarChar,512)
            };
            parameters[0].Value = City_Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BP_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_BuyProcess");
            strSql.Append(" where BP_Code=@BP_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@BP_Code", SqlDbType.NVarChar,512)
            };
            parameters[0].Value = BP_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表 
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  BP_ID,BP_Code,BP_SellLineno,BP_Datetime,BP_Opt,BP_Ope,BP_Remark,BP_Clear");
            strSql.Append(" FROM T_BuyProcess ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
