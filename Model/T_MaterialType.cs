using System;
namespace Model
{
	/// <summary>
	/// 物料类别表
	/// </summary>
	[Serializable]
	public partial class T_MaterialType
	{
		public T_MaterialType()
		{}
		#region Model
		private int _mt_id;
		private string _mt_code;
		private string _mt_onegroup;
		private string _mt_twogroup;
		private string _mt_threegroup;
		private string _mt_fourgroup;
		private string _mt_fivegroup;
		private int? _mt_enable=1;
		private int? _mt_clear=1;
		private string _mt_safetyone;
		private string _mt_safetytwo;
		private string _mt_remark;
		/// <summary>
		/// 
		/// </summary>
		public int MT_ID
		{
			set{ _mt_id=value;}
			get{return _mt_id;}
		}
		/// <summary>
		/// 类别编号
		/// </summary>
		public string MT_Code
		{
			set{ _mt_code=value;}
			get{return _mt_code;}
		}
		/// <summary>
		/// 一级类别
		/// </summary>
		public string MT_OneGroup
		{
			set{ _mt_onegroup=value;}
			get{return _mt_onegroup;}
		}
		/// <summary>
		/// 二级类别
		/// </summary>
		public string MT_TwoGroup
		{
			set{ _mt_twogroup=value;}
			get{return _mt_twogroup;}
		}
		/// <summary>
		/// 三级类别
		/// </summary>
		public string MT_ThreeGroup
		{
			set{ _mt_threegroup=value;}
			get{return _mt_threegroup;}
		}
		/// <summary>
		/// 四级类别
		/// </summary>
		public string MT_FourGroup
		{
			set{ _mt_fourgroup=value;}
			get{return _mt_fourgroup;}
		}
		/// <summary>
		/// 五级类别
		/// </summary>
		public string MT_FiveGroup
		{
			set{ _mt_fivegroup=value;}
			get{return _mt_fivegroup;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int? MT_Enable
		{
			set{ _mt_enable=value;}
			get{return _mt_enable;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? MT_Clear
		{
			set{ _mt_clear=value;}
			get{return _mt_clear;}
		}
		/// <summary>
		/// 保留字段1
		/// </summary>
		public string MT_Safetyone
		{
			set{ _mt_safetyone=value;}
			get{return _mt_safetyone;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string MT_Safetytwo
		{
			set{ _mt_safetytwo=value;}
			get{return _mt_safetytwo;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string MT_Remark
		{
			set{ _mt_remark=value;}
			get{return _mt_remark;}
		}
		#endregion Model

	}
}

