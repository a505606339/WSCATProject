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
using DAL;
using HelperUtility.Encrypt;

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
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            ClientType ct = new ClientType();
            ClientTypeService cts = new ClientTypeService();
            DataSet ds = cts.GetList("");
            bindingDGVForDataTable(ds);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientTypeFormEx.CreateClientTypeForm cltf = new ClientTypeFormEx.CreateClientTypeForm();
            cltf.StartPosition = FormStartPosition.CenterParent;
            cltf.ShowDialog(this);
            if(refresh)
            {
                ClientType ct = new ClientType();
                ClientTypeService cts = new ClientTypeService();
                DataSet ds = cts.GetList("");
                bindingDGVForDataTable(ds);
                refresh = false;
            }
        }

        /// <summary>
        /// 将DataSet里的第一个table解密后绑定到控件上
        /// </summary>
        /// <param name="ds"></param>
        private void bindingDGVForDataTable(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CodingHelper codingHelper = new CodingHelper();
                    superGridControl1.PrimaryGrid.DataSource =
                        codingHelper.DataTableReCoding(ds.Tables[0]);
                }
            }
        }
    }
}
