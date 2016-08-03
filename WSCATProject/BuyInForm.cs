﻿using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;
using HelperUtility;
using System.Text.RegularExpressions;

namespace WSCATProject
{
    public partial class BuyInForm : TemplateForm
    {
        public BuyInForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 所有商品列表
        /// </summary>
        private DataSet _AllMaterial = null;
        /// <summary>
        /// 所有仓库列表
        /// </summary>
        private DataSet _AllStorage = null;
        /// <summary>
        /// 所有的供应商列表
        /// </summary>
        private DataTable _AllSupplier = null;
        /// <summary>
        /// 选择的仓库
        /// </summary>
        private KeyValuePair<string,string> _ClickStorage;
        /// <summary>
        /// 采购单单号
        /// </summary>
        private string _BuyOdd = "";
        /// <summary>
        /// 供应商编号
        /// </summary>
        private string _ProfeCode = "";
        /// <summary>
        /// 点击的项,1为仓库,2为供应商
        /// </summary>
        private int _Click = 0;
        /// <summary>
        /// 用户选择的商品总数
        /// </summary>
        private decimal _MaterialNumber = 0;
        /// <summary>
        /// 用户选择的商品总值
        /// </summary>
        private decimal _MaterialMoney = 0.00m;

        #region 初始化操作
        protected override void InitTopLab()
        {
            base.InitTopLab();
            pictureBox1.Visible = false;
            checkBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            labelTitle.Text = "采购开单";
            labTop2.Text = "供应商：";
            labTop3.Text = "本次付款：";
            labTop4.Text = "付款账户：";
            labTop7.Text = "快递单号：";
            labTop8.Text = "快递员：";
            labTop9.Text = "快递电话：";
            //labtextboxTop3.Enabled = false;
            //labtextboxTop4.Enabled = false;
            //labtextboxTop5.Enabled = false;
            //labtextboxTop6.Enabled = false;

            labtextboxTop6.Visible = false;

            labtextboxTop7.Enabled = false;
            labtextboxTop8.Enabled = false;
            labtextboxTop9.Enabled = false;

            labBotton4.Visible = false;
            labtextboxBotton4.Visible = false;

            comboBoxEx1.SelectedIndex = 0;
        }

        protected override void InitTopLabText()
        {
            base.InitTopLabText();
            labtextboxTop1.Text = "采购开单";
        }

