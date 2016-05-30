using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DAL;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Client
	/// </summary>
	public partial class ClientService
	{
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Cli_ID", "T_Client"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Cli_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Client");
			strSql.Append(" where Cli_ID=@Cli_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Cli_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Cli_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Client model)
		{
            
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Client(");
			strSql.Append("Cli_Code,Cli_zhiwen,Cli_Name,Cli_PicName,Cli_Phone,Cli_PhoneTwo,Cli_faxes,Cli_area,Cli_Address,Cli_LinkMan,Cli_TypeCode,Cli_DiscountCode,Cli_Bankaccounts,Cli_OpenBank,Cli_Olddata,Cli_Oldreturn,Cli_Newoutdata,Cli_Newintodata,Cli_Createdata,Cli_Limit,Cli_RemainLimit,Cli_ClearLimitdate,Cli_ShouldMoney,Cli_GetMoney,Cli_PreMoney,Cli_Remark,Cli_safetone,Cli_safettwo,Cli_Enable)");
			strSql.Append(" values (");
			strSql.Append("@Cli_Code,@Cli_zhiwen,@Cli_Name,@Cli_PicName,@Cli_Phone,@Cli_PhoneTwo,@Cli_faxes,@Cli_area,@Cli_Address,@Cli_LinkMan,@Cli_TypeCode,@Cli_DiscountCode,@Cli_Bankaccounts,@Cli_OpenBank,@Cli_Olddata,@Cli_Oldreturn,@Cli_Newoutdata,@Cli_Newintodata,@Cli_Createdata,@Cli_Limit,@Cli_RemainLimit,@Cli_ClearLimitdate,@Cli_ShouldMoney,@Cli_GetMoney,@Cli_PreMoney,@Cli_Remark,@Cli_safetone,@Cli_safettwo,@Cli_Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Cli_Code", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_zhiwen", SqlDbType.NVarChar,-1),
					new SqlParameter("@Cli_Name", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PicName", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Phone", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PhoneTwo", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_faxes", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_area", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Address", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_LinkMan", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_TypeCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_DiscountCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Bankaccounts", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_OpenBank", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Olddata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Oldreturn", SqlDbType.DateTime),
					new SqlParameter("@Cli_Newoutdata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Newintodata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Createdata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Limit", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_RemainLimit", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_ClearLimitdate", SqlDbType.DateTime),
					new SqlParameter("@Cli_ShouldMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_GetMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PreMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Remark", SqlDbType.NVarChar,1024),
					new SqlParameter("@Cli_safetone", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_safettwo", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Enable", SqlDbType.Int,4)};
			parameters[0].Value = model.Cli_Code;
			parameters[1].Value = model.Cli_zhiwen;
			parameters[2].Value = model.Cli_Name;
			parameters[3].Value = model.Cli_PicName;
			parameters[4].Value = model.Cli_Phone;
			parameters[5].Value = model.Cli_PhoneTwo;
			parameters[6].Value = model.Cli_faxes;
			parameters[7].Value = model.Cli_area;
			parameters[8].Value = model.Cli_Address;
			parameters[9].Value = model.Cli_LinkMan;
			parameters[10].Value = model.Cli_TypeCode;
			parameters[11].Value = model.Cli_DiscountCode;
			parameters[12].Value = model.Cli_Bankaccounts;
			parameters[13].Value = model.Cli_OpenBank;
			parameters[14].Value = model.Cli_Olddata;
			parameters[15].Value = model.Cli_Oldreturn;
			parameters[16].Value = model.Cli_Newoutdata;
			parameters[17].Value = model.Cli_Newintodata;
			parameters[18].Value = model.Cli_Createdata;
			parameters[19].Value = model.Cli_Limit;
			parameters[20].Value = model.Cli_RemainLimit;
			parameters[21].Value = model.Cli_ClearLimitdate;
			parameters[22].Value = model.Cli_ShouldMoney;
			parameters[23].Value = model.Cli_GetMoney;
			parameters[24].Value = model.Cli_PreMoney;
			parameters[25].Value = model.Cli_Remark;
			parameters[26].Value = model.Cli_safetone;
			parameters[27].Value = model.Cli_safettwo;
			parameters[28].Value = model.Cli_Enable;

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
		public bool Update(Client model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Client set ");
			strSql.Append("Cli_Code=@Cli_Code,");
			strSql.Append("Cli_zhiwen=@Cli_zhiwen,");
			strSql.Append("Cli_Name=@Cli_Name,");
			strSql.Append("Cli_PicName=@Cli_PicName,");
			strSql.Append("Cli_Phone=@Cli_Phone,");
			strSql.Append("Cli_PhoneTwo=@Cli_PhoneTwo,");
			strSql.Append("Cli_faxes=@Cli_faxes,");
			strSql.Append("Cli_area=@Cli_area,");
			strSql.Append("Cli_Address=@Cli_Address,");
			strSql.Append("Cli_LinkMan=@Cli_LinkMan,");
			strSql.Append("Cli_TypeCode=@Cli_TypeCode,");
			strSql.Append("Cli_DiscountCode=@Cli_DiscountCode,");
			strSql.Append("Cli_Bankaccounts=@Cli_Bankaccounts,");
			strSql.Append("Cli_OpenBank=@Cli_OpenBank,");
			strSql.Append("Cli_Olddata=@Cli_Olddata,");
			strSql.Append("Cli_Oldreturn=@Cli_Oldreturn,");
			strSql.Append("Cli_Newoutdata=@Cli_Newoutdata,");
			strSql.Append("Cli_Newintodata=@Cli_Newintodata,");
			strSql.Append("Cli_Createdata=@Cli_Createdata,");
			strSql.Append("Cli_Limit=@Cli_Limit,");
			strSql.Append("Cli_RemainLimit=@Cli_RemainLimit,");
			strSql.Append("Cli_ClearLimitdate=@Cli_ClearLimitdate,");
			strSql.Append("Cli_ShouldMoney=@Cli_ShouldMoney,");
			strSql.Append("Cli_GetMoney=@Cli_GetMoney,");
			strSql.Append("Cli_PreMoney=@Cli_PreMoney,");
			strSql.Append("Cli_Remark=@Cli_Remark,");
			strSql.Append("Cli_safetone=@Cli_safetone,");
			strSql.Append("Cli_safettwo=@Cli_safettwo,");
			strSql.Append("Cli_Enable=@Cli_Enable");
			strSql.Append(" where Cli_ID=@Cli_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Cli_Code", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_zhiwen", SqlDbType.NVarChar,-1),
					new SqlParameter("@Cli_Name", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PicName", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Phone", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PhoneTwo", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_faxes", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_area", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Address", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_LinkMan", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_TypeCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_DiscountCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Bankaccounts", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_OpenBank", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Olddata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Oldreturn", SqlDbType.DateTime),
					new SqlParameter("@Cli_Newoutdata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Newintodata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Createdata", SqlDbType.DateTime),
					new SqlParameter("@Cli_Limit", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_RemainLimit", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_ClearLimitdate", SqlDbType.DateTime),
					new SqlParameter("@Cli_ShouldMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_GetMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_PreMoney", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Remark", SqlDbType.NVarChar,1024),
					new SqlParameter("@Cli_safetone", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_safettwo", SqlDbType.NVarChar,512),
					new SqlParameter("@Cli_Enable", SqlDbType.Int,4),
					new SqlParameter("@Cli_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Cli_Code;
			parameters[1].Value = model.Cli_zhiwen;
			parameters[2].Value = model.Cli_Name;
			parameters[3].Value = model.Cli_PicName;
			parameters[4].Value = model.Cli_Phone;
			parameters[5].Value = model.Cli_PhoneTwo;
			parameters[6].Value = model.Cli_faxes;
			parameters[7].Value = model.Cli_area;
			parameters[8].Value = model.Cli_Address;
			parameters[9].Value = model.Cli_LinkMan;
			parameters[10].Value = model.Cli_TypeCode;
			parameters[11].Value = model.Cli_DiscountCode;
			parameters[12].Value = model.Cli_Bankaccounts;
			parameters[13].Value = model.Cli_OpenBank;
			parameters[14].Value = model.Cli_Olddata;
			parameters[15].Value = model.Cli_Oldreturn;
			parameters[16].Value = model.Cli_Newoutdata;
			parameters[17].Value = model.Cli_Newintodata;
			parameters[18].Value = model.Cli_Createdata;
			parameters[19].Value = model.Cli_Limit;
			parameters[20].Value = model.Cli_RemainLimit;
			parameters[21].Value = model.Cli_ClearLimitdate;
			parameters[22].Value = model.Cli_ShouldMoney;
			parameters[23].Value = model.Cli_GetMoney;
			parameters[24].Value = model.Cli_PreMoney;
			parameters[25].Value = model.Cli_Remark;
			parameters[26].Value = model.Cli_safetone;
			parameters[27].Value = model.Cli_safettwo;
			parameters[28].Value = model.Cli_Enable;
			parameters[29].Value = model.Cli_ID;

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
		public bool Delete(int Cli_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Client ");
			strSql.Append(" where Cli_ID=@Cli_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Cli_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Cli_ID;

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
		public bool DeleteList(string Cli_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Client ");
			strSql.Append(" where Cli_ID in ("+Cli_IDlist + ")  ");
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
		public Client GetModel(int Cli_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Cli_ID,Cli_Code,Cli_zhiwen,Cli_Name,Cli_PicName,Cli_Phone,Cli_PhoneTwo,Cli_faxes,Cli_area,Cli_Address,Cli_LinkMan,Cli_TypeCode,Cli_DiscountCode,Cli_Bankaccounts,Cli_OpenBank,Cli_Olddata,Cli_Oldreturn,Cli_Newoutdata,Cli_Newintodata,Cli_Createdata,Cli_Limit,Cli_RemainLimit,Cli_ClearLimitdate,Cli_ShouldMoney,Cli_GetMoney,Cli_PreMoney,Cli_Remark,Cli_safetone,Cli_safettwo,Cli_Enable from T_Client ");
			strSql.Append(" where Cli_ID=@Cli_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Cli_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Cli_ID;

			Client model=new Client();
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
		public Client DataRowToModel(DataRow row)
		{
			Client model=new Client();
			if (row != null)
			{
				if(row["Cli_ID"]!=null && row["Cli_ID"].ToString()!="")
				{
					model.Cli_ID=int.Parse(row["Cli_ID"].ToString());
				}
				if(row["Cli_Code"]!=null)
				{
					model.Cli_Code=row["Cli_Code"].ToString();
				}
				if(row["Cli_zhiwen"]!=null)
				{
					model.Cli_zhiwen=row["Cli_zhiwen"].ToString();
				}
				if(row["Cli_Name"]!=null)
				{
					model.Cli_Name=row["Cli_Name"].ToString();
				}
				if(row["Cli_PicName"]!=null)
				{
					model.Cli_PicName=row["Cli_PicName"].ToString();
				}
				if(row["Cli_Phone"]!=null)
				{
					model.Cli_Phone=row["Cli_Phone"].ToString();
				}
				if(row["Cli_PhoneTwo"]!=null)
				{
					model.Cli_PhoneTwo=row["Cli_PhoneTwo"].ToString();
				}
				if(row["Cli_faxes"]!=null)
				{
					model.Cli_faxes=row["Cli_faxes"].ToString();
				}
				if(row["Cli_area"]!=null)
				{
					model.Cli_area=row["Cli_area"].ToString();
				}
				if(row["Cli_Address"]!=null)
				{
					model.Cli_Address=row["Cli_Address"].ToString();
				}
				if(row["Cli_LinkMan"]!=null)
				{
					model.Cli_LinkMan=row["Cli_LinkMan"].ToString();
				}
				if(row["Cli_TypeCode"]!=null)
				{
					model.Cli_TypeCode=row["Cli_TypeCode"].ToString();
				}
				if(row["Cli_DiscountCode"]!=null)
				{
					model.Cli_DiscountCode=row["Cli_DiscountCode"].ToString();
				}
				if(row["Cli_Bankaccounts"]!=null)
				{
					model.Cli_Bankaccounts=row["Cli_Bankaccounts"].ToString();
				}
				if(row["Cli_OpenBank"]!=null)
				{
					model.Cli_OpenBank=row["Cli_OpenBank"].ToString();
				}
				if(row["Cli_Olddata"]!=null && row["Cli_Olddata"].ToString()!="")
				{
					model.Cli_Olddata=DateTime.Parse(row["Cli_Olddata"].ToString());
				}
				if(row["Cli_Oldreturn"]!=null && row["Cli_Oldreturn"].ToString()!="")
				{
					model.Cli_Oldreturn=DateTime.Parse(row["Cli_Oldreturn"].ToString());
				}
				if(row["Cli_Newoutdata"]!=null && row["Cli_Newoutdata"].ToString()!="")
				{
					model.Cli_Newoutdata=DateTime.Parse(row["Cli_Newoutdata"].ToString());
				}
				if(row["Cli_Newintodata"]!=null && row["Cli_Newintodata"].ToString()!="")
				{
					model.Cli_Newintodata=DateTime.Parse(row["Cli_Newintodata"].ToString());
				}
				if(row["Cli_Createdata"]!=null && row["Cli_Createdata"].ToString()!="")
				{
					model.Cli_Createdata=DateTime.Parse(row["Cli_Createdata"].ToString());
				}
				if(row["Cli_Limit"]!=null)
				{
					model.Cli_Limit=row["Cli_Limit"].ToString();
				}
				if(row["Cli_RemainLimit"]!=null)
				{
					model.Cli_RemainLimit=row["Cli_RemainLimit"].ToString();
				}
				if(row["Cli_ClearLimitdate"]!=null && row["Cli_ClearLimitdate"].ToString()!="")
				{
					model.Cli_ClearLimitdate=DateTime.Parse(row["Cli_ClearLimitdate"].ToString());
				}
				if(row["Cli_ShouldMoney"]!=null)
				{
					model.Cli_ShouldMoney=row["Cli_ShouldMoney"].ToString();
				}
				if(row["Cli_GetMoney"]!=null)
				{
					model.Cli_GetMoney=row["Cli_GetMoney"].ToString();
				}
				if(row["Cli_PreMoney"]!=null)
				{
					model.Cli_PreMoney=row["Cli_PreMoney"].ToString();
				}
				if(row["Cli_Remark"]!=null)
				{
					model.Cli_Remark=row["Cli_Remark"].ToString();
				}
				if(row["Cli_safetone"]!=null)
				{
					model.Cli_safetone=row["Cli_safetone"].ToString();
				}
				if(row["Cli_safettwo"]!=null)
				{
					model.Cli_safettwo=row["Cli_safettwo"].ToString();
				}
				if(row["Cli_Enable"]!=null && row["Cli_Enable"].ToString()!="")
				{
					model.Cli_Enable=int.Parse(row["Cli_Enable"].ToString());
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
			strSql.Append("select Cli_ID,Cli_Code,Cli_zhiwen,Cli_Name,Cli_PicName,Cli_Phone,Cli_PhoneTwo,Cli_faxes,Cli_area,Cli_Address,Cli_LinkMan,Cli_TypeCode,Cli_DiscountCode,Cli_Bankaccounts,Cli_OpenBank,Cli_Olddata,Cli_Oldreturn,Cli_Newoutdata,Cli_Newintodata,Cli_Createdata,Cli_Limit,Cli_RemainLimit,Cli_ClearLimitdate,Cli_ShouldMoney,Cli_GetMoney,Cli_PreMoney,Cli_Remark,Cli_safetone,Cli_safettwo,Cli_Enable ");
			strSql.Append(" FROM T_Client ");
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
			strSql.Append(" Cli_ID,Cli_Code,Cli_zhiwen,Cli_Name,Cli_PicName,Cli_Phone,Cli_PhoneTwo,Cli_faxes,Cli_area,Cli_Address,Cli_LinkMan,Cli_TypeCode,Cli_DiscountCode,Cli_Bankaccounts,Cli_OpenBank,Cli_Olddata,Cli_Oldreturn,Cli_Newoutdata,Cli_Newintodata,Cli_Createdata,Cli_Limit,Cli_RemainLimit,Cli_ClearLimitdate,Cli_ShouldMoney,Cli_GetMoney,Cli_PreMoney,Cli_Remark,Cli_safetone,Cli_safettwo,Cli_Enable ");
			strSql.Append(" FROM T_Client ");
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
			strSql.Append("select count(1) FROM T_Client ");
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
				strSql.Append("order by T.Cli_ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Client T ");
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
			parameters[0].Value = "T_Client";
			parameters[1].Value = "Cli_ID";
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
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="Cli_Code"></param>
        /// <returns></returns>
        public bool Exists(string Cli_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Client");
            strSql.Append(" where Cli_Code=@Cli_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cli_Code", SqlDbType.VarChar,512)
            };
            parameters[0].Value = Cli_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据客户编号做假删除
        /// </summary>
        /// <param name="Cli_Code"></param>
        /// <returns></returns>
        public bool Delete(string Cli_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Client ");
            strSql.Append(" where Cli_Code=@Cli_Code");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cli_Code", SqlDbType.VarChar,512)
            };
            parameters[0].Value = Cli_Code;

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
        #endregion  ExtensionMethod
    }
}

