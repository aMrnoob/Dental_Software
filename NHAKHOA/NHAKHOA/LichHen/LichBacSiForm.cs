using NHAKHOA.LichHen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHAKHOA
{
    public partial class LichBacSiForm : Form
    {
        public LichBacSiForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_thembs_Click(object sender, EventArgs e)
        {
            ThemLichHenForm AddLH = new ThemLichHenForm();
            AddLH.Show(this);
        }

        private void button_dangki_Click(object sender, EventArgs e)
        {
            DKLichBSForm DKF = new DKLichBSForm();
            DKF.ShowDialog(this);
        }
    }
}
