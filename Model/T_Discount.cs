using System;
namespace Model
{
	/// <summary>
	/// 客户折扣表
	/// </summary>
	[Serializable]
	public partial class T_Discount
	{
		public T_Discount()
		{}
		#region Model
		private int _ct_id;
		private string _ct_name;
		private string _ct_clientid;
		private DateTime? _ct_createdate;
		private DateTime? _ct_cleardate= DateTime.Now;
		private decimal? _ct_discount=0M;
		private int? _ct_enable=1;
		private int? _ct_clear=1;
		private string _ct_remark;
		private string _ct_code;
		/// <summary>
		/// 
		/// </summary>
		public int CT_ID
		{
			set{ _ct_id=value;}
			get{return _ct_id;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string CT_Name
		{
			set{ _ct_name=value;}
			get{return _ct_name;}
		}
		/// <summary>
		/// 客户ID
		/// </summary>
		public string CT_ClientID
		{
			set{ _ct_clientid=value;}
			get{return _ct_clientid;}
		}
		/// <summary>
		/// 建立时间
		/// </summary>
		public DateTime? CT_CreateDate
		{
			set{ _ct_createdate=value;}
			get{return _ct_createdate;}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime? CT_ClearDate
		{
			set{ _ct_cleardate=value;}
			get{return _ct_cleardate;}
		}
		/// <summary>
		/// 折数（%）
		/// </summary>
		public decimal? CT_Discount
		{
			set{ _ct_discount=value;}
			get{return _ct_discount;}
		}
		/// <summary>
		/// 是否可用
		/// </summary>
		public int? CT_Enable
		{
			set{ _ct_enable=value;}
			get{return _ct_enable;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? CT_Clear
		{
			set{ _ct_clear=value;}
			get{return _ct_clear;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string CT_Remark
		{
			set{ _ct_remark=value;}
			get{return _ct_remark;}
		}
		/// <summary>
		/// 折扣编号
		/// </summary>
		public string CT_Code
		{
			set{ _ct_code=value;}
			get{return _ct_code;}
		}
		#endregion Model

	}
}

