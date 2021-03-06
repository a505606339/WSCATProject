﻿using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSCATProject.Base
{
    public partial class ProjectCostType : MaterialNodeType
    {
        ProjectCostManager picm = new ProjectCostManager();
        ProjectCostNode picn = null;
        public ProjectCostType()
        {
            InitializeComponent();
            //菜单工具栏
            新增同级分类ToolStripMenuItem.Click += 新增同级分类ToolStripMenuItem_Click;
            新增下级分类ToolStripMenuItem.Click += 新增下级分类ToolStripMenuItem_Click;
            编辑ToolStripMenuItem.Click += 编辑ToolStripMenuItem_Click;
            删除ToolStripMenuItem.Click += 删除ToolStripMenuItem_Click;
            全部删除ToolStripMenuItem.Click += 全部删除ToolStripMenuItem_Click;
            展开第一节ToolStripMenuItem.Click += 展开第一节ToolStripMenuItem_Click;
            全部展开ToolStripMenuItem.Click += 全部展开ToolStripMenuItem_Click;
            刷新ToolStripMenuItem.Click += 刷新ToolStripMenuItem_Click;
        }

        private void ProjectCostType_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            Text = "其他支出项目";
            BindTreeViewList();
        }

        #region 操作-刷新
        /// <summary>
        /// 操作-刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            BindTreeViewList();
        } 
        #endregion

        #region 操作-全部展开
        /// <summary>
        /// 操作-全部展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 全部展开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].ExpandAll();
        } 
        #endregion

        #region 操作-展开第一节
        /// <summary>
        /// 操作-展开第一节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 展开第一节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Expand();
        } 
        #endregion

        #region 操作-全部删除
        /// <summary>
        /// 操作-全部删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 全部删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定全部删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                try
                {
                    int result = picm.UpdateAllClearProjectCost();
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        treeView1.Nodes.Clear();
                        BindTreeViewList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        } 
        #endregion

        #region 操作-删除
        /// <summary>
        /// 操作-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定删除吗? 删除后将不可恢复!", "WACAT管家", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                if (treeView1.SelectedNode == null)
                {
                    return;
                }
                string code = treeView1.SelectedNode.Tag.ToString();
                try
                {
                    int result = picm.UpdateClearProjectCost(code);
                    if (result > 0)
                    {
                        MessageBox.Show("删除成功!");
                        treeView1.Nodes.Clear();
                        BindTreeViewList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败,请检查服务器连接并尝试重新删除.错误:" + ex.Message);
                }
            }
        } 
        #endregion

        #region 操作-编辑
        /// <summary>
        /// 操作-编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectCostNode();
            picn.state = 2;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        } 
        #endregion

        #region 操作-新增下级分类
        /// <summary>
        /// 操作-新增下级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增下级分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectCostNode();
            picn.state = 1;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        } 
        #endregion

        #region 操作-新增同级分类
        /// <summary>
        /// 操作-新增同级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增同级分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picn = new ProjectCostNode();
            picn.state = 0;
            picn.txtName = treeView1.SelectedNode.Text;
            picn.code = treeView1.SelectedNode.Parent.Tag.ToString();
            picn.ShowDialog(this);
            if (isflag)
            {
                treeView1.Nodes.Clear();
                BindTreeViewList();
            }
        }
        #endregion

        #region 绑定TreeView
        /// <summary>
        /// 绑定TreeView
        /// </summary>
        private void BindTreeViewList()
        {
            try
            {
                DataTable dts = picm.SelProjectCostTable();
                base.AddTree("D4", null, dts, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        #endregion
    }
}
