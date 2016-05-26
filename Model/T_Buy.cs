using System;
namespace Model
{
	/// <summary>
	/// 借款类型表
	/// </summary>
	[Serializable]
	public partial class T_Buy
	{
		public T_Buy()
		{}
		#region Model
		private int _buy_id;
		private string _buy_code;
		private DateTime? _buy_date;
		private int? _buy_stockid;
		private string _buy_stockname;
		private int? _buy_purchasestatus;
		private int? _buy_auditstatus;
		private string _buy_purchaserid;
		private string _buy_salesman;
		private string _buy_operation;
		private string _buy_auditman;
		private string _buy_remark;
		private string _buy_satetyone;
		private string _buy_satetytwo;
		private int? _buy_clear;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int Buy_ID
		{
			set{ _buy_id=value;}
			get{return _buy_id;}
		}
		/// <summary>
		/// 采购单号
		/// </summary>
		public string Buy_Code
		{
			set{ _buy_code=value;}
			get{return _buy_code;}
		}
		/// <summary>
		/// 采购日期
		/// </summary>
		public DateTime? Buy_Date
		{
			set{ _buy_date=value;}
			get{return _buy_date;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int? Buy_StockID
		{
			set{ _buy_stockid=value;}
			get{return _buy_stockid;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string Buy_StockName
		{
			set{ _buy_stockname=value;}
			get{return _buy_stockname;}
		}
		/// <summary>
		/// 是否已完成,1已完成,0未完成
		/// </summary>
		public int? Buy_PurchaseStatus
		{
			set{ _buy_purchasestatus=value;}
			get{return _buy_purchasestatus;}
		}
		/// <summary>
		/// 审核情况,1已审核,0未审核
		/// </summary>
		public int? Buy_AuditStatus
		{
			set{ _buy_auditstatus=value;}
			get{return _buy_auditstatus;}
		}
		/// <summary>
		/// 采购人员ID
		/// </summary>
		public string Buy_PurchaserID
		{
			set{ _buy_purchaserid=value;}
			get{return _buy_purchaserid;}
		}
		/// <summary>
		/// 业务员
		/// </summary>
		public string Buy_SalesMan
		{
			set{ _buy_salesman=value;}
			get{return _buy_salesman;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string Buy_Operation
		{
			set{ _buy_operation=value;}
			get{return _buy_operation;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string Buy_AuditMan
		{
			set{ _buy_auditman=value;}
			get{return _buy_auditman;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Buy_Remark
		{
			set{ _buy_remark=value;}
			get{return _buy_remark;}
		}
		/// <summary>
		/// 保留字段1
		/// </summary>
		public string Buy_Satetyone
		{
			set{ _buy_satetyone=value;}
			get{return _buy_satetyone;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string Buy_Satetytwo
		{
			set{ _buy_satetytwo=value;}
			get{return _buy_satetytwo;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Buy_Clear
		{
			set{ _buy_clear=value;}
			get{return _buy_clear;}
		}
		#endregion Model

	}
}

