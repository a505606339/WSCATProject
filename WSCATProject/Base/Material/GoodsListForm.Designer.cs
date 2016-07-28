namespace WSCATProject.Base.Material
{
    partial class GoodsListForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("所有商品");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewModel = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShowEnable = new System.Windows.Forms.CheckBox();
            this.textBoxXModel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxXBarcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewGoodsList = new System.Windows.Forms.DataGridView();
            this.gID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Columnzhujima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnStoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStoAllNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFloorNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonSelectClear = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoodsList)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(894, 512);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeViewModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 306);
            this.panel1.TabIndex = 2;
            // 
            // treeViewModel
            // 
            this.treeViewModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewModel.Font = new System.Drawing.Font("宋体", 13F);
            this.treeViewModel.Location = new System.Drawing.Point(0, 0);
            this.treeViewModel.Name = "treeViewModel";
            treeNode1.Name = "nodeAllGoods";
            treeNode1.Text = "所有商品";
            this.treeViewModel.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewModel.Size = new System.Drawing.Size(271, 306);
            this.treeViewModel.TabIndex = 0;
            this.treeViewModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewModel_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 206);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxShowEnable);
            this.groupBox1.Controls.Add(this.textBoxXModel);
            this.groupBox1.Controls.Add(this.textBoxXName);
            this.groupBox1.Controls.Add(this.textBoxXBarcode);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonSelect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // checkBoxShowEnable
            // 
            this.checkBoxShowEnable.AutoSize = true;
            this.checkBoxShowEnable.Location = new System.Drawing.Point(39, 170);
            this.checkBoxShowEnable.Name = "checkBoxShowEnable";
            this.checkBoxShowEnable.Size = new System.Drawing.Size(84, 16);
            this.checkBoxShowEnable.TabIndex = 1;
            this.checkBoxShowEnable.Text = "只显示可用";
            this.checkBoxShowEnable.UseVisualStyleBackColor = true;
            // 
            // textBoxXModel
            // 
            // 
            // 
            // 
            this.textBoxXModel.Border.Class = "TextBoxBorder";
            this.textBoxXModel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXModel.Location = new System.Drawing.Point(108, 113);
            this.textBoxXModel.Name = "textBoxXModel";
            this.textBoxXModel.PreventEnterBeep = true;
            this.textBoxXModel.Size = new System.Drawing.Size(123, 21);
            this.textBoxXModel.TabIndex = 23;
            // 
            // textBoxXName
            // 
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Location = new System.Drawing.Point(108, 74);
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(123, 21);
            this.textBoxXName.TabIndex = 22;
            // 
            // textBoxXBarcode
            // 
            // 
            // 
            // 
            this.textBoxXBarcode.Border.Class = "TextBoxBorder";
            this.textBoxXBarcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXBarcode.Location = new System.Drawing.Point(108, 36);
            this.textBoxXBarcode.Name = "textBoxXBarcode";
            this.textBoxXBarcode.PreventEnterBeep = true;
            this.textBoxXBarcode.Size = new System.Drawing.Size(123, 21);
            this.textBoxXBarcode.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "货品编码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "货品名称：";
            // 
            // buttonSelect
            // 
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelect.Location = new System.Drawing.Point(149, 165);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(82, 25);
            this.buttonSelect.TabIndex = 10;
            this.buttonSelect.Text = "检索";
            this.buttonSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "货品规格：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewGoodsList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(619, 347);
            this.panel4.TabIndex = 3;
            // 
            // dataGridViewGoodsList
            // 
            this.dataGridViewGoodsList.AllowUserToAddRows = false;
            this.dataGridViewGoodsList.AllowUserToDeleteRows = false;
            this.dataGridViewGoodsList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.ForestGreen;
            this.dataGridViewGoodsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGoodsList.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridViewGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoodsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gID,
            this.ColumnCode,
            this.ColumnSelect,
            this.Columnzhujima,
            this.ColumnGoodsName,
            this.ColumnModel,
            this.ColumnType,
            this.ColumnUnit,
            this.ColumnStoNum,
            this.ColumnBarcode,
            this.ColumnPrice,
            this.ColumnPrice2,
            this.ColumnPrice3,
            this.ColumnEnable});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGoodsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGoodsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGoodsList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGoodsList.MultiSelect = false;
            this.dataGridViewGoodsList.Name = "dataGridViewGoodsList";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            this.dataGridViewGoodsList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewGoodsList.RowTemplate.Height = 23;
            this.dataGridViewGoodsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoodsList.Size = new System.Drawing.Size(619, 347);
            this.dataGridViewGoodsList.TabIndex = 0;
            this.dataGridViewGoodsList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewGoodsList_CellMouseDoubleClick);
            // 
            // gID
            // 
            this.gID.DataPropertyName = "Ma_ID";
            this.gID.HeaderText = "ID";
            this.gID.Name = "gID";
            this.gID.ReadOnly = true;
            this.gID.Visible = false;
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "Ma_Code";
            this.ColumnCode.HeaderText = "code";
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.Visible = false;
            // 
            // ColumnSelect
            // 
            this.ColumnSelect.FalseValue = "false";
            this.ColumnSelect.HeaderText = "选择";
            this.ColumnSelect.Name = "ColumnSelect";
            this.ColumnSelect.TrueValue = "true";
            this.ColumnSelect.Width = 40;
            // 
            // Columnzhujima
            // 
            this.Columnzhujima.DataPropertyName = "Ma_zhujima";
            this.Columnzhujima.HeaderText = "助记码";
            this.Columnzhujima.Name = "Columnzhujima";
            this.Columnzhujima.ReadOnly = true;
            this.Columnzhujima.Width = 80;
            // 
            // ColumnGoodsName
            // 
            this.ColumnGoodsName.DataPropertyName = "Ma_Name";
            this.ColumnGoodsName.HeaderText = "货品名称";
            this.ColumnGoodsName.Name = "ColumnGoodsName";
            this.ColumnGoodsName.ReadOnly = true;
            this.ColumnGoodsName.Width = 120;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Ma_Model";
            this.ColumnModel.HeaderText = "规格型号";
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            this.ColumnModel.Width = 120;
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "Ma_TypeName";
            this.ColumnType.HeaderText = "货品类别";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnUnit
            // 
            this.ColumnUnit.DataPropertyName = "Ma_Unit";
            this.ColumnUnit.HeaderText = "单位";
            this.ColumnUnit.Name = "ColumnUnit";
            this.ColumnUnit.ReadOnly = true;
            this.ColumnUnit.Width = 60;
            // 
            // ColumnStoNum
            // 
            this.ColumnStoNum.DataPropertyName = "Sto_EnaNumber";
            this.ColumnStoNum.HeaderText = "库存量";
            this.ColumnStoNum.Name = "ColumnStoNum";
            // 
            // ColumnBarcode
            // 
            this.ColumnBarcode.DataPropertyName = "Ma_Barcode";
            this.ColumnBarcode.HeaderText = "条码";
            this.ColumnBarcode.Name = "ColumnBarcode";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.DataPropertyName = "Ma_Price";
            this.ColumnPrice.HeaderText = "建议售价";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnPrice2
            // 
            this.ColumnPrice2.DataPropertyName = "Ma_PriceA";
            this.ColumnPrice2.HeaderText = "建议售价A";
            this.ColumnPrice2.Name = "ColumnPrice2";
            // 
            // ColumnPrice3
            // 
            this.ColumnPrice3.DataPropertyName = "Ma_PriceB";
            this.ColumnPrice3.HeaderText = "建议售价B";
            this.ColumnPrice3.Name = "ColumnPrice3";
            // 
            // ColumnEnable
            // 
            this.ColumnEnable.DataPropertyName = "Ma_Enable";
            this.ColumnEnable.HeaderText = "是否已停用";
            this.ColumnEnable.Name = "ColumnEnable";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(619, 2);
            this.label1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 163);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 163);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStoName,
            this.ColumnStoAllNum,
            this.ColumnFloorNum});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(492, 143);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnStoName
            // 
            this.ColumnStoName.HeaderText = "仓库名称";
            this.ColumnStoName.Name = "ColumnStoName";
            this.ColumnStoName.ReadOnly = true;
            // 
            // ColumnStoAllNum
            // 
            this.ColumnStoAllNum.HeaderText = "可用总量";
            this.ColumnStoAllNum.Name = "ColumnStoAllNum";
            this.ColumnStoAllNum.ReadOnly = true;
            // 
            // ColumnFloorNum
            // 
            this.ColumnFloorNum.HeaderText = "安全数量";
            this.ColumnFloorNum.Name = "ColumnFloorNum";
            this.ColumnFloorNum.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonCancel);
            this.panel5.Controls.Add(this.buttonOk);
            this.panel5.Controls.Add(this.buttonSelectClear);
            this.panel5.Controls.Add(this.buttonSelectAll);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(498, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(121, 163);
            this.panel5.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Location = new System.Drawing.Point(23, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 25);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "关闭";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOk.Location = new System.Drawing.Point(23, 87);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(82, 25);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "确认";
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonSelectClear
            // 
            this.buttonSelectClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectClear.Location = new System.Drawing.Point(23, 47);
            this.buttonSelectClear.Name = "buttonSelectClear";
            this.buttonSelectClear.Size = new System.Drawing.Size(82, 25);
            this.buttonSelectClear.TabIndex = 11;
            this.buttonSelectClear.Text = "全清";
            this.buttonSelectClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectClear.UseVisualStyleBackColor = true;
            this.buttonSelectClear.Click += new System.EventHandler(this.buttonSelectClear_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSelectAll.Location = new System.Drawing.Point(23, 7);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(82, 25);
            this.buttonSelectAll.TabIndex = 10;
            this.buttonSelectAll.Text = "全选";
            this.buttonSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // GoodsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 512);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GoodsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品列表";
            this.Load += new System.EventHandler(this.GoodsListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoodsList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewGoodsList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonSelectClear;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Label label7;
        //private BlueTextBox blueTextBoxName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewModel;
        //private BlueTextBox blueTextBoxBarcode;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXBarcode;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXModel;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private System.Windows.Forms.CheckBox checkBoxShowEnable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoAllNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFloorNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnzhujima;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStoNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnable;
    }
}