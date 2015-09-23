namespace PeculiarTuitionERP.Master_Module
{
    partial class frmTimetable
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
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grdTimetable = new System.Windows.Forms.DataGridView();
            this.grpTimetable = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimetable)).BeginInit();
            this.grpTimetable.SuspendLayout();
            this.SuspendLayout();
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 683);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1266, 90);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 10;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grdTimetable
            // 
            this.grdTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTimetable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTimetable.Location = new System.Drawing.Point(3, 22);
            this.grdTimetable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdTimetable.Name = "grdTimetable";
            this.grdTimetable.Size = new System.Drawing.Size(1260, 603);
            this.grdTimetable.TabIndex = 0;
            this.grdTimetable.Tag = "grdSubAlloc";
            // 
            // grpTimetable
            // 
            this.grpTimetable.Controls.Add(this.grdTimetable);
            this.grpTimetable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTimetable.Location = new System.Drawing.Point(0, 0);
            this.grpTimetable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTimetable.Name = "grpTimetable";
            this.grpTimetable.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTimetable.Size = new System.Drawing.Size(1266, 629);
            this.grpTimetable.TabIndex = 9;
            this.grpTimetable.TabStop = false;
            this.grpTimetable.Text = "Timetable";
            // 
            // frmTimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 773);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpTimetable);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmTimetable";
            this.Tag = "frmTimetable";
            this.Text = "TimeTable Master";
            this.Load += new System.EventHandler(this.frmTimetable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimetable)).EndInit();
            this.grpTimetable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.DataGridView grdTimetable;
        private System.Windows.Forms.GroupBox grpTimetable;
    }
}