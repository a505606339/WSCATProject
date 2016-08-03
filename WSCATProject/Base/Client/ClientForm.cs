using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Model;
using BLL;
using HelperUtility.Excel;
using HelperUtility.Encrypt;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject.Base
{
    public partial class ClientForm : RibbonForm
    {
        private bool isflag = false;
        //�Ƿ��Ӵ���ȷ������Ҫˢ��
        public bool Isflag
        {
            get
            {
                return isflag;
            }

            set
            {
                isflag = value;
            }
        }
        //���еĿͻ��б�
        private DataSet allDS = null;
        //����Ľڵ�text
        private string clientNodeText = "���нڵ�";

        public ClientForm()
        {
            InitializeComponent();
        }

        #region ��ʼ��

        private void ClientForm_Load(object sender, EventArgs e)
        {
            loadTree();
            loadData();
            MultiColumn();
            toolStripComboBoxKey.SelectedIndex = 0;
        }

        //�������ݰ󶨵�dgv
        private void loadData()
        {
            try
            {
                ClientManager cm = new ClientManager();
                allDS = cm.GetList("");
                superGridControlClient.PrimaryGrid.DataSource = allDS;
            }
            catch (Exception ex)
            {

                MessageBox.Show("��ѯ����ʧ��,������������ӡ��쳣:" + ex.Message);
            }
        }

        //�ݹ�������Ľڵ�
        private void AddTree(string ParentID, TreeNode pNode, DataTable table)
        {
            if (ParentID == "")
            {
                ParentID = "D4";
            }
            string ParentId = "City_ParentID";
            string Code = "City_Code";
            string Name = "City_Name";

            DataView dvTree = new DataView(table);
            //����ParentID,�õ���ǰ�������ӽڵ�
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //��Ӹ��ڵ�
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    treeViewClient.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);
                    //չ����һ���ڵ�
                    Node.Expand();
                }
                else
                {
                    //��ӵ�ǰ�ڵ���ӽڵ�
                    Node.Text = XYEEncoding.strHexDecode(Row[Name].ToString());
                    Node.Tag = XYEEncoding.strHexDecode(Row[Code].ToString());
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, table);//�ٴεݹ� 
                }
            }
        }

        #endregion

        #region treeview�Ĳ���
        //�����ڵ�
        private void conToolStripMenuItemChild_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                InsNodes insN = new InsNodes();
                insN.city_code = treeViewClient.SelectedNode.Tag.ToString();
                insN.ShowDialog(this);
                if(Isflag)
                {
                    
                    loadTree();
                    isflag = false;
                    this.Focus();
                }
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            }
        }

        //ɾ���ڵ� 
        private void conToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeViewClient.SelectedNode != null)
            {
                CityManager cm = new CityManager();
                try
                {
                    if (cm.DeleteByCode(treeViewClient.SelectedNode.Tag.ToString()))
                    {
                        treeViewClient.SelectedNode.Remove();
                        MessageBox.Show("ɾ���ó��гɹ�!");
                    }
                    else
                    {
                        MessageBox.Show("ɾ���ó�����Ϣʧ��,�����³���");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ɾ��������Ϣ�����쳣,�������������." + ex.Message);
                }
            }
        }

        //�༭�ڵ� 
        private void conToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if(treeViewClient.SelectedNode != null)
            {
                InsNodes insNodes = new InsNodes();
                City city = new City();
                city.City_Name = treeViewClient.SelectedNode.Text;
                city.City_Code = treeViewClient.SelectedNode.Tag.ToString();
                city.City_ParentId = treeViewClient.SelectedNode.Parent.Tag.ToString();
                city.City_Clear = 1;
                city.City_Enable = 1;
                insNodes.city = city;
                insNodes.ShowDialog(this);
                if(isflag)
                {
                    loadTree();
                }
            }
            else
            {
                MessageBox.Show("����ѡ��Ҫ�༭�Ľڵ�");
            }
        }

        /// <summary>
        /// ���ұ߿հ׶�λ����߽ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewClient_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewClient.SelectedNode = treeViewClient.GetNodeAt(e.X, e.Y);
            }
        }

        //����ڵ�ɸѡ�����з��ϵ���Ľڵ����
        private void treeViewClient_AfterSelect(object sender, TreeViewEventArgs e)
        {

            clientNodeText = e.Node.Text;
            ClientManager cm = new ClientManager();
            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS.Tables[0],
                                clientNodeText, "����");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region �����˵��Ĳ���

        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewClient.SelectedNode = treeViewClient.Nodes[0];
        }

        //������ť
        private void toolStripButtonSeach_Click(object sender, EventArgs e)
        {
            string field = toolStripComboBoxKey.Text;
            string text = toolStripTextBoxValue.Text.Trim();
            ClientManager cm = new ClientManager();

            if (allDS != null)
            {
                try
                {
                    superGridControlClient.PrimaryGrid.DataSource =
                                cm.searchClientByNodeClick(allDS.Tables[0],
                                text, field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //����
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            CreateClientForm ccf = new CreateClientForm();
            ccf.ShowDialog(this);
            closeDispose();
        }

        //�༭
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                Client client = new Client();
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    client.Cli_ID = Convert.ToInt32(gridRow.Cells["gridColumnID"].Value);
                    client.Cli_Code = gridRow.Cells["gridColumnCode"].Value.ToString();
                    client.Cli_zhiwen = gridRow.Cells["gridColumnZ"].Value.ToString();
                    client.Cli_Name = gridRow.Cells["gridColumnCliName"].Value.ToString();
                    client.Cli_LinkMan = gridRow.Cells["gridColumnMan"].Value.ToString();
                    client.Cli_Company = gridRow.Cells["gridColumnCo"].Value.ToString();
                    client.Cli_Phone = gridRow.Cells["gridColumnPho"].Value.ToString();
                    client.Cli_PhoneTwo = gridRow.Cells["gridColumnPho2"].Value.ToString();
                    client.Cli_faxes = gridRow.Cells["gridColumnFax"].Value.ToString();
                    client.Cli_CityCode = gridRow.Cells["gridColumnCiCode"].Value.ToString();
                    client.Cli_area = gridRow.Cells["gridColumnArea"].Value.ToString();
                    client.Cli_Address = gridRow.Cells["gridColumnAd"].Value.ToString();
                    client.Cli_TypeCode = gridRow.Cells["gridColumnTy"].Value.ToString();
                    client.Cli_TypeName = gridRow.Cells["gridColumnTyName"].Value.ToString();
                    client.Cli_DiscountCode = gridRow.Cells["gridColumnDiCode"].Value.ToString();
                    client.Cli_Bankaccounts = gridRow.Cells["gridColumnBa"].Value.ToString();
                    client.Cli_OpenBank = gridRow.Cells["gridColumnOpB"].Value.ToString();
                    client.Cli_Olddata = null;
                    client.Cli_Oldreturn = null;
                    client.Cli_Newoutdata = null;
                    client.Cli_Newintodata = null;
                    client.Cli_Createdata = Convert.ToDateTime(gridRow.Cells["gridColumnCre"].Value);
                    client.Cli_Limit = gridRow.Cells["gridColumnLim"].Value.ToString();
                    client.Cli_RemainLimit = gridRow.Cells["gridColumnReLim"].Value.ToString();
                    client.Cli_ClearLimitdate = gridRow.Cells["gridColumnDay"].Value.ToString();
                    client.Cli_ShouldMoney = gridRow.Cells["gridColumnSho"].Value.ToString();
                    client.Cli_GetMoney = gridRow.Cells["gridColumnGet"].Value.ToString();
                    client.Cli_PreMoney = gridRow.Cells["gridColumnPre"].Value.ToString();
                    client.Cli_Remark = gridRow.Cells["gridColumnRem"].Value.ToString();
                    client.Cli_safetone = gridRow.Cells["gridColumnsafetone"].Value.ToString();
                    client.Cli_safettwo = gridRow.Cells["gridColumnsafettwo"].Value.ToString();
                    client.Cli_Enable = Convert.ToInt32(gridRow.Cells["gridColumnEnable"].Value);
                    client.Cli_PicName = gridRow.Cells["gridColumnPic"].Value.ToString();
                }
                CreateClientForm ccf = new CreateClientForm();
                ccf.Client = client;
                ccf.ShowDialog(this);
                closeDispose();
            }
            else
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ���");
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlClient.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("ȷ��Ҫɾ��ѡ���е�������?","��ע��",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                Client client = new Client();
                ClientManager cm = new ClientManager();
                SelectedElementCollection col = superGridControlClient.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        bool result = cm.DeleteFake(gridRow.Cells[1].Value.ToString());
                        if(result)
                        {
                            MessageBox.Show("ɾ���ɹ�!");
                            isflag = true;
                            closeDispose();
                        }
                        else
                        {
                            MessageBox.Show("ɾ��ʧ��,�����Ƿ�ѡ��ָ����");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("ɾ���쳣,�������������:" + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("����ѡ��Ҫ����ɾ������");
            }
        }

        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName =  DateTime.Now.ToString("yyyyMMddHHmm") + "�ͻ�����";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel�ļ���*.xls��|*.xls|Excel �ļ�(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if(saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = (DataTable)superGridControlClient.PrimaryGrid.DataSource;
            GridColumnCollection gcc = superGridControlClient.PrimaryGrid.Columns;
            string[] x = {
                "�ͻ�����", "�ֻ�", "�绰", "����", "����", "��ϸ��ַ", "��ϵ��", "��λ", "�������", "�����ʺ�",
                "������", "����ʱ��", "���ö��", "ʣ����", "������", "Ӧ�տ�", "���տ�", "Ԥ�տ�", "��ע" };
            dt.Columns.Remove("Cli_ID");
            dt.Columns.Remove("Cli_Code");
            dt.Columns.Remove("Cli_zhiwen");
            dt.Columns.Remove("Cli_PicName");
            dt.Columns.Remove("Cli_CityCode");
            dt.Columns.Remove("Cli_TypeCode");
            dt.Columns.Remove("Cli_DiscountCode");
            dt.Columns.Remove("Cli_Olddata");
            dt.Columns.Remove("Cli_Oldreturn");
            dt.Columns.Remove("Cli_Newoutdata");
            dt.Columns.Remove("Cli_Newintodata");
            dt.Columns.Remove("Cli_safetone");
            dt.Columns.Remove("Cli_safettwo");
            dt.Columns.Remove("Cli_Enable");
            try
            {
                NPOIExcelHelper.DataTableToExcel(dt, "sdfe", saveFileDialog1.FileName, x);
                MessageBox.Show("Excel�ļ��ѳɹ��������뵽����Ŀ¼�²鿴��");
            }
            catch (Exception ex)
            {
                MessageBox.Show("����ʧ��,�����쳣���:" + ex.Message);
            }
        }

        #endregion

        #region ��DGV�ؼ����ϲ���
        /// <summary>
        /// ��DGV�ؼ����ϲ���
        /// </summary>
        private void MultiColumn()
        {
            GridPanel panel = superGridControlClient.PrimaryGrid;
            GridColumnCollection columns = panel.Columns;

            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns,
                    "Columnsbase",
                    "�ͻ���������",
                    "gridColumnCliName",
                    "gridColumnFax"));
            panel.ColumnHeader.GroupHeaders.Add(
                GetSlCompanyInfoHeader(
                    columns, 
                    "Columnslocation",
                    "��ϵ��ַ",
                    "gridColumnArea",
                    "gridColumnAd"));
            //panel.ColumnHeader.GroupHeaders.Add(
            //    GetSlCompanyInfoHeader(
            //        columns,
            //        "Columnsother",
            //        "������Ϣ",
            //        "gridColumnBa",
            //        "gridColumnPic"));
        }

        /// <summary>
        /// �ϲ��з���
        /// </summary>
        /// <returns></returns>
        private ColumnGroupHeader GetSlCompanyInfoHeader(
            GridColumnCollection columns,
            string name,
            string headerText,
            string startName,
            string endName)
        {
            ColumnGroupHeader cgh = new ColumnGroupHeader();

            cgh.Name = name;
            cgh.HeaderText = headerText;

            cgh.MinRowHeight = 36;

            cgh.StartDisplayIndex = GetDisplayIndex(columns, startName);
            cgh.EndDisplayIndex = GetDisplayIndex(columns, endName);

            //superGridControl1.PrimaryGrid
            return (cgh);
        }
        private int GetDisplayIndex(GridColumnCollection columns, string name)
        {
            return (columns.GetDisplayIndex(columns[name]));
        }
        #endregion

        #region dgv���Ҽ��˵�

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void �༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemDelete.PerformClick();
        }

        private void ɾ��ȫ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemAll.PerformClick();
        }

        private void ������ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemExcel.PerformClick();
        }

        private void ˢ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemRefresh.PerformClick();
        }



        #endregion

        #region ͨ�÷���

        //˫�������༭
        private void superGridControlClient_CellDoubleClick(object sender, 
            GridCellDoubleClickEventArgs e)
        {
            if(e.MouseEventArgs.Button == MouseButtons.Left)
            {
                ToolStripMenuItemEdit.PerformClick();
            }
        }

        /// <summary>
        /// �ر��Ӵ��������������ݵĴ��� 
        /// </summary>
        private void closeDispose()
        {
            if(isflag)
            {
                loadData();
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            else
            {
                treeViewClient.SelectedNode = treeViewClient.Nodes[0];
            }
            isflag = false;
        }

        private void loadTree()
        {
            treeViewClient.Nodes.Clear();
            CityManager cm = new CityManager();
            DataTable dt = cm.GetList("").Tables[0];
            AddTree("", null, dt);
        }

        #endregion
    }
}