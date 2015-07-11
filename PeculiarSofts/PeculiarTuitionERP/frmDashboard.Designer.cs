namespace PeculiarTuitionERP
{
    partial class frmDashboard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewAdmission = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnExamDet = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 509);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dashboard";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNewAdmission);
            this.flowLayoutPanel1.Controls.Add(this.btnTimetable);
            this.flowLayoutPanel1.Controls.Add(this.btnExamDet);
            this.flowLayoutPanel1.Controls.Add(this.btnResult);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(730, 487);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNewAdmission
            // 
            this.btnNewAdmission.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNewAdmission.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNewAdmission.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewAdmission.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAdmission.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnNewAdmission.Location = new System.Drawing.Point(10, 10);
            this.btnNewAdmission.Margin = new System.Windows.Forms.Padding(10);
            this.btnNewAdmission.Name = "btnNewAdmission";
            this.btnNewAdmission.Size = new System.Drawing.Size(233, 160);
            this.btnNewAdmission.TabIndex = 0;
            this.btnNewAdmission.Text = "New Admisssion";
            this.btnNewAdmission.UseVisualStyleBackColor = false;
            // 
            // btnTimetable
            // 
            this.btnTimetable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimetable.AutoEllipsis = true;
            this.btnTimetable.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTimetable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimetable.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimetable.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnTimetable.Location = new System.Drawing.Point(263, 10);
            this.btnTimetable.Margin = new System.Windows.Forms.Padding(10);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(233, 160);
            this.btnTimetable.TabIndex = 1;
            this.btnTimetable.Text = "Timetable";
            this.btnTimetable.UseVisualStyleBackColor = false;
            // 
            // btnExamDet
            // 
            this.btnExamDet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExamDet.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExamDet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExamDet.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExamDet.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnExamDet.Location = new System.Drawing.Point(10, 190);
            this.btnExamDet.Margin = new System.Windows.Forms.Padding(10);
            this.btnExamDet.Name = "btnExamDet";
            this.btnExamDet.Size = new System.Drawing.Size(233, 160);
            this.btnExamDet.TabIndex = 2;
            this.btnExamDet.Text = "Exam Details";
            this.btnExamDet.UseVisualStyleBackColor = false;
            // 
            // btnResult
            // 
            this.btnResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnResult.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnResult.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnResult.Location = new System.Drawing.Point(263, 190);
            this.btnResult.Margin = new System.Windows.Forms.Padding(10);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(233, 160);
            this.btnResult.TabIndex = 3;
            this.btnResult.Text = "Result Details";
            this.btnResult.UseVisualStyleBackColor = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 509);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNewAdmission;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnExamDet;
        private System.Windows.Forms.Button btnResult;
    }
}