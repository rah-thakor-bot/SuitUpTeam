namespace PeculiarTuitionERP.Transaction_Module
{
    partial class frmPaymentMaster
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
            this.grdPaymentMas = new System.Windows.Forms.DataGridView();
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpPaymentMas = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentMas)).BeginInit();
            this.grpPaymentMas.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPaymentMas
            // 
            this.grdPaymentMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaymentMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaymentMas.Location = new System.Drawing.Point(3, 22);
            this.grdPaymentMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPaymentMas.Name = "grdPaymentMas";
            this.grdPaymentMas.RowHeadersVisible = false;
            this.grdPaymentMas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPaymentMas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPaymentMas.Size = new System.Drawing.Size(1289, 603);
            this.grdPaymentMas.TabIndex = 0;
            this.grdPaymentMas.Tag = "grdPaymentMas";
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 707);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1295, 89);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 13;
            this.btnMainPanel1.btnAddClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnAddClick);
            this.btnMainPanel1.btnEditClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnEditClick);
            this.btnMainPanel1.btnDeleteClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnDeleteClick);
            this.btnMainPanel1.btnSearchClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnSearchClick);
            this.btnMainPanel1.btnRefreshClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnRefreshClick);
            this.btnMainPanel1.btnCloseClick += new Private.MyUserControls.ButtonPanelControl.Button_Click(this.btnMainPanel1_btnCloseClick);
            // 
            // grpPaymentMas
            // 
            this.grpPaymentMas.Controls.Add(this.grdPaymentMas);
            this.grpPaymentMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPaymentMas.Location = new System.Drawing.Point(0, 0);
            this.grpPaymentMas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPaymentMas.Name = "grpPaymentMas";
            this.grpPaymentMas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPaymentMas.Size = new System.Drawing.Size(1295, 629);
            this.grpPaymentMas.TabIndex = 12;
            this.grpPaymentMas.TabStop = false;
            this.grpPaymentMas.Tag = "PaymentMas";
            this.grpPaymentMas.Text = "Payment Master";
            // 
            // frmPaymentMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 796);
            this.Controls.Add(this.btnMainPanel1);
            this.Controls.Add(this.grpPaymentMas);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmPaymentMaster";
            this.Tag = "PaymentMas";
            this.Text = "Payment Detail";
            this.Load += new System.EventHandler(this.frmPaymentMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentMas)).EndInit();
            this.grpPaymentMas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPaymentMas;
        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpPaymentMas;
    }
}