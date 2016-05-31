using System;
using System.Windows.Forms;
using DAL;
using Model;
using HelperUtility.Encrypt;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;

namespace WSCATProject.Base.ClientTypeFormEx
{
    public partial class CreateClientTypeForm : OfficeForm
    {
        public CreateClientTypeForm()
        {
            InitializeComponent();
        }

        private void CreateClientTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            ClientType ct = new ClientType();
            ClientTypeService cts = new ClientTypeService();

            ct.CT_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
            ct.CT_Remark = XYEEncoding.strCodeHex(richTextBoxExRe.Text);
            ct.CT_Enable = 1;
            //写入用户类别
            int result = cts.Add(ct);

            MessageBox.Show("添加成功!");

            ClientTypeForm ctf = (ClientTypeForm)this.Owner;
            ctf.ReFresh = true;//提示需要刷新
            Close();
        }

        private void buttonXCancel_Click(object sender, EventArgs e)
        {
            ClientTypeForm ctf = (ClientTypeForm)this.Owner;
            ctf.ReFresh = false;//提示需要刷新
            Close();
        }

        private void CreateClientTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientTypeForm ctf = (ClientTypeForm)this.Owner;
            ctf.ReFresh = false;//提示需要刷新
        }
    }
}
