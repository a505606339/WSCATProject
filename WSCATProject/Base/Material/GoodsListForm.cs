using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using BLL;
using Model;

namespace WSCATProject.Base.Material
{
    public partial class GoodsListForm : Form
    {
        enum categoryEnum
        {
            id = 0,
            name = 1
        }

        public delegate void DataTableChangeEvenHandler(DataTable dt);

        public event DataTableChangeEvenHandler fullDataEvent;

        DataTable dataTableAllMaterial = null;//原始的数据 
        /// <summary>
        /// 待更新的Code
        /// </summary>
        private string modifyCode = string.Empty;

        public GoodsListForm()
        {
            InitializeComponent();
        }

        //商品检索 
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            MaterialManager materialManager = new MaterialManager();
            string barcode = textBoxXBarcode.Text.Trim();
            string name = textBoxXName.Text.Trim();
            string type = textBoxXModel.Text.Trim();

            bool whereAdd = true;
            string queryString = "select * from 货品明细表";
            if (!string.IsNullOrEmpty(barcode))
            {
                if (whereAdd)
                {
                    queryString += " where ";
                    whereAdd = false;
                }
                queryString += "编码 Like '%" + barcode + "%'";
            }
            if(!string.IsNullOrEmpty(name))
            {
                if (whereAdd)
                {
                    queryString += " where ";
                    whereAdd = false;
                }
                else
                {
                    queryString += " and ";
                }
                queryString += "货品名称 Like '%" + name + "%'";
            }
            if (!string.IsNullOrEmpty(type))
            {
                if (whereAdd)
                {
                    queryString += " where ";
                    whereAdd = false;
                }
                else
                {
                    queryString += " and ";
                }
                queryString += "规格型号 Like '%" + type + "%'";
            }
            DataTable userSelectDS = materialManager.GetList("").Tables[0];
            dataGridViewGoodsList.DataSource = userSelectDS;
        }

        private void GoodsListForm_Load(object sender, EventArgs e)
        {
            dataGridViewGoodsList.AutoGenerateColumns = false;

            MaterialManager mm = new MaterialManager();

            MaterialTypeManager mtm = new MaterialTypeManager();

            DataTable matType = mtm.GetList("").Tables[0];

            dataTableAllMaterial = mm.GetList("").Tables[0];

            dataGridViewGoodsList.DataSource = dataTableAllMaterial;

            //CategoryDAO category = new CategoryDAO();

            //GoodsListDAO goodsList = new GoodsListDAO();

            //try
            //{
            //    DataTable categoryDataTable = category.selectAll();
            //    //获取商品类型列表填充到treeView 
            //    dataTableAllGoods = goodsList.selectAll();
            //    foreach (DataRow dr in categoryDataTable.Rows)
            //    {
            //        treeViewModel.Nodes[0].Nodes.Add(dr[(int)categoryEnum.name]
            //            .ToString());//添加节点
            //        treeViewModel.Nodes[0].LastNode.Tag = dr[(int)categoryEnum.id]
            //            .ToString();//为该节点的tag赋值成ID
            //    }
            //    treeViewModel.Nodes[0].Expand();
            //    dataGridViewGoodsList.DataSource = dataTableAllGoods;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("数据初始化异常:" + ex.Message);
            //}
        }

