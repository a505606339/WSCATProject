using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSCATProject.Base.Material;

namespace WSCATProject.Base.Buys
{
    public partial class BuyCheckDetailForm : TemplateForm
    {
        BuyDetailManager bdm = new BuyDetailManager();
        public string code { get; set; }
        public string typeState { get; set; }
        public string picboxname { get; set; }
        public BuyCheckDetailForm()
        {
            InitializeComponent();
        }

        private void BuyCheckDetailForm_Load(object sender, EventArgs e)
        {
            MaterialBuyAndSellDetailForm mbasdf = new MaterialBuyAndSellDetailForm();
            Text = "审核申请单";
            textBoxOddNumbers.Text = code;
            superGridControl1.PrimaryGrid.DataSource = bdm.SelBuyCancelDetailByCode(code);
        }
        public void InitDetailData()
        {

        }
        protected override void dataGridViewFujia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string TextValue = dataGridViewFujia.CurrentRow.Cells["ColumnsValue"].Value.ToString();
            switch (picboxname)
            {
                case "pictureBox1":
                    labtextboxTop1.Text = TextValue;
                    break;
                case "pictureBox2":
                    labtextboxTop2.Text = TextValue;
                    break;
                case "pictureBox3":
                    labtextboxTop4.Text = TextValue;
                    break;
                case "pictureBox4":
                    labtextboxTop6.Text = TextValue;
                    break;
            }
            resizablePanel1.Visible = false;
            BtnAdd = false;
        }
        protected override void ClickPicBox(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn gc;
            PictureBox pb = sender as PictureBox;
            picboxname = pb.Name;
            switch (pb.Name)
            {
                case "pictureBox1":
                    dataGridViewFujia.Columns.Clear();
                    OrderTypeManager otm = new OrderTypeManager();
                    dataGridViewFujia.AutoGenerateColumns = false;
                    gc = new DataGridViewTextBoxColumn();
                    gc.DataPropertyName = "Ot_Name";
                    gc.Name = "ColumnsValue";
                    gc.HeaderText = "类型名称";
                    dataGridViewFujia.Columns.Add(gc);
                    dataGridViewFujia.DataSource = otm.SelOrderType();
                    resizablePanel1.Location = new Point(120, 100);
                    break;
                case "pictureBox2":
                    dataGridViewFujia.Columns.Clear();
                    SupplierManager sm = new SupplierManager();
                    dataGridViewFujia.AutoGenerateColumns = false;
                    gc = new DataGridViewTextBoxColumn();
                    gc.DataPropertyName = "单位名称";
                    gc.Name = "ColumnsValue";
                    gc.HeaderText = "供应商名称";
                    dataGridViewFujia.Columns.Add(gc);
                    dataGridViewFujia.DataSource = sm.SelSupplierTable();
                    resizablePanel1.Location = new Point(400, 100);
                    break;
                case "pictureBox3":
                    dataGridViewFujia.Columns.Clear();
                    BankAccountManager bam = new BankAccountManager();
                    dataGridViewFujia.AutoGenerateColumns = false;
                    gc = new DataGridViewTextBoxColumn();
                    gc.DataPropertyName = "开户行";
                    gc.Name = "ColumnsValue";
                    gc.HeaderText = "账户名称";
                    dataGridViewFujia.Columns.Add(gc);
                    dataGridViewFujia.DataSource = bam.SelBankAccount(false);
                    resizablePanel1.Location = new Point(400, 130);
                    break;
                case "pictureBox4":
                    resizablePanel1.Location = new Point(120, 160);
                    break;
            }
            if (!BtnAdd)
            {
                resizablePanel1.Visible = true;
                BtnAdd = true;
            }
            else
            {
                resizablePanel1.Size = new System.Drawing.Size(248, 144);
                resizablePanel1.Visible = true;
                resizablePanel1.Focus();
            }
        }
    }
}
