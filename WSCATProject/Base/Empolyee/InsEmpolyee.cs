using BLL;
using DAL;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
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
    public partial class InsEmpolyee : Form
    {
        EmpolyeeManager em = new EmpolyeeManager();
        DepartmentManager dm = new DepartmentManager();
        public InsEmpolyee()
        {
            InitializeComponent();
        }
        private void InsEmpolyee_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            textBox11.Text = DateTime.Now.ToString();
            comboBox1.DataSource = dm.SelDepartment();
            comboBox1.DisplayMember = "Dt_Name";
            comboBox1.ValueMember = "Dt_Code";
            EmpolyeeMaterial empM = (EmpolyeeMaterial)Owner;
            try
            {
                switch (empM.StateType)
                {
                    case 0:
                        textBox2.Text = BuildCode.ModuleCode("EMP");
                        break;
                    case 1:
                        T_Empolyee empolyee = em.SelEmpolyeeByCode(empM.id);
                        textBox1.Text = XYEEncoding.strHexDecode(empolyee.Emp_Name);
                        textBox2.Text = XYEEncoding.strHexDecode(empolyee.Emp_Code);
                        textBox3.Text = XYEEncoding.strHexDecode(empolyee.Emp_CardCode);
                        textBox4.Text = XYEEncoding.strHexDecode(empolyee.Emp_Phone);
                        textBox5.Text = XYEEncoding.strHexDecode(empolyee.Emp_Card);
                        textBox6.Text = empolyee.Emp_Birthday.ToString();
                        textBox7.Text = XYEEncoding.strHexDecode(empolyee.Emp_Email);
                        textBox8.Text = XYEEncoding.strHexDecode(empolyee.Emp_School);
                        textBox9.Text = XYEEncoding.strHexDecode(empolyee.Emp_Bank);
                        textBox10.Text = XYEEncoding.strHexDecode(empolyee.Emp_OpenBank);
                        textBox11.Text = empolyee.Emp_Entry.ToString();
                        comboBox1.Text = dm.SelDepartmentByCode(XYEEncoding.strHexDecode(empolyee.Emp_Depid)).Dt_Name;
                        comboBox2.Text = XYEEncoding.strHexDecode(empolyee.Emp_Education);
                        if (empolyee.Emp_Sex == "男")
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;

                        if (empolyee.Emp_State == 0)
                        {
                            checkBox2.Checked = true;
                        }
                        if (empolyee.Emp_Enable == 0)
                        {
                            checkBox1.Checked = true;
                        }
                        break;
                    default:
                        MessageBox.Show("类型错误！");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败,请检查服务器连接并尝试刷新.错误:" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EmpolyeeMaterial empM = (EmpolyeeMaterial)Owner;
            if (InsTextIsNull() == false)
            {
                return;
            }
            try
            {
                int result = InsEmpolyeeFun(empM.StateType);
                if (result > 0)
                {
                    empM.isflag = true;
                    MessageBox.Show("保存成功");
                    Close();
                    Dispose();
                }
                else
                {
                    empM.isflag = false;
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败,请检查服务器连接并尝试重新保存.错误:" + ex.Message);
            }
        }

        private int InsEmpolyeeFun(int state)
        {
            T_Empolyee emp = new T_Empolyee();
            emp.Emp_Name = XYEEncoding.strCodeHex(textBox1.Text.Trim());
            emp.Emp_Code = XYEEncoding.strCodeHex(textBox2.Text.Trim());
            emp.Emp_CardCode = XYEEncoding.strCodeHex(textBox3.Text.Trim());
            emp.Emp_Phone = XYEEncoding.strCodeHex(textBox4.Text.Trim());
            emp.Emp_Card = XYEEncoding.strCodeHex(textBox5.Text.Trim());
            emp.Emp_Birthday = Convert.ToDateTime(textBox6.Text);//textBox6
            emp.Emp_Email = XYEEncoding.strCodeHex(textBox7.Text.Trim());
            emp.Emp_School = XYEEncoding.strCodeHex(textBox8.Text.Trim());
            emp.Emp_Bank = XYEEncoding.strCodeHex(textBox9.Text.Trim());
            emp.Emp_OpenBank = XYEEncoding.strCodeHex(textBox10.Text.Trim());
            emp.Emp_Entry = Convert.ToDateTime(textBox11.Text); //textBox11
            emp.Emp_Depid = XYEEncoding.strCodeHex(comboBox1.SelectedValue.ToString());
            emp.Emp_Education = XYEEncoding.strCodeHex(comboBox2.Text);
            emp.Emp_Sex = XYEEncoding.strCodeHex(radioButton1.Checked == true ? "男" : "女");
            emp.Emp_Enable = checkBox1.Checked == true ? 0 : 1;
            emp.Emp_State = checkBox2.Checked == true ? 0 : 1;
            emp.Emp_Clear = 1;
            if (state == 0)
            {
                return em.InsEmpolyee(emp);
            }
            else
            {
                return em.UpdateEmpolyee(emp);
            }
        }

        #region 非空验证
        /// <summary>
        /// 非空验证
        /// </summary>
        /// <returns></returns>
        private bool InsTextIsNull()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("员工姓名不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("员工工号不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("生日不能为空！");
                return false;
            }
            if (comboBox1.SelectedText == "请选择")
            {
                MessageBox.Show("最高学历不能为空！");
                return false;
            }
            return true;
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        #endregion
    }
}
