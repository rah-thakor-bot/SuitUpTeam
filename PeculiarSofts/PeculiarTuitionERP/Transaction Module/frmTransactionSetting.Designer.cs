namespace PeculiarTuitionERP.Transaction_Module
{
    partial class frmTransactionSetting
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
            this.grpTransactionMas = new System.Windows.Forms.GroupBox();
            this.grdTrnMas = new System.Windows.Forms.DataGridView();
            this.grpTransactionMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrnMas)).BeginInit();
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 726);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1291, 81);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 11;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grpTransactionMas
            // 
            this.grpTransactionMas.Controls.Add(this.grdTrnMas);
            this.grpTransactionMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTransactionMas.Location = new System.Drawing.Point(0, 0);
            this.grpTransactionMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTransactionMas.Name = "grpTransactionMas";
            this.grpTransactionMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTransactionMas.Size = new System.Drawing.Size(1291, 629);
            this.grpTransactionMas.TabIndex = 10;
            this.grpTransactionMas.TabStop = false;
            this.grpTransactionMas.Tag = "TrnMas";
            this.grpTransactionMas.Text = "Transaction Settings";
            // 
            // grdTrnMas
            // 
            this.grdTrnMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTrnMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTrnMas.Location = new System.Drawing.Point(3, 22);
            this.grdTrnMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdTrnMas.Name = "grdTrnMas";
            this.grdTrnMas.RowHeadersVisible = false;
            this.grdTrnMas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTrnMas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTrnMas.Size = new System.Drawing.Size(1285, 603);
            this.grdTrnMas.TabIndex = 0;
            this.grdTrnMas.Tag = "grdTrnMas";
            this.grdTrnMas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTrnMas_RowEnter);
            // 
            // frmTransactionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 807);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpTransactionMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmTransactionSetting";
            this.Tag = "TranSettings";
            this.Text = "Transaction Settings";
            this.Load += new System.EventHandler(this.frmTransactionSetting_Load);
            this.grpTransactionMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTrnMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpTransactionMas;
        private System.Windows.Forms.DataGridView grdTrnMas;
    }
}