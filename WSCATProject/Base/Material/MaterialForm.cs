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
using HelperUtility.Encrypt;
using DevComponents.DotNetBar.SuperGrid;
using HelperUtility.Excel;

namespace WSCATProject.Base
{
    public partial class MaterialForm : RibbonForm
    {
        public MaterialForm()
        {
            InitializeComponent();
        }

        DataSet allData = new DataSet();
        //����Ľڵ�text
        private string materialNodeText = "���";

        private bool isflag;
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

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            MaterialTypeManager mtm = new MaterialTypeManager();
            DataTable dt = mtm.GetList("").Tables[0];
            DataView dvTree = new DataView(dt);
            AddTree("", null, dvTree);
            loadData();
        }

        #region �˵�����

        //�½�
        private void ToolStripMenuItemCreate_Click(object sender, EventArgs e)
        {
            MaterialCreateForm mf = new MaterialCreateForm();
            mf.ShowDialog(this);
            closeDispose();
        }

        //�༭
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (superGridControlMaterial.GetSelectedRows().Count > 0)
            {
                Model.Material material = new Model.Material();
                SelectedElementCollection col = superGridControlMaterial.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    material.Ma_Barcode = gridRow.Cells["Ma_Barcode"].Value.ToString();
                    material.Ma_Clear = 1;
                    material.Ma_Code = gridRow.Cells["Ma_Code"].Value.ToString();
                    if(gridRow.Cells["Ma_CreateDate"].Value == null ||
                        gridRow.Cells["Ma_InDate"].Value == DBNull.Value)
                    {
                        material.Ma_CreateDate = null;
                    }
                    else
                    {
                        material.Ma_CreateDate = Convert.
                            ToDateTime(gridRow.Cells["Ma_CreateDate"].Value);
                    }
                    material.Ma_Enable = Convert.ToInt32(gridRow.Cells["Ma_Enable"].Value);
                    material.Ma_ID = Convert.ToInt32(gridRow.Cells["Ma_ID"].Value);
                    if(gridRow.Cells["Ma_InDate"].Value == null ||
                        gridRow.Cells["Ma_InDate"].Value == DBNull.Value)
                    {
                        material.Ma_InDate = null;
                    }
                    else
                    {
                        material.Ma_InDate = Convert.ToDateTime(gridRow.Cells["Ma_InDate"].Value);
                    }
                    material.Ma_InPrice = gridRow.Cells["Ma_InPrice"].Value.ToString();
                    material.Ma_Model = gridRow.Cells["Ma_Model"].Value.ToString();
                    material.Ma_Name = gridRow.Cells["Ma_Name"].Value.ToString();
                    material.Ma_PicName = gridRow.Cells["Ma_PicName"].Value.ToString();
                    material.Ma_Price = gridRow.Cells["Ma_Price"].Value.ToString();
                    material.Ma_PriceA = gridRow.Cells["Ma_PriceA"].Value.ToString();
                    material.Ma_PriceB = gridRow.Cells["Ma_PriceB"].Value.ToString();
                    material.Ma_PriceC = gridRow.Cells["Ma_PriceC"].Value.ToString();
                    material.Ma_PriceD = gridRow.Cells["Ma_PriceD"].Value.ToString();
                    material.Ma_PriceE = "";
                    material.Ma_Remark = gridRow.Cells["Ma_Remark"].Value.ToString();
                    material.Ma_RFID = gridRow.Cells["Ma_RFID"].Value.ToString();
                    material.Ma_Safetytwo = "";
                    material.Ma_Safeyone = "";
                    material.Ma_SupID = gridRow.Cells["Ma_SupID"].Value.ToString();
                    material.Ma_Supplier = gridRow.Cells["Ma_Supplier"].Value.ToString();
                    material.Ma_TypeID = gridRow.Cells["Ma_TypeID"].Value.ToString();
                    material.Ma_TypeName = gridRow.Cells["Ma_TypeName"].Value.ToString();
                    material.Ma_Unit = gridRow.Cells["Ma_Unit"].Value.ToString();
                    material.Ma_zhujima = gridRow.Cells["Ma_zhujima"].Value.ToString();
                }
                MaterialCreateForm mcf = new MaterialCreateForm();
                mcf.Material = material;
                mcf.ShowDialog(this);
                closeDispose();
            }
            else
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ���");
            }
        }

        //ɾ��
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (superGridControlMaterial.GetSelectedRows().Count > 0)
            {
                if (DialogResult.No == MessageBox.Show("ȷ��Ҫɾ��ѡ���е�������?", "��ע��",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                Client client = new Client();
                ClientManager cm = new ClientManager();
                SelectedElementCollection col = superGridControlMaterial.GetSelectedRows();
                if (col.Count > 0)
                {
                    GridRow gridRow = col[0] as GridRow;
                    try
                    {
                        bool result = cm.DeleteFake(gridRow.Cells[1].Value.ToString());
                        if (result)
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
                    catch (Exception ex)
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

        //ɾ��ȫ��
        private void ToolStripMenuItemAll_Click(object sender, EventArgs e)
        {

        }

        //����excel
        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e)
        {
            string defaultName = DateTime.Now.ToString("yyyyMMddHHmm") + "��Ʒ����";
            saveFileDialog1.FileName = defaultName + ".xls";
            saveFileDialog1.Filter = "Excel�ļ���*.xls��|*.xls|Excel �ļ�(*.xlsx)|*.xlsx";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DataTable dt = ((DataSet)superGridControlMaterial.PrimaryGrid.DataSource).Tables[0];
            GridColumnCollection gcc = superGridControlMaterial.PrimaryGrid.Columns;
            string[] x = {
                "��Ʒ����", "����ͺ�", "����", "������", "���", "�������", "�ۼ�", "Ԥ���ۼ�A", "Ԥ���ۼ�B", "Ԥ���ۼ�C",
                "Ԥ���ۼ�D", "Ԥ���ۼ�E", "����ʱ��", "��Ӧ��", "��λ", "����", "����ʱ��", "��ע", "���ñ�־", "Ԥ��1", "Ԥ��2" };
            dt.Columns.Remove("Ma_ID");
            dt.Columns.Remove("Ma_PicName");
            dt.Columns.Remove("Ma_RFID");
            dt.Columns.Remove("Ma_TypeID");
            dt.Columns.Remove("Ma_SupID");
            dt.Columns.Remove("Ma_Clear");
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

        //�˵�������ť ģ�������������Ƿ��з��ϵ�����
        private void toolStripButtonSeach_Click(object sender, EventArgs e)
        {
            string field = toolStripComboBoxKey.Text;
            string text = toolStripTextBoxValue.Text.Trim();
            MaterialManager mm = new MaterialManager();

            if (allData != null)
            {
                try
                {
                    superGridControlMaterial.PrimaryGrid.DataSource =
                                mm.searchClientByNodeClick(allData.Tables[0],
                                text, field);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //ˢ��
        private void ToolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
        }

        #endregion 

        #region treeview���Ҽ��˵�����

        private void �����¼��ڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMaterial.SelectedNode != null)
            {
                MaterialTypeManager mtm = new MaterialTypeManager();
                DataTable dt = mtm.GetList("").Tables[0];
                DataView dvTree = new DataView(dt);
                InsNodes insN = new InsNodes();
                insN.city_code = treeViewMaterial.SelectedNode.Tag.ToString();
                insN.ShowDialog(this);
                if (Isflag)
                {
                    treeViewMaterial.Nodes.Clear();
                    AddTree("", null, dvTree);
                    isflag = false;
                    this.Focus();
                }
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            }
        }

        private void �༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMaterial.SelectedNode != null)
            {
                MaterialTypeInsNodes insN = new MaterialTypeInsNodes();
                MaterialType mt = new MaterialType();
                mt.MT_Clear = 1;
                mt.MT_Code = treeViewMaterial.SelectedNode.Tag.ToString();
                mt.MT_Enable = 1;
                mt.MT_Name = treeViewMaterial.SelectedNode.Text;
                mt.MT_ParentID = treeViewMaterial.SelectedNode.Parent.Tag.ToString();
                insN.ShowDialog(this);
                if (Isflag)
                {
                    MaterialTypeManager mtm = new MaterialTypeManager();
                    DataTable dt = mtm.GetList("").Tables[0];
                    DataView dvTree = new DataView(dt);
                    treeViewMaterial.Nodes.Clear();
                    AddTree("", null, dvTree);
                    isflag = false;
                    Focus();
                }
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ���ӵ��ϼ�����");
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewMaterial.SelectedNode != null)
            {
                if (DialogResult.Yes != MessageBox.Show("ȷ��Ҫɾ����ѡ�ڵ���?�ò��������ɻָ�,��ע��.","��ȷ��",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2))
                {
                    return;
                }
                MaterialTypeManager mtm = new MaterialTypeManager();
                try
                {
                    if(mtm.DeleteFake(treeViewMaterial.SelectedNode.Tag.ToString()))
                    {
                        MessageBox.Show("ɾ���ɹ�!");
                        DataTable dt = mtm.GetList("").Tables[0];
                        DataView dvTree = new DataView(dt);
                        treeViewMaterial.Nodes.Clear();
                        AddTree("", null, dvTree);
                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ��,������.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ɾ���ڵ����,�������������.�쳣:" + ex.Message);
                }
            }
        }

        //����ڵ��������ϸ÷�Χ������
        private void treeViewMaterial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            materialNodeText = e.Node.Text;
            MaterialManager mm = new MaterialManager();
            if (allData != null)
            {
                try
                {
                    superGridControlMaterial.PrimaryGrid.DataSource =
                                mm.searchClientByNodeClick(allData.Tables[0],
                                materialNodeText, "�������");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region dgv���Ҽ��˵�����

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemCreate.PerformClick();
        }

        private void �༭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemEdit.PerformClick();
        }

        private void ɾ��ToolStripMenuItem1_Click(object sender, EventArgs e)
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

        /// <summary>
        /// �ر��Ӵ��������������ݵĴ���
        /// </summary>
        private void closeDispose()
        {
            if (Isflag)
            {
                loadData();
                treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
            }
            else
            {
                treeViewMaterial.SelectedNode = treeViewMaterial.Nodes[0];
            }
            Isflag = false;
        }

        /// <summary>
        /// ����datagridview������
        /// </summary>
        private void loadData()
        {
            MaterialManager mm = new MaterialManager();
            allData = mm.GetList("");
            superGridControlMaterial.PrimaryGrid.DataSource = allData;
        }

        /// <summary>
        /// �ص�������״ͼ
        /// </summary>
        /// <param name="ParentID">����ID ��ʼӦΪ""</param>
        /// <param name="pNode">��ǰ�ڵ� ��ʼΪnull</param>
        /// <param name="dvTree">data��ͼ ��ʼΪ���е�datatable����</param>
        private void AddTree(string ParentID, TreeNode pNode, DataView dvTree)
        {
            if (ParentID == "")
            {
                ParentID = "0";
            }
            string ParentId = "MT_ParentID";
            string Code = "MT_Code";
            string Name = "MT_Name";

            //����ParentID,�õ���ǰ�������ӽڵ�
            dvTree.RowFilter = string.Format("{0} = '{1}'", ParentId, ParentID);
            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {
                    //��Ӹ��ڵ�
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    treeViewMaterial.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);
                    //չ����һ���ڵ�
                    Node.Expand();
                }
                else
                {
                    //��ӵ�ǰ�ڵ���ӽڵ�
                    Node.Text = Row[Name].ToString();
                    Node.Tag = Row[Code].ToString();
                    pNode.Nodes.Add(Node);
                    AddTree(Row[Code].ToString(), Node, dvTree);//�ٴεݹ�
                }
            }
        }
        #endregion
    }
}