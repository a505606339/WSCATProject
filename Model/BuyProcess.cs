using System;
namespace Model
{
	/// <summary>
	/// 借款类型表
	/// </summary>
	[Serializable]
	public partial class BuyProcess
	{
		public BuyProcess()
		{}
		#region Model
		private int _bp_id;
		private string _bp_code;
		private string _bp_selllineno;
		private DateTime? _bp_datetime;
		private string _bp_opt;
		private string _bp_ope;
		private string _bp_remark;
		private int? _bp_clear;
		/// <summary>
		/// 
		/// </summary>
		public int BP_ID
		{
			set{ _bp_id=value;}
			get{return _bp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BP_Code
		{
			set{ _bp_code=value;}
			get{return _bp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BP_SellLineno
		{
			set{ _bp_selllineno=value;}
			get{return _bp_selllineno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BP_Datetime
		{
			set{ _bp_datetime=value;}
			get{return _bp_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BP_Opt
		{
			set{ _bp_opt=value;}
			get{return _bp_opt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BP_Ope
		{
			set{ _bp_ope=value;}
			get{return _bp_ope;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BP_Remark
		{
			set{ _bp_remark=value;}
			get{return _bp_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BP_Clear
		{
			set{ _bp_clear=value;}
			get{return _bp_clear;}
		}
		#endregion Model

	}
}

