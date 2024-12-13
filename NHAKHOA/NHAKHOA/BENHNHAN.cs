using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAKHOA
{
    internal class BENHNHAN
    {
        MYDB myDB = new MYDB();

        // Phương thức để chèn một bệnh nhân mới vào cơ sở dữ liệu
        public bool insertPatient(int ma, string ten, string gioitinh, DateTime ngaysinh, string dienthoai, string diachi)
        {
            SqlCommand command = new SqlCommand("INSERT INTO benhnhan (ma, ten, gioitinh, ngaysinh, dienthoai, diachi)" +
                " VALUES (@ma, @ten, @gioitinh, @ngaysinh, @dienthoai, @diachi)", myDB.getConnection);
            command.Parameters.Add("@ma", SqlDbType.Int).Value = ma;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = gioitinh;
            command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = ngaysinh;
            command.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = dienthoai;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;

            myDB.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                myDB.closeConnection();
                return true;
            }
            else
            {
                myDB.closeConnection();
                return false;
            }
        }

        // Phương thức để lấy danh sách bệnh nhân từ cơ sở dữ liệu
        public DataTable getPatients(SqlCommand command)
        {
            command.Connection = myDB.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Phương thức để thực thi một truy vấn đếm và trả về kết quả dưới dạng chuỗi
        public string execCount(string query)
        {
            myDB.openConnection();
            SqlCommand command = new SqlCommand(query, myDB.getConnection);
            string count = command.ExecuteScalar().ToString();
            myDB.closeConnection();
            return count;
        }

        // Phương thức để đếm tổng số bệnh nhân
        public string totalPatients()
        {
            return execCount("SELECT COUNT(*) FROM benhnhan");
        }
    }
}
