using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHAKHOA
{
    public partial class LoginForm : Form
    {
        MYDB myDB = new MYDB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            myDB.openConnection();

            String querry = "SELECT * FROM login WHERE username = '" + textBox_username.Text + "' AND password = '" + textBox_password.Text + "' ";

            SqlDataAdapter sda = new SqlDataAdapter(querry, myDB.getConnection);

            DataTable dtable = new DataTable();

            sda.Fill(dtable);

            if ((dtable.Rows.Count > 0))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_password_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_password.Checked == true) 
            {
                textBox_password.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_password.UseSystemPasswordChar = true;
            }

        }
    }
}
