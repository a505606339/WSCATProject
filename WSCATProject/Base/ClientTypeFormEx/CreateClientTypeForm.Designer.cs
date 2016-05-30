namespace WSCATProject.Base.ClientTypeFormEx
{
    partial class CreateClientTypeForm
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
            this.buttonXOK = new DevComponents.DotNetBar.ButtonX();
            this.textBoxXName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.richTextBoxExRe = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // buttonXOK
            // 
            this.buttonXOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonXOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonXOK.Location = new System.Drawing.Point(189, 89);
            this.buttonXOK.Name = "buttonXOK";
            this.buttonXOK.Size = new System.Drawing.Size(75, 23);
            this.buttonXOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonXOK.TabIndex = 0;
            this.buttonXOK.Text = "确定";
            this.buttonXOK.Click += new System.EventHandler(this.buttonXOK_Click);
            // 
            // textBoxXName
            // 
            // 
            // 
            // 
            this.textBoxXName.Border.Class = "TextBoxBorder";
            this.textBoxXName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxXName.Location = new System.Drawing.Point(83, 12);
            this.textBoxXName.Name = "textBoxXName";
            this.textBoxXName.PreventEnterBeep = true;
            this.textBoxXName.Size = new System.Drawing.Size(181, 21);
            this.textBoxXName.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "类别名称：";
            // 
            // richTextBoxExRe
            // 
            // 
            // 
            // 
            this.richTextBoxExRe.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxExRe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxExRe.Location = new System.Drawing.Point(83, 41);
            this.richTextBoxExRe.Name = "richTextBoxExRe";
            this.richTextBoxExRe.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.richTextBoxExRe.Size = new System.Drawing.Size(181, 39);
            this.richTextBoxExRe.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(39, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "备注：";
            // 
            // CreateClientTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(281, 121);
            this.Controls.Add(this.richTextBoxExRe);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.textBoxXName);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.buttonXOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CreateClientTypeForm";
            this.Text = "CreateClientType";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonXOK;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxXName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxExRe;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}