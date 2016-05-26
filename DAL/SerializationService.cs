using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    class SerializationService
    {
        #region  BasicMethod

        /// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Ser_ID", "T_Serialization");
        }

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int Ser_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Serialization ");
            strSql.Append(" where Ser_ID=@Ser_ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Ser_ID", SqlDbType.Int,4)
            };
            parameters[0].Value = Ser_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T_Serialization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Serialization(");
            strSql.Append("Ser_Code,Ser_Description,Ser_AllLenght,Ser_Prefix,Ser_CurrentDate,Ser_SegNo,Ser_Clear)");
            strSql.Append(" values (");
            strSql.Append("@Ser_Code,@Ser_Description,@Ser_AllLenght,@Ser_Prefix,@Ser_CurrentDate,@Ser_SegNo,@Ser_Clear)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Ser_Code", SqlDbType.VarChar,50),
                    new SqlParameter("@Ser_Description", SqlDbType.VarChar,20),
                    new SqlParameter("@Ser_AllLenght", SqlDbType.Int,4),
                    new SqlParameter("@Ser_Prefix", SqlDbType.VarChar,20),
                    new SqlParameter("@Ser_CurrentDate", SqlDbType.DateTime),
                    new SqlParameter("@Ser_SegNo", SqlDbType.Int,4),
                    new SqlParameter("@Ser_Clear", SqlDbType.Int,4)};
            parameters[0].Value = model.Ser_Code;
            parameters[1].Value = model.Ser_Description;
            parameters[2].Value = model.Ser_AllLenght;
            parameters[3].Value = model.Ser_Prefix;
            parameters[4].Value = model.Ser_CurrentDate;
            parameters[5].Value = model.Ser_SegNo;
            parameters[6].Value = model.Ser_Clear;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(T_Serialization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Serialization set ");
            strSql.Append("Ser_Description=@Ser_Description,");
            strSql.Append("Ser_AllLenght=@Ser_AllLenght,");
            strSql.Append("Ser_Prefix=@Ser_Prefix,");
            strSql.Append("Ser_CurrentDate=@Ser_CurrentDate,");
            strSql.Append("Ser_SegNo=@Ser_SegNo,");
            strSql.Append("Ser_Clear=@Ser_Clear");
            strSql.Append(" where Ser_Code=@Ser_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@Ser_Code", SqlDbType.VarChar,50),
                    new SqlParameter("@Ser_Description", SqlDbType.VarChar,20),
                    new SqlParameter("@Ser_AllLenght", SqlDbType.Int,4),
                    new SqlParameter("@Ser_Prefix", SqlDbType.VarChar,20),
                    new SqlParameter("@Ser_CurrentDate", SqlDbType.DateTime),
                    new SqlParameter("@Ser_SegNo", SqlDbType.Int,4),
                    new SqlParameter("@Ser_Clear", SqlDbType.Int,4)};
            parameters[0].Value = model.Ser_Code;
            parameters[1].Value = model.Ser_Description;
            parameters[2].Value = model.Ser_AllLenght;
            parameters[3].Value = model.Ser_Prefix;
            parameters[4].Value = model.Ser_CurrentDate;
            parameters[5].Value = model.Ser_SegNo;
            parameters[6].Value = model.Ser_Clear;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Ser_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Serialization ");
            strSql.Append(" where Ser_ID=@Ser_ID");
            SqlParameter[] parameters = {
                new SqlParameter("@Ser_ID", SqlDbType.Int)
            };
            parameters[0].Value = Ser_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Cli_Codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Serialization ");
            strSql.Append(" where Ser_ID in (" + Cli_Codelist + ") ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public T_Serialization GetModel(string Ser_ID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Ser_ID,Ser_Code,Ser_Description,Ser_AllLenght,Ser_Prefix,Ser_CurrentDate,Ser_SegNo,Ser_Clear from T_Serialization ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            T_Serialization model = new T_Serialization();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_Serialization DataRowToModel(DataRow row)
        {
            T_Serialization model = new T_Serialization();
            if (row != null)
            {
                if (row["Ser_Code"] != null)
                {
                    model.Ser_Code = row["Ser_Code"].ToString();
                }
                if (row["Ser_Description"] != null)
                {
                    model.Ser_Description = row["Ser_Description"].ToString();
                }
                if (row["Ser_AllLenght"] != null && row["Ser_AllLenght"].ToString() != "")
                {
                    model.Ser_AllLenght = int.Parse(row["Ser_AllLenght"].ToString());
                }
                if (row["Ser_Prefix"] != null)
                {
                    model.Ser_Prefix = row["Ser_Prefix"].ToString();
                }
                if (row["Ser_CurrentDate"] != null && row["Ser_CurrentDate"].ToString() != "")
                {
                    model.Ser_CurrentDate = DateTime.Parse(row["Ser_CurrentDate"].ToString());
                }
                if (row["Ser_SegNo"] != null && row["Ser_SegNo"].ToString() != "")
                {
                    model.Ser_SegNo = int.Parse(row["Ser_SegNo"].ToString());
                }
                if (row["Ser_Clear"] != null && row["Ser_Clear"].ToString() != "")
                {
                    model.Ser_Clear = int.Parse(row["Ser_Clear"].ToString());
                }
                if (row["Ser_ID"] != null)
                {
                    model.Ser_ID = row["Ser_ID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Ser_ID,Ser_Code,Ser_Description,Ser_AllLenght,Ser_Prefix,Ser_CurrentDate,Ser_SegNo,Ser_Clear");
            strSql.Append(" FROM T_Serialization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Ser_ID,Ser_Code,Ser_Description,Ser_AllLenght,Ser_Prefix,Ser_CurrentDate,Ser_SegNo,Ser_Clear ");
            strSql.Append(" FROM T_Serialization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_Serialization ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Sell_Lineno desc");
            }
            strSql.Append(")AS Row, T.*  from T_Serialization T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Serialization";
			parameters[1].Value = "Sell_Lineno";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod

        #region  ExtensionMethod



        #endregion  ExtensionMethod
    }
}