        private void dataGridViewGoodsList_CellMouseDoubleClick(object sender, 
            DataGridViewCellMouseEventArgs e)
        {
            /*
             * 双击单元格选中"选择"的复选框
             * 若已选择则将其改成未选 
             */
            if (e.RowIndex > -1)
            {
                //记录更新的ID和填充更新项目 
                modifyCode = dataGridViewGoodsList.Rows[e.RowIndex].Cells["gID"].Value.ToString();

                if (dataGridViewGoodsList.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    dataGridViewGoodsList.Rows[e.RowIndex].Cells[0].Value = true;
                }
                else
                { 
                    bool click = (bool)dataGridViewGoodsList.Rows[e.RowIndex].Cells[0].Value;
                    if (click)
                    {
                        dataGridViewGoodsList.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        dataGridViewGoodsList.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
            }
        }
        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataTable dataTableSource = (DataTable)dataGridViewGoodsList.DataSource;
            DataTable dataTableUserCheck = dataTableSource.Clone();
            int count = 0;
            for(int i=0;i<dataGridViewGoodsList.Rows.Count;i++)
            {
                if(dataGridViewGoodsList.Rows[i].
                    Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    count++;
                    DataRow row = dataTableSource.Rows[i];
                    dataTableUserCheck.ImportRow(row);
                }
            }
            if (count == 0)
            {
                MessageBox.Show("请至少选择一项商品");
            }
            else
            {
                fullDataEvent(dataTableUserCheck);
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void pricetx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        //绑定类别combox
        private void comboBoxCategoryBinding()
        {
            //程序路径
            //systemFunction.systemFunction func = new systemFunction.systemFunction();

            //CategoryDAO categoryDAO = new CategoryDAO();

            //DataTable categoryDT = categoryDAO.selectAll();

            //comboBoxCreateGoodsModel.Items.Clear();
            //foreach (DataRow dr in categoryDT.Rows)
            //{
            //    comboBoxCreateGoodsModel.Items.Add(
            //        new DictionaryEntry(dr[(int)categoryEnum.name], dr[(int)categoryEnum.id]));
            //}
            ////第一项为name,第二项为id
            //comboBoxCreateGoodsModel.DisplayMember = "Key";
            //comboBoxCreateGoodsModel.ValueMember = "Value";
            
            
        }
        //绑定单位combobox
        private void comboboxUnitBinding()
        {
            //systemFunction.systemFunction func = new systemFunction.systemFunction();

            //string unitString = FileReader.ReadFile(func.exePath() + @"/unit.list");

            //string[] unitList = Regex.Split(unitString, "\r\n");

            //comboBoxCreateGoodsUnit.Items.Clear();
            //comboBoxCreateGoodsUnit.Items.Add("件");
            //comboBoxCreateGoodsUnit.SelectedIndex = 0;
            //foreach (string unit in unitList)
            //{
            //    if (!string.IsNullOrEmpty(unit))
            //    {
            //        comboBoxCreateGoodsUnit.Items.Add(unit);
            //    }
            //}
        }
        //检查商品是否已经存在 
        private bool goodsWhetherExist(string name,string type)
        {
            var goodsQuery = from goods in dataTableAllMaterial.AsEnumerable()
                             where goods.Field<string>("货品名称").Equals(name) &&
                             goods.Field<string>("规格型号").Equals(type)
                             select goods;
            if (goodsQuery.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonUnitAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonUnitDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void treeViewModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dataTableAllMaterial != null)
            {
                if (e.Node.Text.Equals("所有商品"))
                {
                    dataGridViewGoodsList.DataSource = dataTableAllMaterial;
                }
                else
                {
                    var userSelectData = from d in dataTableAllMaterial.AsEnumerable()
                                         where d.Field<string>("类型名称").Equals(e.Node.Text.ToString())
                                         select d;
                    if (userSelectData.Count() > 0)
                    {
                        DataTable tempDataTable = userSelectData.CopyToDataTable();
                        dataGridViewGoodsList.DataSource = tempDataTable;
                    }
                    else
                    {
                        DataTable tempDataTable = dataTableAllMaterial.Clone();
                        dataGridViewGoodsList.DataSource = tempDataTable;
                    }
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvr in dataGridViewGoodsList.Rows)
            {
                dgvr.Cells[0].Value = 1;
            }
        }

        private void buttonSelectClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridViewGoodsList.Rows)
            {
                dgvr.Cells[0].Value = 0;
            }
        }

        private void buttonCreateClear_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewGoodsList.SelectedRows.Count > 0)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("删除该商品将无法恢复,确定要删除吗?",
                    "请注意",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2))
                {
                    MaterialManager mm = new MaterialManager();
                    //GoodsListDAO goodsDAO = new GoodsListDAO();
                    bool influenceRow = mm.DeleteFake(
                        dataGridViewGoodsList.SelectedRows[0].Cells["gID"].Value.ToString());
                    if (influenceRow)
                    {
                        dataTableAllMaterial = mm.GetList("").Tables[0];
                        dataGridViewGoodsList.DataSource = dataTableAllMaterial;
                        MessageBox.Show("删除指定商品成功");
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行");
            }
        }
    }
}
