namespace PeculiarTuitionERP.Exam_Module
{
    partial class frmResultMas
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
            this.grpResultMas = new System.Windows.Forms.GroupBox();
            this.grdResultMas = new System.Windows.Forms.DataGridView();
            this.grpResultMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultMas)).BeginInit();
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 684);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1292, 106);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 7;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grpResultMas
            // 
            this.grpResultMas.Controls.Add(this.grdResultMas);
            this.grpResultMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResultMas.Location = new System.Drawing.Point(0, 0);
            this.grpResultMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpResultMas.Name = "grpResultMas";
            this.grpResultMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpResultMas.Size = new System.Drawing.Size(1292, 629);
            this.grpResultMas.TabIndex = 6;
            this.grpResultMas.TabStop = false;
            this.grpResultMas.Tag = "ResultMas";
            this.grpResultMas.Text = "Result Master";
            // 
            // grdResultMas
            // 
            this.grdResultMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResultMas.Location = new System.Drawing.Point(3, 22);
            this.grdResultMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdResultMas.Name = "grdResultMas";
            this.grdResultMas.Size = new System.Drawing.Size(1286, 603);
            this.grdResultMas.TabIndex = 0;
            this.grdResultMas.Tag = "grdResultMas";
            // 
            // frmResultMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 790);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpResultMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmResultMas";
            this.Tag = "ResultMas";
            this.Text = "Result Master";
            this.Load += new System.EventHandler(this.frmResultMas_Load);
            this.grpResultMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpResultMas;
        private System.Windows.Forms.DataGridView grdResultMas;
    }
}