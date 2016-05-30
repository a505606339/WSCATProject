using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class ProjectCost
	{
		public ProjectCost()
		{}
		#region Model
		private int _pc_id;
		private string _pc_code;
		private string _pc_oneproject;
		private string _pc_twoproject;
		private string _pc_threeproject;
		private string _pc_fourproject;
		private string _pc_fiveproject;
		/// <summary>
		/// 
		/// </summary>
		public int PC_ID
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		/// <summary>
		/// 类型编号
		/// </summary>
		public string PC_Code
		{
			set{ _pc_code=value;}
			get{return _pc_code;}
		}
		/// <summary>
		/// 费用项目1
		/// </summary>
		public string PC_OneProject
		{
			set{ _pc_oneproject=value;}
			get{return _pc_oneproject;}
		}
		/// <summary>
		/// 费用项目2
		/// </summary>
		public string PC_TwoProject
		{
			set{ _pc_twoproject=value;}
			get{return _pc_twoproject;}
		}
		/// <summary>
		/// 费用项目3
		/// </summary>
		public string PC_ThreeProject
		{
			set{ _pc_threeproject=value;}
			get{return _pc_threeproject;}
		}
		/// <summary>
		/// 费用项目4
		/// </summary>
		public string PC_FourProject
		{
			set{ _pc_fourproject=value;}
			get{return _pc_fourproject;}
		}
		/// <summary>
		/// 费用项目5
		/// </summary>
		public string PC_FiveProject
		{
			set{ _pc_fiveproject=value;}
			get{return _pc_fiveproject;}
		}
		#endregion Model

	}
}

