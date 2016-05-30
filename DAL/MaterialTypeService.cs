using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DAL;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:MaterialType
	/// </summary>
	public partial class MaterialTypeService
    {
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MT_ID", "T_MaterialType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_MaterialType");
			strSql.Append(" where MT_ID=@MT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MT_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = MT_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MaterialType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_MaterialType(");
			strSql.Append("MT_Remark,MT_Enable,MT_Clear,MT_Safetyone,MT_Safetytwo,MT_Code,MT_OneGroup,MT_TwoGroup,MT_ThreeGroup,MT_FourGroup,MT_FiveGroup)");
			strSql.Append(" values (");
			strSql.Append("@MT_Remark,@MT_Enable,@MT_Clear,@MT_Safetyone,@MT_Safetytwo,@MT_Code,@MT_OneGroup,@MT_TwoGroup,@MT_ThreeGroup,@MT_FourGroup,@MT_FiveGroup)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MT_Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Enable", SqlDbType.Int,4),
					new SqlParameter("@MT_Clear", SqlDbType.Int,4),
					new SqlParameter("@MT_Safetyone", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Safetytwo", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Code", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_OneGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_TwoGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_ThreeGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_FourGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_FiveGroup", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.MT_Remark;
			parameters[1].Value = model.MT_Enable;
			parameters[2].Value = model.MT_Clear;
			parameters[3].Value = model.MT_Safetyone;
			parameters[4].Value = model.MT_Safetytwo;
			parameters[5].Value = model.MT_Code;
			parameters[6].Value = model.MT_OneGroup;
			parameters[7].Value = model.MT_TwoGroup;
			parameters[8].Value = model.MT_ThreeGroup;
			parameters[9].Value = model.MT_FourGroup;
			parameters[10].Value = model.MT_FiveGroup;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(MaterialType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_MaterialType set ");
			strSql.Append("MT_Remark=@MT_Remark,");
			strSql.Append("MT_Enable=@MT_Enable,");
			strSql.Append("MT_Clear=@MT_Clear,");
			strSql.Append("MT_Safetyone=@MT_Safetyone,");
			strSql.Append("MT_Safetytwo=@MT_Safetytwo,");
			strSql.Append("MT_Code=@MT_Code,");
			strSql.Append("MT_OneGroup=@MT_OneGroup,");
			strSql.Append("MT_TwoGroup=@MT_TwoGroup,");
			strSql.Append("MT_ThreeGroup=@MT_ThreeGroup,");
			strSql.Append("MT_FourGroup=@MT_FourGroup,");
			strSql.Append("MT_FiveGroup=@MT_FiveGroup");
			strSql.Append(" where MT_ID=@MT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MT_Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Enable", SqlDbType.Int,4),
					new SqlParameter("@MT_Clear", SqlDbType.Int,4),
					new SqlParameter("@MT_Safetyone", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Safetytwo", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_Code", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_OneGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_TwoGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_ThreeGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_FourGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_FiveGroup", SqlDbType.NVarChar,512),
					new SqlParameter("@MT_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.MT_Remark;
			parameters[1].Value = model.MT_Enable;
			parameters[2].Value = model.MT_Clear;
			parameters[3].Value = model.MT_Safetyone;
			parameters[4].Value = model.MT_Safetytwo;
			parameters[5].Value = model.MT_Code;
			parameters[6].Value = model.MT_OneGroup;
			parameters[7].Value = model.MT_TwoGroup;
			parameters[8].Value = model.MT_ThreeGroup;
			parameters[9].Value = model.MT_FourGroup;
			parameters[10].Value = model.MT_FiveGroup;
			parameters[11].Value = model.MT_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int MT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialType ");
			strSql.Append(" where MT_ID=@MT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MT_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = MT_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string MT_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_MaterialType ");
			strSql.Append(" where MT_ID in ("+MT_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public MaterialType GetModel(int MT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MT_ID,MT_Remark,MT_Enable,MT_Clear,MT_Safetyone,MT_Safetytwo,MT_Code,MT_OneGroup,MT_TwoGroup,MT_ThreeGroup,MT_FourGroup,MT_FiveGroup from T_MaterialType ");
			strSql.Append(" where MT_ID=@MT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MT_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = MT_ID;

			MaterialType model=new MaterialType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MaterialType DataRowToModel(DataRow row)
		{
			MaterialType model=new MaterialType();
			if (row != null)
			{
				if(row["MT_ID"]!=null && row["MT_ID"].ToString()!="")
				{
					model.MT_ID=int.Parse(row["MT_ID"].ToString());
				}
				if(row["MT_Remark"]!=null)
				{
					model.MT_Remark=row["MT_Remark"].ToString();
				}
				if(row["MT_Enable"]!=null && row["MT_Enable"].ToString()!="")
				{
					model.MT_Enable=int.Parse(row["MT_Enable"].ToString());
				}
				if(row["MT_Clear"]!=null && row["MT_Clear"].ToString()!="")
				{
					model.MT_Clear=int.Parse(row["MT_Clear"].ToString());
				}
				if(row["MT_Safetyone"]!=null)
				{
					model.MT_Safetyone=row["MT_Safetyone"].ToString();
				}
				if(row["MT_Safetytwo"]!=null)
				{
					model.MT_Safetytwo=row["MT_Safetytwo"].ToString();
				}
				if(row["MT_Code"]!=null)
				{
					model.MT_Code=row["MT_Code"].ToString();
				}
				if(row["MT_OneGroup"]!=null)
				{
					model.MT_OneGroup=row["MT_OneGroup"].ToString();
				}
				if(row["MT_TwoGroup"]!=null)
				{
					model.MT_TwoGroup=row["MT_TwoGroup"].ToString();
				}
				if(row["MT_ThreeGroup"]!=null)
				{
					model.MT_ThreeGroup=row["MT_ThreeGroup"].ToString();
				}
				if(row["MT_FourGroup"]!=null)
				{
					model.MT_FourGroup=row["MT_FourGroup"].ToString();
				}
				if(row["MT_FiveGroup"]!=null)
				{
					model.MT_FiveGroup=row["MT_FiveGroup"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MT_ID,MT_Remark,MT_Enable,MT_Clear,MT_Safetyone,MT_Safetytwo,MT_Code,MT_OneGroup,MT_TwoGroup,MT_ThreeGroup,MT_FourGroup,MT_FiveGroup ");
			strSql.Append(" FROM T_MaterialType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MT_ID,MT_Remark,MT_Enable,MT_Clear,MT_Safetyone,MT_Safetytwo,MT_Code,MT_OneGroup,MT_TwoGroup,MT_ThreeGroup,MT_FourGroup,MT_FiveGroup ");
			strSql.Append(" FROM T_MaterialType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_MaterialType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.MT_ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_MaterialType T ");
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
			parameters[0].Value = "T_MaterialType";
			parameters[1].Value = "MT_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MT_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_MaterialType");
            strSql.Append(" where MT_Code=@MT_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@MT_Code", SqlDbType.VarChar,512)
            };
            parameters[0].Value = MT_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

