﻿using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;

namespace WSCATProject
{
    public partial class TemplateForm : Form
    {
        public TemplateForm()
        {
            InitializeComponent();
        }
        private void InputGoodsForm_Load(object sender, EventArgs e)
        {
            InitDataGridViewHeaderColumn();
            InitTopLab();
            InitTopLabText();
            InitBottomLab();
            InitBottonLabText();
            InitButton();
            dataGridViewFujia.ReadOnly = true;
            dataGridViewFujia.AllowUserToResizeColumns = false;
            dataGridViewFujia.AllowUserToResizeRows = false;
        }

        //对view添加列标题 
        protected virtual void InitDataGridViewHeaderColumn()
        {

        }

        /// <summary>
        /// 初始化上方lab
        /// </summary>
        protected virtual void InitTopLab()
        {

        }

        /// <summary>
        ///初始化上方输入框 
        /// </summary>
        protected virtual void InitTopLabText()
        {

        }

        /// <summary>
        /// 初始化下方lab
        /// </summary>
        protected virtual void InitBottomLab()
        {

        }

        /// <summary>
        /// 初始化下方输入框
        /// </summary>
        protected virtual void InitBottonLabText()
        {

        }

        /// <summary>
        /// 初始化界面按钮
        /// </summary>
        protected virtual void InitButton()
        {

        }

        /// <summary>
        /// 点击panel隐藏扩展panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void panel6_Click(object sender, EventArgs e)
        {
            if (resizablePanel1.Visible)
                resizablePanel1.Visible = false;
        }

        protected virtual void ClickPicBox(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            switch (pb.Name)
            {
                case "pictureBox1":
                    resizablePanel1.Location = new Point(120, 100);
                    break;
                case "pictureBox2":
                    resizablePanel1.Location = new Point(400, 100);
                    break;
                case "pictureBox3":
                    resizablePanel1.Location = new Point(400, 130);
                    break;
                case "pictureBox4":
                    resizablePanel1.Location = new Point(120, 160);
                    break;
            }
            if (!_btnAdd)
            {
                resizablePanel1.Visible = true;
                _btnAdd = true;
            }
            else
            {
                resizablePanel1.Size = new System.Drawing.Size(248, 144);
                resizablePanel1.Visible = true;
                resizablePanel1.Focus();
            }
        }

        //控制面板是否显示
        private bool _btnAdd = false;

        protected bool BtnAdd
        {
            get { return _btnAdd; }
            set { _btnAdd = value; }
        }

        protected virtual void dataGridViewFujia_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void superGridControl1_BeginEdit(object sender, GridEditEventArgs e)
        {
            if(e.GridCell.GridColumn.Name == "material")
            {
                resizablePanelData.Visible = true;
                resizablePanelData.Location = new Point(e.GridCell.UnMergedBounds.X ,
                    e.GridCell.UnMergedBounds.Bottom + panel7.Location.Y + 65);
            }
        }

        private void superGridControl1_CloseEdit(object sender, GridCloseEditEventArgs e)
        {
            resizablePanelData.Visible = false;
        }
    }
}
