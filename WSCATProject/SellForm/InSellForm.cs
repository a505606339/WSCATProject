using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSCATProject.SellForm
{
    public partial class InSellForm : TemplateForm
    {
        public InSellForm()
        {
            InitializeComponent();
        }

        protected override void InitTopLab()
        {
            base.InitTopLab();
            labelTitle.Text = "销售开单";
            labelTitle.Font = new System.Drawing.Font(labelTitle.Name,21f,
                FontStyle.Bold | FontStyle.Italic,labelTitle.Font.Unit);

            labTop1.Text = "单据类型：";

            labTop5.Enabled = false;
            labtextboxTop5.Enabled = false;
        }

        protected override void InitDataGridViewHeaderColumn()
        {
            base.InitDataGridViewHeaderColumn();
            
            DataGridViewTextBoxColumn dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inStorage";
            dgvTextBoxColumn.HeaderText = "仓库名称";
            dgvTextBoxColumn.DataPropertyName = "StorageName";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inBarcode";
            dgvTextBoxColumn.HeaderText = "编码、名称、型号";
            dgvTextBoxColumn.DataPropertyName = "inBarcode";
            dgvTextBoxColumn.Width = 150;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inOrderName";
            dgvTextBoxColumn.HeaderText = "货品名称";
            dgvTextBoxColumn.DataPropertyName = "orderName";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inType";
            dgvTextBoxColumn.HeaderText = "规格型号";
            dgvTextBoxColumn.DataPropertyName = "inType";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inUnit";
            dgvTextBoxColumn.HeaderText = "单位";
            dgvTextBoxColumn.DataPropertyName = "inUnit";
            dgvTextBoxColumn.Width = 80;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inNumber";
            dgvTextBoxColumn.HeaderText = "数量";
            dgvTextBoxColumn.DataPropertyName = "inNumber";
            dgvTextBoxColumn.Width = 80;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inPrice";
            dgvTextBoxColumn.HeaderText = "单价";
            dgvTextBoxColumn.DataPropertyName = "inPrice";
            dgvTextBoxColumn.Width = 80;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);


            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inDiscount";
            dgvTextBoxColumn.HeaderText = "折扣率%";
            dgvTextBoxColumn.DataPropertyName = "inDiscount";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inConvertMoney";
            dgvTextBoxColumn.HeaderText = "折后单价";
            dgvTextBoxColumn.DataPropertyName = "inConvertMoney";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inAllPrice";
            dgvTextBoxColumn.HeaderText = "总金额";
            dgvTextBoxColumn.DataPropertyName = "inAllPrice";
            dgvTextBoxColumn.Width = 100;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            dgvTextBoxColumn = new DataGridViewTextBoxColumn();
            dgvTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTextBoxColumn.Name = "inRemark";
            dgvTextBoxColumn.HeaderText = "备注";
            dgvTextBoxColumn.DataPropertyName = "inRemark";
            dgvTextBoxColumn.Width = 80;
            multiHeaderView1.Columns.Add(dgvTextBoxColumn);

            this.multiHeaderView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            this.multiHeaderView1.MergeColumnHeaderBackColor = Color.Aquamarine;
            multiHeaderView1.AddSpanHeader(1, 3, "货品信息");
        }

    }
}