        private void InitDataGridView()
        {
            //改为点击可编辑
            superGridControl1.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
            //新增一行 用于给客户操作
            superGridControl1.PrimaryGrid.NewRow(true);
            //最后一行做统计行
            GridRow gr = (GridRow)superGridControl1.PrimaryGrid.
                Rows[superGridControl1.PrimaryGrid.Rows.Count - 1];
            gr.ReadOnly = true;
            gr.CellStyles.Default.Background.Color1 = Color.Gray;
            gr.Cells["gridColumnStock"].Value = "合计";
            gr.Cells["gridColumnStock"].CellStyles.Default.Alignment = 
                DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnNumber"].Value = 0;
            gr.Cells["gridColumnNumber"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnNumber"].CellStyles.Default.Background.Color1 = Color.Red;
            gr.Cells["gridColumnMoney"].Value = 0;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gr.Cells["gridColumnMoney"].CellStyles.Default.Background.Color1 = Color.Red;
        }

        #endregion

        private void BuyInForm_Load(object sender, EventArgs e)
        {
            MaterialManager mm = new MaterialManager();
            StorageManager sm = new StorageManager();
            SupplierManager sum = new SupplierManager();
            _AllMaterial = mm.GetList("");
            _AllStorage = sm.GetList("");
            _AllSupplier = sum.SelSupplierTable();
            
            //禁用自动创建列
            dataGridView1.AutoGenerateColumns = false;
            dataGridViewFujia.AutoGenerateColumns = false;
            //初始化商品下拉列表
            InitMaterialDataGridView();
            //初始化datagridview
            InitDataGridView();

            dataGridView1.DataSource = _AllMaterial.Tables[0];
            //绑定事件 双击事填充内容并隐藏列表
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridViewFujia.CellDoubleClick += DataGridViewFujia_CellDoubleClick;
            
            //采购单单号
            _BuyOdd = BuildCode.ModuleCode("BA");
            textBoxOddNumbers.Text = _BuyOdd;

            InitSupplier();
        }

        //双击物料信息填充到申请单里并隐藏列表 
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GridRow gr = (GridRow)superGridControl1.PrimaryGrid.Rows[ClickRowIndex];
            gr.Cells["gridColumnid"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_ID"].Value;
            gr.Cells["gridColumnpic"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_PicName"].Value;
            gr.Cells["gridColumnRfid"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_RFID"].Value;
            gr.Cells["gridColumnBarcode"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_Code"].Value;
            gr.Cells["gridColumnTypeid"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_TypeID"].Value;
            //gr.Cells["gridColumnStock"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_TypeID"].Value;
            gr.Cells["gridColumnMaID"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_ID"].Value;
            gr.Cells["material"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_zhujima"].Value;
            gr.Cells["gridColumnName"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_Name"].Value;
            gr.Cells["gridColumnModel"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_Model"].Value;
            gr.Cells["gridColumnUnit"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_Unit"].Value;
            gr.Cells["gridColumnNumber"].Value = 1;
            decimal price = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Ma_Price"].Value.Equals("") ?
                0 : dataGridView1.Rows[e.RowIndex].Cells["Ma_Price"].Value);
            gr.Cells["gridColumnPrice"].Value = price;
            gr.Cells["gridColumnDis"].Value = 100;
            gr.Cells["gridColumnDisPrice"].Value = price;
            gr.Cells["gridColumnMoney"].Value = price;
            //gr.Cells["gridColumnRemark"].Value = dataGridView1.Rows[e.RowIndex].Cells["Ma_Unit"].Value;
            resizablePanelData.Visible = false;
            //新增一行
            superGridControl1.PrimaryGrid.NewRow(superGridControl1.PrimaryGrid.Rows.Count);
            //当上一次有选择仓库时 默认本次也为上次选择仓库
            if (!string.IsNullOrEmpty(_ClickStorage.Value) && !string.IsNullOrEmpty(_ClickStorage.Key))
            {
                gr.Cells["gridColumnStockCode"].Value = _ClickStorage.Key;
                gr.Cells["gridColumnStock"].Value = _ClickStorage.Value;
            }
            //递增数量和金额 默认为1和单价
            gr = (GridRow)superGridControl1.PrimaryGrid.LastSelectableRow;
            _MaterialNumber += 1;
            _MaterialMoney += price;
            gr.Cells["gridColumnNumber"].Value = _MaterialNumber;
            gr.Cells["gridColumnMoney"].Value = _MaterialMoney;
        }

        //双击填充到供应商或是仓库列 
        private void DataGridViewFujia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_Click == 2)
            {
                string code = dataGridViewFujia.Rows[e.RowIndex].Cells["Su_Code"].Value.ToString();
                string name = dataGridViewFujia.Rows[e.RowIndex].Cells["Su_Name"].Value.ToString();
                _ProfeCode = code;
                labtextboxTop2.Text = name;
                resizablePanel1.Visible = false;
            }
            if (_Click == 1)
            {
                GridRow gr = (GridRow)superGridControl1.PrimaryGrid.Rows[ClickRowIndex];
                string code = dataGridViewFujia.Rows[e.RowIndex].Cells["St_Code"].Value.ToString();
                string name = dataGridViewFujia.Rows[e.RowIndex].Cells["St_Name"].Value.ToString();
                gr.Cells["gridColumnStockCode"].Value = code;
                gr.Cells["gridColumnStock"].Value = name;
                _ClickStorage = new KeyValuePair<string, string>(code, name);
                resizablePanel1.Visible = false;
            }
        }

        /// <summary>
        /// 初始化仓库列和数据
        /// </summary>
        private void InitStorageList()
        {
            if (_Click != 1)
            {
                _Click = 1;
                dataGridViewFujia.DataSource = null;
                dataGridViewFujia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "St_Code";
                dgvc.Visible = false;
                dgvc.HeaderText = "code";
                dgvc.DataPropertyName = "St_Code";
                dataGridViewFujia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "St_Name";
                dgvc.Visible = true;
                dgvc.HeaderText = "仓库名称";
                dgvc.DataPropertyName = "St_Name";
                dataGridViewFujia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "St_Address";
                dgvc.Visible = true;
                dgvc.HeaderText = "仓库地址";
                dgvc.DataPropertyName = "St_Address";
                dataGridViewFujia.Columns.Add(dgvc);

                dataGridViewFujia.DataSource = _AllStorage.Tables[0];
            }
        }

        /// <summary>
        /// 初始化商品下拉别表的数据
        /// </summary>
        private void InitMaterialDataGridView()
        {
            DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_ID";
            dgvc.Visible = false;
            dgvc.HeaderText = "maid";
            dgvc.DataPropertyName = "Ma_ID";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PicName";
            dgvc.Visible = false;
            dgvc.HeaderText = "pic";
            dgvc.DataPropertyName = "Ma_PicName";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_RFID";
            dgvc.Visible = false;
            dgvc.HeaderText = "rfid";
            dgvc.DataPropertyName = "Ma_RFID";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Code";
            dgvc.Visible = false;
            dgvc.HeaderText = "code";
            dgvc.DataPropertyName = "Ma_Code";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_TypeID";
            dgvc.Visible = false;
            dgvc.HeaderText = "TypeID";
            dgvc.DataPropertyName = "Ma_TypeID";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_TypeName";
            dgvc.Visible = false;
            dgvc.HeaderText = "TypeName";
            dgvc.DataPropertyName = "Ma_TypeName";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Price";
            dgvc.Visible = false;
            dgvc.HeaderText = "price";
            dgvc.DataPropertyName = "Ma_Price";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PriceA";
            dgvc.Visible = false;
            dgvc.HeaderText = "priceA";
            dgvc.DataPropertyName = "Ma_PriceA";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PriceB";
            dgvc.Visible = false;
            dgvc.HeaderText = "priceB";
            dgvc.DataPropertyName = "Ma_PriceB";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PriceC";
            dgvc.Visible = false;
            dgvc.HeaderText = "priceC";
            dgvc.DataPropertyName = "Ma_PriceC";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PriceD";
            dgvc.Visible = false;
            dgvc.HeaderText = "priceD";
            dgvc.DataPropertyName = "Ma_PriceD";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_PriceE";
            dgvc.Visible = false;
            dgvc.HeaderText = "priceE";
            dgvc.DataPropertyName = "Ma_PriceE";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_CreateDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "CreateDate";
            dgvc.DataPropertyName = "Ma_CreateDate";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Supplier";
            dgvc.Visible = false;
            dgvc.HeaderText = "Supplier";
            dgvc.DataPropertyName = "Ma_Supplier";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_SupID";
            dgvc.Visible = false;
            dgvc.HeaderText = "SupID";
            dgvc.DataPropertyName = "Ma_SupID";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Unit";
            dgvc.Visible = false;
            dgvc.HeaderText = "Unit";
            dgvc.DataPropertyName = "Ma_Unit";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_InPrice";
            dgvc.Visible = false;
            dgvc.HeaderText = "InPrice";
            dgvc.DataPropertyName = "Ma_InPrice";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_InDate";
            dgvc.Visible = false;
            dgvc.HeaderText = "InDate";
            dgvc.DataPropertyName = "Ma_InDate";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Remark";
            dgvc.Visible = false;
            dgvc.HeaderText = "Remark";
            dgvc.DataPropertyName = "Ma_Remark";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Enable";
            dgvc.Visible = false;
            dgvc.HeaderText = "Enable";
            dgvc.DataPropertyName = "Ma_Enable";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Clear";
            dgvc.Visible = false;
            dgvc.HeaderText = "Clear";
            dgvc.DataPropertyName = "Ma_Clear";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Safeyone";
            dgvc.Visible = false;
            dgvc.HeaderText = "Safeyone";
            dgvc.DataPropertyName = "Ma_Safeyone";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Safetytwo";
            dgvc.Visible = false;
            dgvc.HeaderText = "Safetytwo";
            dgvc.DataPropertyName = "Ma_Safetytwo";
            dataGridView1.Columns.Add(dgvc);


            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_zhujima";
            dgvc.Visible = true;
            dgvc.HeaderText = "助记码";
            dgvc.DataPropertyName = "Ma_zhujima";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Name";
            dgvc.Visible = true;
            dgvc.HeaderText = "物料名称";
            dgvc.DataPropertyName = "Ma_Name";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Model";
            dgvc.Visible = true;
            dgvc.HeaderText = "规格型号";
            dgvc.DataPropertyName = "Ma_Model";
            dataGridView1.Columns.Add(dgvc);

            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "Ma_Barcode";
            dgvc.Visible = true;
            dgvc.HeaderText = "条码";
            dgvc.DataPropertyName = "Ma_Barcode";
            dataGridView1.Columns.Add(dgvc);
        }

        /// <summary>
        /// 初始化供应商下拉列表
        /// </summary>
        private void InitSupplier()
        {
            if (_Click != 2)
            {
                _Click = 2;
                dataGridViewFujia.DataSource = null;
                dataGridViewFujia.Columns.Clear();

                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "Su_Code";
                dgvc.Visible = false;
                dgvc.HeaderText = "code";
                dgvc.DataPropertyName = "编码";
                dataGridViewFujia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "Su_Name";
                dgvc.Visible = true;
                dgvc.HeaderText = "供应商名称";
                dgvc.DataPropertyName = "供应商名称";
                dataGridViewFujia.Columns.Add(dgvc);

                dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "Su_Credit";
                dgvc.Visible = true;
                dgvc.HeaderText = "信用等级";
                dgvc.DataPropertyName = "信用等级";
                dataGridViewFujia.Columns.Add(dgvc);

                dataGridViewFujia.DataSource = _AllSupplier;
            }
        }

        //双击显示详细的商品界面 
        private void superGridControl1_CellDoubleClick(object sender,
            GridCellDoubleClickEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "gridColumnName" ||
                e.GridCell.GridColumn.Name == "gridColumnModel")
            {
                MessageBox.Show("Test");
            }
        }

        //点击superGridControl隐藏下拉列表 
        private void superGridControl1_Click(object sender, EventArgs e)
        {
            resizablePanelData.Visible = false;
            resizablePanel1.Visible = false;
        }

        //点击显示供应商列表
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (_Click != 2)
            {
                InitSupplier();
            }
        }

        //保存按钮 
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ProfeCode))
            {
                MessageBox.Show("供应商不可为空,请选择供应商!");
                return;
            }
            BuyManager bm = new BuyManager();
            GridItemsCollection grs = superGridControl1.PrimaryGrid.Rows;
            List<BuyDetail> buyDetailList = new List<BuyDetail>();
            Buy buy = new Buy();
            if (grs.Count > 1)
            {
                buy.Buy_Code = _BuyOdd;
                buy.Buy_Date = dateTimePicker1.Value;
                buy.Buy_suppliercode = _ProfeCode;
                buy.Buy_suppliername = labtextboxTop2.Text.Trim();
                buy.Buy_PurchaseStatus = 1;
                buy.Buy_AuditStatus = 0;
                buy.Buy_PurchaserID = "0";
                buy.Buy_SalesMan = labtextboxBotton1.Text;
                buy.Buy_Operation = labtextboxBotton3.Text;
                buy.Buy_AuditMan = "";
                buy.Buy_Remark = labtextboxBotton2.Text;
                buy.Buy_Clear = 1;
                buy.Buy_IsPay = 0;
                buy.Buy_PayMethod = 0;
                buy.Buy_IsPutSto = 0;
                buy.Buy_class = "采购申请单";
                //buy.Buy_PayMethod = 
                foreach (GridRow gr in grs)
                {
                    BuyDetail buyDetail = new BuyDetail();
                    if (gr["gridColumnName"].Value == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(gr["gridColumnName"].Value.ToString()))
                    {
                        continue;
                    }
                    if (gr["gridColumnStock"].Value == null || gr["gridColumnStockCode"].Value == null)
                    {
                        MessageBox.Show("货品" +
                            gr["gridColumnName"].Value.ToString() + "仓库未选择,请选择!");
                        return;
                    }
                    if (gr["gridColumnStock"].Value.ToString() == "" ||
                        gr["gridColumnStockCode"].Value.ToString() == "")
                    {
                        MessageBox.Show("货品" +
                            gr["gridColumnName"].Value.ToString() + "仓库未选择,请选择!");
                        return;
                    }

                    buyDetail.Buy_LineCode = _BuyOdd;
                    buyDetail.Buy_StockCode = gr["gridColumnStockCode"].Value.ToString();
                    buyDetail.Buy_StockName = gr["gridColumnStock"].Value.ToString();
                    buyDetail.Buy_Code = _BuyOdd;
                    buyDetail.Buy_MaID = gr["gridColumnMaID"].Value.ToString();
                    buyDetail.Buy_MaName = gr["gridColumnName"].Value.ToString();
                    buyDetail.Buy_Model = gr["gridColumnModel"].Value.ToString();
                    buyDetail.Buy_Unit = gr["gridColumnUnit"].Value.ToString();
                    buyDetail.Buy_CurNumber = Convert.ToDecimal(gr["gridColumnNumber"].Value);
                    buyDetail.Buy_DiscountAPrice = Convert.ToDecimal(gr["gridColumnPrice"].Value);
                    buyDetail.Buy_Discount = Convert.ToDecimal(gr["gridColumnDis"].Value);
                    buyDetail.Buy_DiscountBPrice = Convert.ToDecimal(gr["gridColumnDisPrice"].Value);
                    buyDetail.Buy_AmountMoney = Convert.ToDecimal(gr["gridColumnMoney"].Value);
                    buyDetail.Buy_Clear = 1;
                    buyDetail.Buy_Remark = gr["gridColumnRemark"].Value == null ? 
                        "" : gr["gridColumnRemark"].Value.ToString();

                    buyDetailList.Add(buyDetail);
                }
                try
                {
                    int influence = bm.AddBatch(buy, buyDetailList);
                    if (influence < 1)
                    {
                        MessageBox.Show("未新增任何数据,请检查是否未录入数据,或是存在数据为空");
                    }
                    else
                    {
                        MessageBox.Show("申请采购单成功,该单正在等待审核中.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误代码:3101-创建采购单异常，异常信息：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先在表格内增加需要采购的商品");
            }
        }

        //点击绑定仓库
        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            if (e.GridCell.GridColumn.Name == "gridColumnStock" && !resizablePanel1.Visible)
            {
                //绑定仓库列表
                InitStorageList();
            }
        }

        //验证完全后,统计单元格数据
        private void superGridControl1_CellValidated(object sender, GridCellValidatedEventArgs e)
        {
            
        }

        private void superGridControl1_CellValidating(object sender, GridCellValidatingEventArgs e)
        {
            
        }

        private void superGridControl1_EditorValueChanged(object sender, GridEditEventArgs e)
        {
            
        }
    }
}
