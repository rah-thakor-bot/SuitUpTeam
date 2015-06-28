namespace PeculiarTuitionERP.Master_Module
{
    partial class frmSubjectMas
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
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.grdDet = new System.Windows.Forms.DataGridView();
            this.buttonPanelControl1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetail
            // 
            this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetail.Controls.Add(this.grdDet);
            this.grpDetail.Location = new System.Drawing.Point(12, 74);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(1155, 504);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Subject Master";
            // 
            // grdDet
            // 
            this.grdDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDet.Location = new System.Drawing.Point(3, 16);
            this.grdDet.Name = "grdDet";
            this.grdDet.Size = new System.Drawing.Size(1149, 485);
            this.grdDet.TabIndex = 0;
            // 
            // buttonPanelControl1
            // 
            this.buttonPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanelControl1.ButtonAddEnable = true;
            this.buttonPanelControl1.ButtonAddImage = null;
            this.buttonPanelControl1.ButtonAddText = "Add";
            this.buttonPanelControl1.ButtonAddVisible = true;
            this.buttonPanelControl1.ButtonCloseEnable = true;
            this.buttonPanelControl1.ButtonCloseImage = null;
            this.buttonPanelControl1.ButtonCloseVisible = true;
            this.buttonPanelControl1.ButtonDeleteEnable = true;
            this.buttonPanelControl1.ButtonDeleteImage = null;
            this.buttonPanelControl1.ButtonDeleteVisible = true;
            this.buttonPanelControl1.ButtonEditEnable = true;
            this.buttonPanelControl1.ButtonEditImage = null;
            this.buttonPanelControl1.ButtonEditText = "Edit";
            this.buttonPanelControl1.ButtonEditVisible = true;
            this.buttonPanelControl1.ButtonRefreshEnable = true;
            this.buttonPanelControl1.ButtonRefreshImage = null;
            this.buttonPanelControl1.ButtonRefreshVisible = true;
            this.buttonPanelControl1.ButtonSearchEnable = true;
            this.buttonPanelControl1.ButtonSearchImage = null;
            this.buttonPanelControl1.ButtonSearchText = "Search";
            this.buttonPanelControl1.ButtonSearchVisible = true;
            this.buttonPanelControl1.Location = new System.Drawing.Point(333, 610);
            this.buttonPanelControl1.MessageText = "";
            this.buttonPanelControl1.Name = "buttonPanelControl1";
            this.buttonPanelControl1.SetColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.SetDuration = 0;
            this.buttonPanelControl1.SetLightColor = System.Drawing.Color.Empty;
            this.buttonPanelControl1.Size = new System.Drawing.Size(498, 62);
            this.buttonPanelControl1.StartTime = new System.DateTime(((long)(0)));
            this.buttonPanelControl1.TabIndex = 2;
            // 
            // frmSubjectMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 706);
            this.Controls.Add(this.buttonPanelControl1);
            this.Controls.Add(this.grpDetail);
            this.Name = "frmSubjectMas";
            this.Text = "Subject Master";
            this.grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView grdDet;
        private Private.MyUserControls.ButtonPanelControl buttonPanelControl1;
    }
}