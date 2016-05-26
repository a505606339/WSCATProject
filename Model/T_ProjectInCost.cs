using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class T_ProjectInCost
	{
		public T_ProjectInCost()
		{}
		#region Model
		private int _oic_id;
		private string _oic_code;
		private string _oic_oneproject;
		private string _oic_twoproject;
		private string _oic_threeproject;
		private string _oic_fourproject;
		private string _oic_fiveproject;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int OIC_ID
		{
			set{ _oic_id=value;}
			get{return _oic_id;}
		}
		/// <summary>
		/// 类型编号
		/// </summary>
		public string OIC_Code
		{
			set{ _oic_code=value;}
			get{return _oic_code;}
		}
		/// <summary>
		/// 项目1
		/// </summary>
		public string OIC_OneProject
		{
			set{ _oic_oneproject=value;}
			get{return _oic_oneproject;}
		}
		/// <summary>
		/// 项目2
		/// </summary>
		public string OIC_TwoProject
		{
			set{ _oic_twoproject=value;}
			get{return _oic_twoproject;}
		}
		/// <summary>
		/// 项目3
		/// </summary>
		public string OIC_ThreeProject
		{
			set{ _oic_threeproject=value;}
			get{return _oic_threeproject;}
		}
		/// <summary>
		/// 项目4
		/// </summary>
		public string OIC_FourProject
		{
			set{ _oic_fourproject=value;}
			get{return _oic_fourproject;}
		}
		/// <summary>
		/// 项目5
		/// </summary>
		public string OIC_FiveProject
		{
			set{ _oic_fiveproject=value;}
			get{return _oic_fiveproject;}
		}
		#endregion Model

	}
}

