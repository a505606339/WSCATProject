using BLL;
using DAL;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSCATProject.Base.Buys;

namespace WSCATProject.Base.Material
{
    public partial class MaterialBuyAndSellForm : Form
    {
        BuyManager bm = new BuyManager();
        DataTable dt = null;
        public string whereField;
        public string orderField;
        public MaterialBuyAndSellForm()
        {
            InitializeComponent();
            //添加的位置
            this.toolStrip1.Items.Insert(6, new ToolStripControlHost(dateTimePicker1));
            this.toolStrip1.Items.Insert(8, new ToolStripControlHost(dateTimePicker2));
            今天ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本周ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上周ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本月ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上月ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            本年ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            上年ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;
            全部ToolStripMenuItem.Click += ToolStripMenuDateTimeItem_Click;

            今天ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本周ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上周ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本月ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上月ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            本年ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            上年ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;
            全部ToolStripMenuItem1.Click += ToolStripMenuDateTimeItem_Click;

            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker1_ValueChanged;
        }

        #region 窗体加载方法
        // <summary>
        // 窗体加载方法
        // </summary>
        // <param name="sender"><//aram>
        // < param name="e"></param>
        private void MaterialBuyAndSellForm_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = true;
            superGridControl1.PrimaryGrid.SelectionGranularity = SelectionGranularity.Row;
            superGridControl1.PrimaryGrid.InitialSelection = RelativeSelection.None;
            superGridControl1.PrimaryGrid.FocusCuesEnabled = false;
            superGridControl1.PrimaryGrid.ActiveRowIndicatorStyle = ActiveRowIndicatorStyle.None;
            superGridControl1.PrimaryGrid.AllowEdit = false;

            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox2.SelectedIndex = 0;
        }
        #endregion

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string startDate = dateTimePicker1.Value.ToString();
            string stopDate = dateTimePicker2.Value.ToString();
            superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, startDate, stopDate, orderField);
        }

        #region 日期范围筛选公用事件
        /// <summary>
        /// 日期范围筛选公用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuDateTimeItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            int dayofweek = Convert.ToInt32(DateTime.Now.DayOfWeek);
            string stratWeek;
            string stopWeek;
            switch (tsmi.Text)
            {
                case "今天":
                    stratWeek = DateTime.Now.AddDays(dayofweek - 2).ToShortDateString();
                    stopWeek = DateTime.Now.AddDays(dayofweek).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "本周":
                    //本周开始日期
                    stratWeek = DateTime.Now.AddDays(1 - dayofweek).ToShortDateString();
                    //结束日期
                    stopWeek = DateTime.Now.AddDays(6 - dayofweek + 1).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "上周":
                    stratWeek = DateTime.Now.AddDays(1 - dayofweek - 7).ToShortDateString();
                    stopWeek = DateTime.Now.AddDays(1 - dayofweek - 7).AddDays(6).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "本月":
                    stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(0).ToShortDateString();
                    stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "上月":
                    stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString();
                    stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "本年":
                    stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).ToShortDateString();
                    stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).AddDays(-1).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "上年":
                    stratWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1).ToShortDateString();
                    stopWeek = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddDays(-1).ToShortDateString();
                    superGridControl1.PrimaryGrid.DataSource = WhereDateBetween(dt, whereField, stratWeek, stopWeek, orderField);
                    break;
                case "全部":
                    superGridControl1.PrimaryGrid.DataSource = dt;
                    break;
                default:
                    MessageBox.Show("选择错误！");
                    break;
            }
        }
        #endregion

        #region 日期范围查询公用函数
        /// <summary>
        /// 日期范围查询公用函数
        /// </summary>
        /// <param name="dt">筛选数据源</param>
        /// <param name="stratWeek">开始日期</param>
        /// <param name="stopWeek">结束日期</param>
        /// <returns></returns>
        private static DataTable WhereDateBetween(DataTable dt, string whereField, string stratWeek, string stopWeek, string orderField)
        {
            if (dt == null)
            {
                MessageBox.Show("列表为空!");
            }
            else
            {
                DataRow[] dr = dt.Select(string.Format("{0}>'{1}' and {0}<'{2}'", whereField, stratWeek, stopWeek), orderField);
                DataTable dtNew = dt.Clone();
                foreach (DataRow item in dr)
                {
                    dtNew.ImportRow(item);
                }
                dt = dtNew;
            }
            return dt;
        }
        #endregion

        #region 代码添加时间控件(BUG)
        /// <summary>
        /// 代码添加时间控件(BUG)
        /// </summary>
        private void AddDataTime()
        {
            //开始时间
            DateTimePicker begin = new DateTimePicker();
            begin.Format = DateTimePickerFormat.Custom;//自动设置
            begin.CustomFormat = "yyyy-MM-dd";//自定义格式
            begin.Name = "startDate";
            begin.Width = 100;
            //截止时间
            DateTimePicker end = new DateTimePicker();
            end.Format = DateTimePickerFormat.Custom;//自动设置
            end.CustomFormat = "yyyy-MM-dd";//自定义格式
            end.Name = "stopDate";
            end.Width = 100;
            Controls.Add(begin);
            Controls.Add(end);
            //添加的位置
            this.toolStrip1.Items.Insert(6, new ToolStripControlHost(begin));
            this.toolStrip1.Items.Insert(8, new ToolStripControlHost(end));
        }
        #endregion

        #region 快捷搜索下拉框功能实现
        /// <summary>
        /// 快捷搜索下拉框功能实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
            {
                return;
            }
            string typeName = toolStripComboBox1.Text;
            string searchTxt = toolStripTextBox1.Text.Trim();
            string sql = "";
            switch (typeName)
            {
                case "货品编号":
                    sql = "Buy_Code='{0}'";
                    break;
                case "货品名称":
                    sql = "Sell_MaName='{0}'";
                    break;
                case "规格型号":
                    sql = "Sell_Model='{0}'";
                    break;
                default:
                    MessageBox.Show("类型错误！请重新选择。");
                    break;
            }
            DataRow[] dr = dt.Select(string.Format(sql, searchTxt), "Buy_ID");
            DataTable dtNew = dt.Clone();
            foreach (DataRow item in dr)
            {
                dtNew.ImportRow(item);
            }
            dt = dtNew;
            superGridControl1.PrimaryGrid.DataSource = dt;
        }
        #endregion

        #region 单据类型下拉框内容实现
        /// <summary>
        /// 单据类型下拉框内容实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuyCheckDetailForm bcdf = new BuyCheckDetailForm();
            string cb2 = toolStripComboBox2.Text;

            #region 固定列名，考虑用table查询的as
            GridColumn gc = null;
            string[] BuysColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "供应商", "结算账户", "本次付款", "总金额", "业务员", "摘要" };
            string[] Sellcolumns = { "单据类型", "单据编号", "单据日期", "单据状态", "客户", "结算账户", "本次收款", "总金额", "业务员", "摘要" };
            string[] OtherReceiptColumns = { "仓库", "单据编号", "单据日期", "单据状态", "单据自定义一", "单据自定义二", "单据自定义三", "业务员", "摘要" };
            string[] OtherSendColumns = OtherReceiptColumns;
            string[] RequisitionColumns = { "单据类型", "仓库", "单据编号", "单据日期", "单据状态", "单据自定义一", "单据自定义二", "单据自定义三", "领料人", "摘要" };
            string[] MoveColumns = { "单据类型", "调出仓库", "调入仓库", "单据编号", "单据日期", "单据状态", "业务员", "制单人", "摘要" };
            string[] BreakageColumns = { "仓库", "单据编号", "单据日期", "单据状态", "业务员", "摘要" };
            string[] CheckColumns = OtherReceiptColumns;
            string[] AdjustPriceColumns = { "仓库", "单据编号", "单据日期", "单据状态", "调价比率%", "业务员", "摘要" };
            string[] OtherCostColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "总金额", "业务员", "摘要" };
            string[] OtherInCostColumns = OtherCostColumns;
            string[] PaymentWaitColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "付款金额", "实付金额", "业务员", "摘要" };
            string[] ReceiptColumns = { "单据类型", "单据编号", "单据日期", "单据状态", "往来单位", "结算账户", "收款金额", "实付金额", "业务员", "摘要" };
            string[] AccessMoneyColumns = { "单据编号", "单据日期", "单据状态", "付款账户", "收款金额", "收款账户", "收款金额", "业务员", "摘要" };
            string[] EmbezzleColumns = AccessMoneyColumns;
            //二维数组  用法：实例名[0][0]  便于更改表头时不用去改实现代码
            string[][] ColumnsHeaderText =
            {
                BuysColumns,
                Sellcolumns,
                OtherReceiptColumns,
                OtherSendColumns,
                RequisitionColumns,
                MoveColumns,
                BreakageColumns,
                CheckColumns,
                AdjustPriceColumns,
                OtherCostColumns,
                OtherInCostColumns,
                PaymentWaitColumns,
                ReceiptColumns,
                AccessMoneyColumns,
                EmbezzleColumns
            };
            #endregion

            superGridControl1.PrimaryGrid.Columns.Clear();
            switch (cb2)
            {
                case "采购开单":
                    dt = bm.SelBuyDataTableToCheck();
                    superGridControl1.PrimaryGrid.DataSource = dt;
                    whereField = "单据日期";
                    orderField = "ID";
                    break;
                case "销售开单":
                    for (int i = 0; i < ColumnsHeaderText[0].Length; i++)
                    {
                        gc = new GridColumn(ColumnsHeaderText[0][i]);
                        gc.Name = "";
                        superGridControl1.PrimaryGrid.Columns.Add(gc);
                    }
                    break;
                case "其他收货单":
                    break;
                case "其他发货单":
                    break;
                case "领料单":
                    break;
                case "调拨单":
                    break;
                case "报损单":
                    break;
                case "盘点单":
                    break;
                case "调价单":
                    break;
                case "费用开支":
                    break;
                case "其他收入":
                    break;
                case "应付款单":
                    break;
                case "银行存取款":
                    break;
                case "资金拆借":
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.ClearAll();
            superGridControl1.PrimaryGrid.DataSource = dt;
        }

        private void superGridControl1_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            BuyCheckDetailForm bcdf = new BuyCheckDetailForm();
            bcdf.code = superGridControl1.PrimaryGrid.GetSelectedRows().GetCells()[1].Value.ToString();  //主窗体   获取选中行的code
            bcdf.ShowDialog();
        }
    }
}
