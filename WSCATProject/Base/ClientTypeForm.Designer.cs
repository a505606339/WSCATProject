namespace WSCATProject.Base
{
    partial class ClientTypeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientTypeForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部删除AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部展开SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(411, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.全部删除AToolStripMenuItem,
            this.全部展开SToolStripMenuItem,
            this.查找FToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton1.Text = "选项(&P)";
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增ToolStripMenuItem.Text = "新增分类(&C)";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除DToolStripMenuItem.Text = "删除(&D)";
            // 
            // 全部删除AToolStripMenuItem
            // 
            this.全部删除AToolStripMenuItem.Name = "全部删除AToolStripMenuItem";
            this.全部删除AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部删除AToolStripMenuItem.Text = "全部删除(&A)";
            // 
            // 全部展开SToolStripMenuItem
            // 
            this.全部展开SToolStripMenuItem.Name = "全部展开SToolStripMenuItem";
            this.全部展开SToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部展开SToolStripMenuItem.Text = "全部展开(&S)";
            // 
            // 查找FToolStripMenuItem
            // 
            this.查找FToolStripMenuItem.Name = "查找FToolStripMenuItem";
            this.查找FToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.查找FToolStripMenuItem.Text = "查找...(&F)";
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Location = new System.Drawing.Point(0, 25);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.Size = new System.Drawing.Size(411, 370);
            this.superGridControl1.TabIndex = 1;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "CT_Name";
            this.gridColumn1.HeaderText = "类型";
            this.gridColumn1.Name = "TypeName";
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridColumn2.DataPropertyName = "CT_Remark";
            this.gridColumn2.HeaderText = "备注";
            this.gridColumn2.Name = "TypeRemark";
            // 
            // ClientTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 395);
            this.Controls.Add(this.superGridControl1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "ClientTypeForm";
            this.Text = "ClientTypeForm";
            this.Load += new System.EventHandler(this.ClientTypeForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部删除AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部展开SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找FToolStripMenuItem;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
    }
}