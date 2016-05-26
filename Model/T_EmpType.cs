using System;
namespace Model
{
	/// <summary>
	/// 人员类别表
	/// </summary>
	[Serializable]
	public partial class T_EmpType
	{
		public T_EmpType()
		{}
		#region Model
		private int _et_id;
		private string _et_code;
		private string _et_rolecode;
		private string _et_name;
		private int? _et_clear=1;
		/// <summary>
		/// 
		/// </summary>
		public int Et_ID
		{
			set{ _et_id=value;}
			get{return _et_id;}
		}
		/// <summary>
		/// 类型编号
		/// </summary>
		public string Et_Code
		{
			set{ _et_code=value;}
			get{return _et_code;}
		}
		/// <summary>
		/// 角色编号
		/// </summary>
		public string Et_RoleCode
		{
			set{ _et_rolecode=value;}
			get{return _et_rolecode;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string Et_Name
		{
			set{ _et_name=value;}
			get{return _et_name;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Et_Clear
		{
			set{ _et_clear=value;}
			get{return _et_clear;}
		}
		#endregion Model

	}
}

