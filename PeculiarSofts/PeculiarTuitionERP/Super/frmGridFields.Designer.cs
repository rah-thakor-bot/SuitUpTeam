namespace PeculiarTuitionERP.Super
{
    partial class frmGridFields
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
            this.grdGridMas = new System.Windows.Forms.DataGridView();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpGridMas = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdGridMas)).BeginInit();
            this.grpGridMas.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGridMas
            // 
            this.grdGridMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGridMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGridMas.Location = new System.Drawing.Point(3, 22);
            this.grdGridMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdGridMas.Name = "grdGridMas";
            this.grdGridMas.RowHeadersVisible = false;
            this.grdGridMas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGridMas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGridMas.Size = new System.Drawing.Size(1212, 603);
            this.grdGridMas.TabIndex = 0;
            this.grdGridMas.Tag = "grdBatchMaster";
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 716);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1218, 81);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 9;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grpGridMas
            // 
            this.grpGridMas.Controls.Add(this.grdGridMas);
            this.grpGridMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGridMas.Location = new System.Drawing.Point(0, 0);
            this.grpGridMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGridMas.Name = "grpGridMas";
            this.grpGridMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpGridMas.Size = new System.Drawing.Size(1218, 629);
            this.grpGridMas.TabIndex = 8;
            this.grpGridMas.TabStop = false;
            this.grpGridMas.Tag = "GridFields";
            this.grpGridMas.Text = "Grid Field Master";
            // 
            // frmGridFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 797);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpGridMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGridFields";
            this.Text = "frmGridFields";
            this.Load += new System.EventHandler(this.frmGridFields_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGridMas)).EndInit();
            this.grpGridMas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdGridMas;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpGridMas;
    }
}