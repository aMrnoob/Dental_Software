using NHAKHOA.DieuTri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHAKHOA
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        bool expand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                flowLayoutPanel_benhnhan.Height += 1000;
                if (flowLayoutPanel_benhnhan.Height >= flowLayoutPanel_benhnhan.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand = true;
                }
            }
            else
            {
                flowLayoutPanel_benhnhan.Height -= 1000;
                if (flowLayoutPanel_benhnhan.Height <= flowLayoutPanel_benhnhan.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand = false;
                }
            }
        }

        private void button_benhnhan_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool expand2 = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (expand2 == false)
            {
                flowLayoutPanel_lichhen.Height += 1000;
                if (flowLayoutPanel_lichhen.Height >= flowLayoutPanel_lichhen.MaximumSize.Height)
                {
                    timer2.Stop();
                    expand2 = true;
                }
            }
            else
            {
                flowLayoutPanel_lichhen.Height -= 1000;
                if (flowLayoutPanel_lichhen.Height <= flowLayoutPanel_lichhen.MinimumSize.Height)
                {
                    timer2.Stop();
                    expand2 = false;
                }
            }
        }

        private void button_lichhen_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        bool expand3 = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (expand3 == false)
            {
                flowLayoutPanel_dieutri.Height += 1000;
                if (flowLayoutPanel_dieutri.Height >= flowLayoutPanel_dieutri.MaximumSize.Height)
                {
                    timer3.Stop();
                    expand3 = true;
                }
            }
            else
            {
                flowLayoutPanel_dieutri.Height -= 1000;
                if (flowLayoutPanel_dieutri.Height <= flowLayoutPanel_dieutri.MinimumSize.Height)
                {
                    timer3.Stop();
                    expand3 = false;
                }
            }
        }

        private void button_dieutri_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        bool expand4 = false;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (expand4 == false)
            {
                flowLayoutPanel_taichinh.Height += 1000;
                if (flowLayoutPanel_taichinh.Height >= flowLayoutPanel_taichinh.MaximumSize.Height)
                {
                    timer4.Stop();
                    expand4 = true;
                }
            }
            else
            {
                flowLayoutPanel_taichinh.Height -= 1000;
                if (flowLayoutPanel_taichinh.Height <= flowLayoutPanel_taichinh.MinimumSize.Height)
                {
                    timer4.Stop();
                    expand4 = false;
                }
            }
        }
        private void button_taichinh_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        bool expand5 = false;
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (expand5 == false)
            {
                flowLayoutPanel_baocao.Height += 1000;
                if (flowLayoutPanel_baocao.Height >= flowLayoutPanel_baocao.MaximumSize.Height)
                {
                    timer5.Stop();
                    expand5 = true;
                }
            }
            else
            {
                flowLayoutPanel_baocao.Height -= 1000;
                if (flowLayoutPanel_baocao.Height <= flowLayoutPanel_baocao.MinimumSize.Height)
                {
                    timer5.Stop();
                    expand5 = false;
                }
            }
        }

        private void button_baocao_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }

        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_menu.Controls.Add(childForm);
            panel_menu.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_thembenhnhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThemBenhNhanForm());
        }

        private void button_chinhsuabenhnhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChinSuaBenhNhanForm());
        }

        private void button_lichsu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichSuDieuTriForm());
        }
        //
        private void button_taolichhen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichHenForm());
        }

        private void button_lichbacsi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichBacSiForm());
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm = null;
            }

        }

        private void button_thuocdichvu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThuocVaDVForm());
        }

        private void button_quatrinhdieutri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuaTrinhDieuTriForm());
        }

        private void button_kehoachdieutri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KeHoachDieuTriForm());
        }

        private void button_chiphi_Click(object sender, EventArgs e)
        {

        }

        private void button_hoadon_Click(object sender, EventArgs e)
        {

        }
    }
}
