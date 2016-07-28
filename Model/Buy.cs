using System;
namespace Model
{
	/// <summary>
	/// 借款类型表
	/// </summary>
	[Serializable]
	public partial class Buy
	{
		public Buy()
		{}
		#region Model
		private int _buy_id;
		private string _buy_code;
		private DateTime? _buy_date= DateTime.Now;
        private string _buy_suppliercode;
        private string _buy_suppliername;
        private int? _buy_purchasestatus=0;
		private int? _buy_auditstatus;
		private string _buy_purchaserid;
		private string _buy_salesman;
		private string _buy_operation;
		private string _buy_auditman;
		private string _buy_remark;
		private string _buy_satetyone;
		private string _buy_satetytwo;
        private int? _buy_clear = 1;
        private int? _buy_ispay = 0;
        private int? _buy_paymethod = 0;
        private int? _buy_isputsto = 0;
        private string _buy_class;
        private DateTime? _buy_getdate;
        private string _buy_logistics;
        private string _buy_logcode;
        private string _buy_logphone;

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
        /// 供应商编号
        /// </summary>
        public string Buy_suppliercode
        {
            get
            {
                return _buy_suppliercode;
            }

            set
            {
                _buy_suppliercode = value;
            }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Buy_suppliername
        {
            get
            {
                return _buy_suppliername;
            }

            set
            {
                _buy_suppliername = value;
            }
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
        /// <summary>
        /// 是否已付款(0为未完成,1为已完成)
        /// </summary>
        public int? Buy_IsPay
        {
            get
            {
                return _buy_ispay;
            }

            set
            {
                _buy_ispay = value;
            }
        }
        /// <summary>
        /// 付款方式(0~100，对应实际的数值为百分数。如：50等于付了50%)
        /// </summary>
        public int? Buy_PayMethod
        {
            get
            {
                return _buy_paymethod;
            }

            set
            {
                _buy_paymethod = value;
            }
        }
        /// <summary>
        /// 入库状态(0未入库,1已入库)
        /// </summary>
        public int? Buy_IsPutSto
        {
            get
            {
                return _buy_isputsto;
            }

            set
            {
                _buy_isputsto = value;
            }
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string Buy_class
        {
            get
            {
                return _buy_class;
            }

            set
            {
                _buy_class = value;
            }
        }

        /// <summary>
        /// 到货日期
        /// </summary>
        public DateTime? Buy_getdate
        {
            get
            {
                return _buy_getdate;
            }

            set
            {
                _buy_getdate = value;
            }
        }

        /// <summary>
        /// 物流
        /// </summary>
        public string Buy_logistics
        {
            get
            {
                return _buy_logistics;
            }

            set
            {
                _buy_logistics = value;
            }
        }

        /// <summary>
        /// 物流单号
        /// </summary>
        public string Buy_logcode
        {
            get
            {
                return _buy_logcode;
            }

            set
            {
                _buy_logcode = value;
            }
        }

        /// <summary>
        /// 快递电话
        /// </summary>
        public string Buy_logphone
        {
            get
            {
                return _buy_logphone;
            }

            set
            {
                _buy_logphone = value;
            }
        }

        #endregion Model
    }
}

