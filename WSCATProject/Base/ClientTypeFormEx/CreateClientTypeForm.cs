using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Model;
using HelperUtility.Encrypt;

namespace WSCATProject.Base.ClientTypeFormEx
{
    public partial class CreateClientTypeForm : Form
    {
        public CreateClientTypeForm()
        {
            InitializeComponent();
        }

        private void buttonXOK_Click(object sender, EventArgs e)
        {
            ClientType ct = new ClientType();
            ClientTypeService cts = new ClientTypeService();
            ct.CT_Name = XYEEncoding.strCodeHex(textBoxXName.Text.Trim());
            ct.CT_Remark = XYEEncoding.strCodeHex(richTextBoxExRe.Text);
            ct.CT_Enable = 1;
            int result = cts.Add(ct);
            MessageBox.Show("添加成功!");
            ClientTypeForm.S = true;
            Close();
        }
    }
}
