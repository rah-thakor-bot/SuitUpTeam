namespace PeculiarTuitionERP.Master_Module
{
    partial class frmStudyLevelMas
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
            this.grdStudyLevelMas = new System.Windows.Forms.DataGridView();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpStudyLevelMas = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdStudyLevelMas)).BeginInit();
            this.grpStudyLevelMas.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdStudyLevelMas
            // 
            this.grdStudyLevelMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStudyLevelMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStudyLevelMas.Location = new System.Drawing.Point(3, 22);
            this.grdStudyLevelMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdStudyLevelMas.Name = "grdStudyLevelMas";
            this.grdStudyLevelMas.RowHeadersVisible = false;
            this.grdStudyLevelMas.Size = new System.Drawing.Size(1270, 603);
            this.grdStudyLevelMas.TabIndex = 0;
            this.grdStudyLevelMas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdStudyLevelMas_DataError);
            this.grdStudyLevelMas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdStudyLevelMas_KeyDown);
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 712);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1276, 81);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 5;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grpStudyLevelMas
            // 
            this.grpStudyLevelMas.Controls.Add(this.grdStudyLevelMas);
            this.grpStudyLevelMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStudyLevelMas.Location = new System.Drawing.Point(0, 0);
            this.grpStudyLevelMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStudyLevelMas.Name = "grpStudyLevelMas";
            this.grpStudyLevelMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStudyLevelMas.Size = new System.Drawing.Size(1276, 629);
            this.grpStudyLevelMas.TabIndex = 4;
            this.grpStudyLevelMas.TabStop = false;
            this.grpStudyLevelMas.Tag = "StudyLevelMas";
            this.grpStudyLevelMas.Text = "Study Level Mater";
            // 
            // frmStudyLevelMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 793);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpStudyLevelMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmStudyLevelMas";
            this.Tag = "StudyLevelMas";
            this.Text = "frmStudyLevelMas";
            this.Load += new System.EventHandler(this.frmStudyLevelMas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStudyLevelMas)).EndInit();
            this.grpStudyLevelMas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdStudyLevelMas;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpStudyLevelMas;
    }
}