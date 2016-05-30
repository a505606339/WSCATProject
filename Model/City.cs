using System;
namespace Model
{
	/// <summary>
	/// 借款类型表
	/// </summary>
	[Serializable]
	public partial class City
	{
		public City()
		{}
		#region Model
		private int _city_id;
		private string _city_name;
		private int? _city_parentid;
		/// <summary>
		/// 
		/// </summary>
		public int City_ID
		{
			set{ _city_id=value;}
			get{return _city_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City_Name
		{
			set{ _city_name=value;}
			get{return _city_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? City_ParentId
		{
			set{ _city_parentid=value;}
			get{return _city_parentid;}
		}
		#endregion Model

	}
}

