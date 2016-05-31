using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;
using DAL;
using HelperUtility.Encrypt;
using HelperUtility;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject.Base
{
    public partial class ClientTypeForm : DevComponents.DotNetBar.RibbonForm
    {
        public ClientTypeForm()
        {
            InitializeComponent();
        }

        private bool refresh;
        public bool ReFresh
        {
            get { return refresh; }
            set { refresh = value; }
        }

        private void ClientTypeForm_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;//设置列不自动增加
            loadData();
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        public void loadData()
        {
                ClientTypeManager cts = new ClientTypeManager();
                DataSet ds = cts.GetList("CT_Enable = 1");
                bindingDGVByDataTable(ds);
        }

        #region MenuItem

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientTypeFormEx.CreateClientTypeForm.formType ft =
                new ClientTypeFormEx.CreateClientTypeForm.formType();
            ft.formStatic = "增";
            ft.formText = "增加类别";
            ft.richTextbox = "";
            ft.textboxName = "";

            ClientTypeFormEx.CreateClientTypeForm cltf = 
                new ClientTypeFormEx.CreateClientTypeForm(ft);

            cltf.StartPosition = FormStartPosition.CenterParent;
            cltf.ShowDialog(this);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow row = col[0] as GridRow;

                    ClientTypeFormEx.CreateClientTypeForm.formType ft =
                        new ClientTypeFormEx.CreateClientTypeForm.formType();
                    ft.formStatic = "改";
                    ft.formText = "修改类别";
                    ft.richTextbox = row.Cells[2].Value == 
                        null ? "" : row.Cells[2].Value.ToString();
                    ft.textboxName = row.Cells[3].Value == 
                        null ? "" : row.Cells[3].Value.ToString();

                    ClientTypeFormEx.CreateClientTypeForm cltf =
                         new ClientTypeFormEx.CreateClientTypeForm(ft);

                    cltf.ShowDialog();
                    if (refresh)
                    {
                        loadData();
                        refresh = false;
                    }
                }
                MessageBox.Show("请先选中要修改的数据所在行");
                
            }
            else
            {
                MessageBox.Show("请先选中要修改的数据所在行");
            }
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(superGridControl1.PrimaryGrid.GetSelectedRows() != null)
            {
                ClientTypeManager ctm = new ClientTypeManager();
                SelectedElementCollection col = superGridControl1.PrimaryGrid.GetSelectedRows();
                if (col.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("确定要删除该数据吗?操作不可恢复", "请注意",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(dr == DialogResult.Yes)
                    {
                        GridRow row = col[0] as GridRow;
                        string code = XYEEncoding.
                            strCodeHex(row.Cells["TypeCode"].Value.ToString());
                        bool result = ctm.Delete(code);
                        if (result)
                        {
                            loadData();
                            MessageBox.Show("客户类别删除成功");
                        }
                        else
                        {
                            MessageBox.Show("删除失败,请检查是否选中列");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选中要删除的数据所在行");
                }
            }
            else
            {
                MessageBox.Show("请先选中要修改的数据所在行");
            }
        }

        private void 全部删除AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(superGridControl1.PrimaryGrid.Rows != null)
            {

                DialogResult dr = MessageBox.Show("确定要删除所有客户类别吗?该操作不可恢复", "请注意",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                GridItemsCollection col = superGridControl1.PrimaryGrid.Rows;
                if (col.Count > 0 && dr == DialogResult.No)
                {

                    List<string> ids = new List<string>();
                    foreach(GridRow gr in col)
                    {
                        
                        ids.Add(gr.Cells["TypeID"].Value.ToString());
                    }
                    string idList = string.Join(",", ids);
                    ClientTypeManager ctm = new ClientTypeManager();
                    try
                    {
                        if (ctm.FakeDeleteList())
                        {
                            loadData();
                            MessageBox.Show("清除数据成功");
                        }
                        else
                        {
                            MessageBox.Show("清除数据失败,请检查错误");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("清除数据失败,请检查错误:"+ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("客户类型已为空,不存在需要删除的数据");
                }
            }
        }

        private void 查找FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region contextMenu

        private void 新增类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem.PerformClick();
        }

        private void 删除类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除DToolStripMenuItem.PerformClick();
        }

        private void 删除全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全部删除AToolStripMenuItem.PerformClick();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void superGridControl1_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            编辑ToolStripMenuItem.PerformClick();
        }

        #endregion

        /// <summary>
        /// 将DataSet里的第一个table解密后绑定到控件上
        /// </summary>
        /// <param name="ds"></param>
        private void bindingDGVByDataTable(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CodingHelper codingHelper = new CodingHelper();
                    superGridControl1.PrimaryGrid.DataSource =
                        codingHelper.DataTableReCoding(ds.Tables[0]);
                }
                else
                {
                    DataTable dt = ds.Tables[0].Clone();
                    CodingHelper codingHelper = new CodingHelper();
                    superGridControl1.PrimaryGrid.DataSource =
                        codingHelper.DataTableReCoding(dt);
                }
            }
        }
    }
}
