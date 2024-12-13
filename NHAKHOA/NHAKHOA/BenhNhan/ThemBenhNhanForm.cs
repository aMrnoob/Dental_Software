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
    public partial class ThemBenhNhanForm : Form
    {
        MYDB myDB = new MYDB();
        BENHNHAN benhnhan = new BENHNHAN();

        public ThemBenhNhanForm()
        {
            InitializeComponent();
        }

        private void ThemBenhNhanForm_Load(object sender, EventArgs e)
        {
            button_xoa.Enabled = false;
            button_sua.Enabled = false;
            button_luu.Enabled = false;
        }

        private bool IsIdExist(int ma)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[benhnhan] WHERE ma = @ma", myDB.getConnection))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        bool verif()
        {
            return !(string.IsNullOrWhiteSpace(textBox_ten.Text) ||
                     string.IsNullOrWhiteSpace(textBox_dienthoai.Text) ||
                     string.IsNullOrWhiteSpace(textBox_diachi.Text));
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            try
            {
                myDB.openConnection();

                int ma = Convert.ToInt32(textBox_ma.Text);

                if (IsIdExist(ma))
                {
                    MessageBox.Show("Mã bệnh nhân đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ten = textBox_ten.Text;
                string gioiTinh = radioButton_nam.Checked ? "Nam" : "Nữ";
                DateTime ngaySinh = dateTimePicker.Value.Date;
                string dienThoai = textBox_dienthoai.Text;
                string diaChi = textBox_diachi.Text;

                if (verif())
                {
                    if (benhnhan.insertPatient(ma, ten, gioiTinh, ngaySinh, dienThoai, diaChi))
                    {
                        MessageBox.Show("Thêm bệnh nhân mới thành công", "Thêm Bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm bệnh nhân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nhập thiếu thông tin", "Thêm Bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDB.closeConnection();
            }
        }

        private void button_lammoi_Click(object sender, EventArgs e)
        {
            textBox_ma.Text = "";
            textBox_ten.Text = "";
            textBox_dienthoai.Text = "";
            textBox_diachi.Text = "";
            dateTimePicker.Value = DateTime.Now;
        }
    }
}
