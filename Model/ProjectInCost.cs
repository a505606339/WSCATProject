using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class ProjectInCost
	{
		public ProjectInCost()
		{}
		#region Model
		private int _pic_id;
		private string _pic_code;
		private string _pic_oneproject;
		private string _pic_twoproject;
		private string _pic_threeproject;
		private string _pic_fourproject;
		private string _pic_fiveproject;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int PIC_ID
		{
			set{ _pic_id=value;}
			get{return _pic_id;}
		}
		/// <summary>
		/// 类型编号
		/// </summary>
		public string PIC_Code
		{
			set{ _pic_code=value;}
			get{return _pic_code;}
		}
		/// <summary>
		/// 项目1
		/// </summary>
		public string PIC_OneProject
		{
			set{ _pic_oneproject=value;}
			get{return _pic_oneproject;}
		}
		/// <summary>
		/// 项目2
		/// </summary>
		public string PIC_TwoProject
		{
			set{ _pic_twoproject=value;}
			get{return _pic_twoproject;}
		}
		/// <summary>
		/// 项目3
		/// </summary>
		public string PIC_ThreeProject
		{
			set{ _pic_threeproject=value;}
			get{return _pic_threeproject;}
		}
		/// <summary>
		/// 项目4
		/// </summary>
		public string PIC_FourProject
		{
			set{ _pic_fourproject=value;}
			get{return _pic_fourproject;}
		}
		/// <summary>
		/// 项目5
		/// </summary>
		public string PIC_FiveProject
		{
			set{ _pic_fiveproject=value;}
			get{return _pic_fiveproject;}
		}
		#endregion Model

	}
}

