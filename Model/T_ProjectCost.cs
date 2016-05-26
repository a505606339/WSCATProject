using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class T_ProjectCost
	{
		public T_ProjectCost()
		{}
		#region Model
		private int _cost_id;
		private string _cost_code;
		private string _cost_oneproject;
		private string _cost_twoproject;
		private string _cost_threeproject;
		private string _cost_fourproject;
		private string _cost_fiveproject;
		/// <summary>
		/// 
		/// </summary>
		public int Cost_ID
		{
			set{ _cost_id=value;}
			get{return _cost_id;}
		}
		/// <summary>
		/// 类型编号
		/// </summary>
		public string Cost_Code
		{
			set{ _cost_code=value;}
			get{return _cost_code;}
		}
		/// <summary>
		/// 费用项目1
		/// </summary>
		public string Cost_OneProject
		{
			set{ _cost_oneproject=value;}
			get{return _cost_oneproject;}
		}
		/// <summary>
		/// 费用项目2
		/// </summary>
		public string Cost_TwoProject
		{
			set{ _cost_twoproject=value;}
			get{return _cost_twoproject;}
		}
		/// <summary>
		/// 费用项目3
		/// </summary>
		public string Cost_ThreeProject
		{
			set{ _cost_threeproject=value;}
			get{return _cost_threeproject;}
		}
		/// <summary>
		/// 费用项目4
		/// </summary>
		public string Cost_FourProject
		{
			set{ _cost_fourproject=value;}
			get{return _cost_fourproject;}
		}
		/// <summary>
		/// 费用项目5
		/// </summary>
		public string Cost_FiveProject
		{
			set{ _cost_fiveproject=value;}
			get{return _cost_fiveproject;}
		}
		#endregion Model

	}
}

