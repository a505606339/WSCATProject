﻿using System;
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
		private string _pic_name;
		private string _pic_parentid;
		private int? _pic_enable;
		private int? _pic_clear;
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
		public string PIC_Name
		{
			set{ _pic_name=value;}
			get{return _pic_name;}
		}
		/// <summary>
		/// 项目2
		/// </summary>
		public string PIC_ParentId
		{
			set{ _pic_parentid=value;}
			get{return _pic_parentid;}
		}
		/// <summary>
		/// 项目3
		/// </summary>
		public int? PIC_Enable
		{
			set{ _pic_enable=value;}
			get{return _pic_enable;}
		}
		/// <summary>
		/// 项目4
		/// </summary>
		public int? PIC_Clear
		{
			set{ _pic_clear=value;}
			get{return _pic_clear;}
		}
		#endregion Model

	}
}

