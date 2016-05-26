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
		private int _Dis_id;
		private string _Dis_name;
		private string _Dis_clientcode;
		private DateTime? _Dis_createdate;
		private DateTime? _Dis_cleardate= DateTime.Now;
		private decimal? _Dis_discount=0M;
		private int? _Dis_enable=1;
		private int? _Dis_clear=1;
		private string _Dis_remark;
		private string _Dis_code;
		/// <summary>
		/// 
		/// </summary>
		public int Dis_ID
		{
			set{ _Dis_id=value;}
			get{return _Dis_id;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string Dis_Name
		{
			set{ _Dis_name=value;}
			get{return _Dis_name;}
		}
		/// <summary>
		/// 客户ID
		/// </summary>
		public string Dis_ClientCode
		{
			set{ _Dis_clientcode = value;}
			get{return _Dis_clientcode; }
		}
		/// <summary>
		/// 建立时间
		/// </summary>
		public DateTime? Dis_CreateDate
		{
			set{ _Dis_createdate=value;}
			get{return _Dis_createdate;}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime? Dis_ClearDate
		{
			set{ _Dis_cleardate=value;}
			get{return _Dis_cleardate;}
		}
		/// <summary>
		/// 折数（%）
		/// </summary>
		public decimal? Dis_Discount
		{
			set{ _Dis_discount=value;}
			get{return _Dis_discount;}
		}
		/// <summary>
		/// 是否可用
		/// </summary>
		public int? Dis_Enable
		{
			set{ _Dis_enable=value;}
			get{return _Dis_enable;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Dis_Clear
		{
			set{ _Dis_clear=value;}
			get{return _Dis_clear;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Dis_Remark
		{
			set{ _Dis_remark=value;}
			get{return _Dis_remark;}
		}
		/// <summary>
		/// 折扣编号
		/// </summary>
		public string Dis_Code
		{
			set{ _Dis_code=value;}
			get{return _Dis_code;}
		}
		#endregion Model

	}
}

