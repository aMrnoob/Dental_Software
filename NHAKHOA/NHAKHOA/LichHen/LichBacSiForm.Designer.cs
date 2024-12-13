namespace NHAKHOA
{
    partial class LichBacSiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_studentlist = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_dangki = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.button_thembs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentlist)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_studentlist
            // 
            this.dataGridView_studentlist.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_studentlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_studentlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_studentlist.Location = new System.Drawing.Point(46, 122);
            this.dataGridView_studentlist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_studentlist.Name = "dataGridView_studentlist";
            this.dataGridView_studentlist.RowHeadersWidth = 51;
            this.dataGridView_studentlist.RowTemplate.Height = 85;
            this.dataGridView_studentlist.Size = new System.Drawing.Size(785, 281);
            this.dataGridView_studentlist.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button_dangki);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.button_thembs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 53);
            this.panel2.TabIndex = 28;
            // 
            // button_dangki
            // 
            this.button_dangki.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_dangki.BackColor = System.Drawing.Color.White;
            this.button_dangki.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_dangki.FlatAppearance.BorderSize = 2;
            this.button_dangki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dangki.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dangki.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_dangki.Location = new System.Drawing.Point(718, 11);
            this.button_dangki.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_dangki.Name = "button_dangki";
            this.button_dangki.Size = new System.Drawing.Size(135, 28);
            this.button_dangki.TabIndex = 33;
            this.button_dangki.Text = "Đăng kí lịch";
            this.button_dangki.UseVisualStyleBackColor = false;
            this.button_dangki.Click += new System.EventHandler(this.button_dangki_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(20, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(88, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Lịch Bác Sĩ";
            // 
            // button_thembs
            // 
            this.button_thembs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_thembs.BackColor = System.Drawing.Color.White;
            this.button_thembs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_thembs.FlatAppearance.BorderSize = 2;
            this.button_thembs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_thembs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thembs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_thembs.Location = new System.Drawing.Point(565, 11);
            this.button_thembs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_thembs.Name = "button_thembs";
            this.button_thembs.Size = new System.Drawing.Size(135, 28);
            this.button_thembs.TabIndex = 32;
            this.button_thembs.Text = "Thêm Bác Sĩ";
            this.button_thembs.UseVisualStyleBackColor = false;
            this.button_thembs.Click += new System.EventHandler(this.button_thembs_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(43, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Danh sách lịch làm việc";
            // 
            // LichBacSiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView_studentlist);
            this.Name = "LichBacSiForm";
            this.Text = "LichBacSiForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_studentlist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_studentlist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_thembs;
        private System.Windows.Forms.Button button_dangki;
    }
}