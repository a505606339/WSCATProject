using System;
namespace Model
{
	/// <summary>
	/// 供应商类别表
	/// </summary>
	[Serializable]
	public partial class T_Profession
	{
		public T_Profession()
		{}
		#region Model
		private int _st_id;
		private string _st_name;
		private string _st_remark;
		private int? _st_enable=1;
		private int? _st_clear=1;
		private string _st_safetyone;
		private string _st_safetytwo;
		private string _st_code;
		/// <summary>
		/// 
		/// </summary>
		public int ST_ID
		{
			set{ _st_id=value;}
			get{return _st_id;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string ST_Name
		{
			set{ _st_name=value;}
			get{return _st_name;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string ST_Remark
		{
			set{ _st_remark=value;}
			get{return _st_remark;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int? ST_Enable
		{
			set{ _st_enable=value;}
			get{return _st_enable;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? ST_Clear
		{
			set{ _st_clear=value;}
			get{return _st_clear;}
		}
		/// <summary>
		/// 保留字段1
		/// </summary>
		public string ST_Safetyone
		{
			set{ _st_safetyone=value;}
			get{return _st_safetyone;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string ST_Safetytwo
		{
			set{ _st_safetytwo=value;}
			get{return _st_safetytwo;}
		}
		/// <summary>
		/// 类别编号
		/// </summary>
		public string ST_Code
		{
			set{ _st_code=value;}
			get{return _st_code;}
		}
		#endregion Model

	}
}

