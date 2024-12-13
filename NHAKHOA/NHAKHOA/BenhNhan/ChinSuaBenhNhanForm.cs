using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace NHAKHOA
{
    public partial class ChinSuaBenhNhanForm : Form
    {
        private int maBenhNhan;
        MYDB myDB = new MYDB();
        BENHNHAN benhnhan = new BENHNHAN();

        public ChinSuaBenhNhanForm()
        {
            InitializeComponent();
        }

        private void ChinSuaBenhNhanForm_Load(object sender, EventArgs e)
        {
            button_them.Enabled = false;
            double total = Convert.ToDouble(benhnhan.totalPatients());
            label_total.Text = "Tổng số BN: " + total.ToString();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                myDB.openConnection();

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM benhnhan", myDB.getConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView_dsbenhnhan.DataSource = dataTable;

                dataGridView_dsbenhnhan.RowTemplate.Height = 40;
                dataGridView_dsbenhnhan.AllowUserToAddRows = false;
                dataGridView_dsbenhnhan.ReadOnly = true;
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

        private void ClearFields()
        {
            textBox_ten.Text = "";
            dateTimePicker.Value = DateTime.Now;
            textBox_dienthoai.Text = "";
            textBox_diachi.Text = "";
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox_search.Text.Trim();

                string query;
                SqlCommand command;

                // Kiểm tra xem chuỗi có phải là số nguyên hợp lệ không
                if (int.TryParse(searchText, out int searchId))
                {
                    // Nếu là số nguyên, tìm kiếm theo ID
                    query = "SELECT * FROM benhnhan WHERE ma = @id";
                    command = new SqlCommand(query, myDB.getConnection);
                    command.Parameters.AddWithValue("@id", searchId);
                }
                else
                {
                    // Nếu không phải là số nguyên, tìm kiếm theo tên
                    query = "SELECT * FROM benhnhan WHERE ten LIKE @name";
                    command = new SqlCommand(query, myDB.getConnection);
                    command.Parameters.AddWithValue("@name", "%" + searchText + "%");
                }

                myDB.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBox_ma.Text = reader["ma"].ToString();
                    textBox_ten.Text = reader["ten"].ToString();
                    dateTimePicker.Value = (DateTime)reader["ngaysinh"];

                    string gender = reader["gioitinh"].ToString().ToLower();
                    if (gender == "nam")
                    {
                        radioButton_nam.Checked = true;
                    }
                    else if (gender == "nữ")
                    {
                        radioButton_nu.Checked = true;
                    }

                    textBox_dienthoai.Text = reader["dienthoai"].ToString();
                    textBox_diachi.Text = reader["diachi"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }

                myDB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int patientIdToDelete = Convert.ToInt32(textBox_ma.Text);

                DialogResult result = MessageBox.Show("Bạn có muốn xóa bệnh nhân này không?", "Xóa bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    myDB.openConnection();

                    SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM benhnhan WHERE ma = @id", myDB.getConnection);
                    checkCommand.Parameters.AddWithValue("@id", patientIdToDelete);

                    int patientCount = (int)checkCommand.ExecuteScalar();

                    if (patientCount > 0)
                    {
                        SqlCommand deleteCommand = new SqlCommand("DELETE FROM benhnhan WHERE ma = @id", myDB.getConnection);
                        deleteCommand.Parameters.AddWithValue("@id", patientIdToDelete);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa thành công.", "Xóa bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                            myDB.closeConnection();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No rows were deleted. Make sure the provided ID exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Patient with provided ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand updateCommand = new SqlCommand("UPDATE benhnhan SET ten = @name, gioitinh = @gender, ngaysinh = @birthdate, dienthoai = @phone, diachi = @address WHERE ma = @id", myDB.getConnection);
                updateCommand.Parameters.AddWithValue("@id", Convert.ToInt32(textBox_ma.Text));
                updateCommand.Parameters.AddWithValue("@name", textBox_ten.Text);
                string gender = radioButton_nam.Checked ? "Nam" : "Nữ";
                updateCommand.Parameters.AddWithValue("@gender", gender);
                updateCommand.Parameters.AddWithValue("@birthdate", dateTimePicker.Value.Date);
                updateCommand.Parameters.AddWithValue("@phone", textBox_dienthoai.Text);
                updateCommand.Parameters.AddWithValue("@address", textBox_diachi.Text);

                myDB.openConnection();
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đã sửa thành công.", "Chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã bệnh nhân.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                myDB.closeConnection();
            }
            LoadData();
        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File|*.xlsx";
            saveFileDialog1.Title = "Save Course Data";
            saveFileDialog1.FileName = "dsbenhnhan.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Set LicenseContext
                    OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Danh sach benh nhan");

                        // Đổ dữ liệu từ DataGridView vào Excel
                        for (int i = 0; i < dataGridView_dsbenhnhan.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView_dsbenhnhan.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 1, j + 1].Value = dataGridView_dsbenhnhan.Rows[i].Cells[j].Value;
                            }
                        }

                        FileInfo excelFile = new FileInfo(saveFileDialog1.FileName);
                        excelPackage.SaveAs(excelFile);
                    }

                    MessageBox.Show("Đã lưu file thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving course data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
