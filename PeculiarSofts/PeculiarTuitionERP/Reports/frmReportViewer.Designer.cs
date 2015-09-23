namespace PeculiarTuitionERP.Reports
{
    partial class frmReportViewer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpCriteria = new System.Windows.Forms.GroupBox();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.grdReportMas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxtFrDate = new System.Windows.Forms.MaskedTextBox();
            this.mtxtToDate = new System.Windows.Forms.MaskedTextBox();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.CmbEmpType = new System.Windows.Forms.ComboBox();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportMas)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpCriteria);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdReportMas);
            this.splitContainer1.Size = new System.Drawing.Size(1180, 770);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpCriteria
            // 
            this.grpCriteria.Controls.Add(this.btnCancel);
            this.grpCriteria.Controls.Add(this.btnGetReport);
            this.grpCriteria.Controls.Add(this.cmbEmp);
            this.grpCriteria.Controls.Add(this.CmbEmpType);
            this.grpCriteria.Controls.Add(this.cmbBatch);
            this.grpCriteria.Controls.Add(this.mtxtToDate);
            this.grpCriteria.Controls.Add(this.mtxtFrDate);
            this.grpCriteria.Controls.Add(this.label5);
            this.grpCriteria.Controls.Add(this.label4);
            this.grpCriteria.Controls.Add(this.label3);
            this.grpCriteria.Controls.Add(this.label2);
            this.grpCriteria.Controls.Add(this.label1);
            this.grpCriteria.Controls.Add(this.cmbReport);
            this.grpCriteria.Controls.Add(this.lblReportName);
            this.grpCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCriteria.Location = new System.Drawing.Point(0, 0);
            this.grpCriteria.Name = "grpCriteria";
            this.grpCriteria.Size = new System.Drawing.Size(1180, 217);
            this.grpCriteria.TabIndex = 0;
            this.grpCriteria.TabStop = false;
            this.grpCriteria.Text = "Report Details";
            // 
            // cmbReport
            // 
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(139, 32);
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.Size = new System.Drawing.Size(121, 25);
            this.cmbReport.TabIndex = 0;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(12, 32);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(86, 17);
            this.lblReportName.TabIndex = 50;
            this.lblReportName.Text = "Select Report";
            // 
            // grdReportMas
            // 
            this.grdReportMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReportMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReportMas.Location = new System.Drawing.Point(0, 0);
            this.grdReportMas.Name = "grdReportMas";
            this.grdReportMas.Size = new System.Drawing.Size(1180, 549);
            this.grdReportMas.TabIndex = 20;
            this.grdReportMas.Tag = "grdReportMas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "Batch Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Emploee Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Employee Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "From Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "To Date";
            // 
            // mtxtFrDate
            // 
            this.mtxtFrDate.Location = new System.Drawing.Point(376, 73);
            this.mtxtFrDate.Mask = "00/00/0000";
            this.mtxtFrDate.Name = "mtxtFrDate";
            this.mtxtFrDate.Size = new System.Drawing.Size(100, 25);
            this.mtxtFrDate.TabIndex = 5;
            this.mtxtFrDate.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtToDate
            // 
            this.mtxtToDate.Location = new System.Drawing.Point(376, 111);
            this.mtxtToDate.Mask = "00/00/0000";
            this.mtxtToDate.Name = "mtxtToDate";
            this.mtxtToDate.Size = new System.Drawing.Size(100, 25);
            this.mtxtToDate.TabIndex = 6;
            this.mtxtToDate.ValidatingType = typeof(System.DateTime);
            // 
            // cmbBatch
            // 
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(139, 73);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(121, 25);
            this.cmbBatch.TabIndex = 1;
            // 
            // CmbEmpType
            // 
            this.CmbEmpType.FormattingEnabled = true;
            this.CmbEmpType.Location = new System.Drawing.Point(139, 111);
            this.CmbEmpType.Name = "CmbEmpType";
            this.CmbEmpType.Size = new System.Drawing.Size(121, 25);
            this.CmbEmpType.TabIndex = 133;
            // 
            // cmbEmp
            // 
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(139, 149);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(121, 25);
            this.cmbEmp.TabIndex = 4;
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(281, 27);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(75, 33);
            this.btnGetReport.TabIndex = 7;
            this.btnGetReport.Text = "View Data";
            this.btnGetReport.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 770);
            this.Controls.Add(this.splitContainer1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReportViewer";
            this.Tag = "ReportView";
            this.Text = "Report Viewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpCriteria.ResumeLayout(false);
            this.grpCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpCriteria;
        private System.Windows.Forms.DataGridView grdReportMas;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.ComboBox cmbReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtToDate;
        private System.Windows.Forms.MaskedTextBox mtxtFrDate;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.ComboBox CmbEmpType;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGetReport;
    }
}