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
            this.grdChapterDetail = new System.Windows.Forms.DataGridView();
            this.grdSubjectMaster = new System.Windows.Forms.DataGridView();
            this.btnMainPanel = new Private.MyUserControls.ButtonPanelControl();
            this.grpSubjectMaster.SuspendLayout();
            this.grpChapterDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChapterDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubjectMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSubjectMaster
            // 
            this.grpSubjectMaster.Controls.Add(this.grpChapterDetail);
            this.grpSubjectMaster.Controls.Add(this.grdSubjectMaster);
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
            this.grpChapterDetail.Controls.Add(this.grdChapterDetail);
            this.grpChapterDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChapterDetail.Location = new System.Drawing.Point(3, 298);
            this.grpChapterDetail.Name = "grpChapterDetail";
            this.grpChapterDetail.Size = new System.Drawing.Size(1288, 339);
            this.grpChapterDetail.TabIndex = 1;
            this.grpChapterDetail.TabStop = false;
            this.grpChapterDetail.Text = "Chapter Detail";
            // 
            // grdChapterDetail
            // 
            this.grdChapterDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChapterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChapterDetail.Location = new System.Drawing.Point(3, 21);
            this.grdChapterDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdChapterDetail.Name = "grdChapterDetail";
            this.grdChapterDetail.Size = new System.Drawing.Size(1282, 315);
            this.grdChapterDetail.TabIndex = 1;
            // 
            // grdSubjectMaster
            // 
            this.grdSubjectMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSubjectMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSubjectMaster.Location = new System.Drawing.Point(3, 22);
            this.grdSubjectMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdSubjectMaster.Name = "grdSubjectMaster";
            this.grdSubjectMaster.Size = new System.Drawing.Size(1288, 276);
            this.grdSubjectMaster.TabIndex = 0;
            // 
            // btnMainPanel
            // 
            this.btnMainPanel.ButtonAddEnable = true;
            this.btnMainPanel.ButtonAddImage = null;
            this.btnMainPanel.ButtonAddText = "Add";
            this.btnMainPanel.ButtonAddVisible = true;
            this.btnMainPanel.ButtonCloseEnable = true;
            this.btnMainPanel.ButtonCloseImage = null;
            this.btnMainPanel.ButtonCloseVisible = true;
            this.btnMainPanel.ButtonDeleteEnable = true;
            this.btnMainPanel.ButtonDeleteImage = null;
            this.btnMainPanel.ButtonDeleteVisible = true;
            this.btnMainPanel.ButtonEditEnable = true;
            this.btnMainPanel.ButtonEditImage = null;
            this.btnMainPanel.ButtonEditText = "Edit";
            this.btnMainPanel.ButtonEditVisible = true;
            this.btnMainPanel.ButtonRefreshEnable = true;
            this.btnMainPanel.ButtonRefreshImage = null;
            this.btnMainPanel.ButtonRefreshVisible = true;
            this.btnMainPanel.ButtonSearchEnable = true;
            this.btnMainPanel.ButtonSearchImage = null;
            this.btnMainPanel.ButtonSearchText = "Search";
            this.btnMainPanel.ButtonSearchVisible = true;
            this.btnMainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMainPanel.Location = new System.Drawing.Point(0, 651);
            this.btnMainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMainPanel.MessageText = "";
            this.btnMainPanel.Name = "btnMainPanel";
            this.btnMainPanel.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel.SetDuration = 0;
            this.btnMainPanel.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel.Size = new System.Drawing.Size(1294, 81);
            this.btnMainPanel.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel.TabIndex = 2;
            this.btnMainPanel.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnAddClick);
            this.btnMainPanel.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnEditClick);
            this.btnMainPanel.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnDeleteClick);
            this.btnMainPanel.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnSearchClick);
            this.btnMainPanel.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnRefreshClick);
            this.btnMainPanel.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.buttonPanelControl1_btnCloseClick);
            // 
            // frmSubjectMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 732);
            this.Controls.Add(this.btnMainPanel);
            this.Controls.Add(this.grpSubjectMaster);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSubjectMas";
            this.Tag = "SubjectMas";
            this.Text = "Subject Master";
            this.Load += new System.EventHandler(this.frmSubjectMas_Load);
            this.grpSubjectMaster.ResumeLayout(false);
            this.grpChapterDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChapterDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubjectMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSubjectMaster;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel;
        private System.Windows.Forms.GroupBox grpChapterDetail;
        private System.Windows.Forms.DataGridView grdChapterDetail;
        public System.Windows.Forms.DataGridView grdSubjectMaster;
    }
}