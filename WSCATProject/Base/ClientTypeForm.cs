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
    public partial class ClientTypeForm : Form
    {
        public ClientTypeForm()
        {
            InitializeComponent();
        }

        private static bool s;
        public static bool S
        {
            get { return s; }
            set { s = value; }
        }

        private void ClientTypeForm_Load(object sender, EventArgs e)
        {
            superGridControl1.PrimaryGrid.AutoGenerateColumns = false;
            ClientType ct = new ClientType();
            ClientTypeService cts = new ClientTypeService();
            DataSet ds = cts.GetList("");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0].Clone();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].NewRow();
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        object temp = XYEEncoding.strHexDecode(ds.Tables[0].Rows[i][j].ToString());
                        if (temp != null && temp.ToString() != "")
                        {
                            dr[j] = temp;
                        }
                    }
                    dt.Rows.Add(dr.ItemArray);
                }
                superGridControl1.PrimaryGrid.DataSource = dt;
            }
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientTypeFormEx.CreateClientTypeForm cltf = new ClientTypeFormEx.CreateClientTypeForm();
            cltf.ShowDialog();
            if(s)
            {
                ClientType ct = new ClientType();
                ClientTypeService cts = new ClientTypeService();
                DataSet ds = cts.GetList("");
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0].Clone();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            object temp = XYEEncoding.strHexDecode(ds.Tables[0].Rows[i][j].ToString());
                            if (temp != null && temp.ToString() != "")
                            {
                                dr[j] = temp;
                            }
                        }
                        dt.Rows.Add(dr.ItemArray);
                    }
                    superGridControl1.PrimaryGrid.DataSource = dt;
                }
            }
        }
    }
}
