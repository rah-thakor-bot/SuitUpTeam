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
            this.grpSubjectMaster = new System.Windows.Forms.GroupBox();
            this.grpChapterDetail = new System.Windows.Forms.GroupBox();
            this.grdChpDet = new System.Windows.Forms.DataGridView();
            this.grdSubMas = new System.Windows.Forms.DataGridView();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpSubjectMaster.SuspendLayout();
            this.grpChapterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChpDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubMas)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSubjectMaster
            // 
            this.grpSubjectMaster.Controls.Add(this.grpChapterDetail);
            this.grpSubjectMaster.Controls.Add(this.grdSubMas);
            this.grpSubjectMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSubjectMaster.Location = new System.Drawing.Point(0, 0);
            this.grpSubjectMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSubjectMaster.Name = "grpSubjectMaster";
            this.grpSubjectMaster.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSubjectMaster.Size = new System.Drawing.Size(1294, 659);
            this.grpSubjectMaster.TabIndex = 1;
            this.grpSubjectMaster.TabStop = false;
            this.grpSubjectMaster.Text = "Subject Master";
            // 
            // grpChapterDetail
            // 
            this.grpChapterDetail.Controls.Add(this.grdChpDet);
            this.grpChapterDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChapterDetail.Location = new System.Drawing.Point(3, 298);
            this.grpChapterDetail.Name = "grpChapterDetail";
            this.grpChapterDetail.Size = new System.Drawing.Size(1288, 339);
            this.grpChapterDetail.TabIndex = 1;
            this.grpChapterDetail.TabStop = false;
            this.grpChapterDetail.Text = "Chapter Detail";
            // 
            // grdChpDet
            // 
            this.grdChpDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChpDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChpDet.Location = new System.Drawing.Point(3, 21);
            this.grdChpDet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdChpDet.Name = "grdChpDet";
            this.grdChpDet.Size = new System.Drawing.Size(1282, 315);
            this.grdChpDet.TabIndex = 1;
            this.grdChpDet.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdChpDet_DataError);
            this.grdChpDet.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChpDet_RowEnter);
            // 
            // grdSubMas
            // 
            this.grdSubMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSubMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSubMas.Location = new System.Drawing.Point(3, 22);
            this.grdSubMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdSubMas.Name = "grdSubMas";
            this.grdSubMas.Size = new System.Drawing.Size(1288, 276);
            this.grdSubMas.TabIndex = 0;
            this.grdSubMas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdSubMas_DataError);
            this.grdSubMas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSubMas_RowEnter);
            // 
            // btnMainPanel1
            // 
            this.btnMainPanel1.ButtonAddEnable = true;
            this.btnMainPanel1.ButtonAddImage = null;
            this.btnMainPanel1.ButtonAddText = "Add";
            this.btnMainPanel1.ButtonAddVisible = true;
            this.btnMainPanel1.ButtonCloseEnable = true;
            this.btnMainPanel1.ButtonCloseImage = null;
            this.btnMainPanel1.ButtonCloseVisible = true;
            this.btnMainPanel1.ButtonDeleteEnable = true;
            this.btnMainPanel1.ButtonDeleteImage = null;
            this.btnMainPanel1.ButtonDeleteVisible = true;
            this.btnMainPanel1.ButtonEditEnable = true;
            this.btnMainPanel1.ButtonEditImage = null;
            this.btnMainPanel1.ButtonEditText = "Edit";
            this.btnMainPanel1.ButtonEditVisible = true;
            this.btnMainPanel1.ButtonRefreshEnable = true;
            this.btnMainPanel1.ButtonRefreshImage = null;
            this.btnMainPanel1.ButtonRefreshVisible = true;
            this.btnMainPanel1.ButtonSearchEnable = true;
            this.btnMainPanel1.ButtonSearchImage = null;
            this.btnMainPanel1.ButtonSearchText = "Search";
            this.btnMainPanel1.ButtonSearchVisible = true;
            this.btnMainPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 651);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1294, 81);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 2;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnCloseClick);
            // 
            // frmSubjectMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 732);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpSubjectMaster);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSubjectMas";
            this.Tag = "SubjectMas";
            this.Text = "Subject Master";
            this.Load += new System.EventHandler(this.frmSubjectMas_Load);
            this.grpSubjectMaster.ResumeLayout(false);
            this.grpChapterDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChpDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSubjectMaster;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpChapterDetail;
        private System.Windows.Forms.DataGridView grdChpDet;
        public System.Windows.Forms.DataGridView grdSubMas;
    }
}