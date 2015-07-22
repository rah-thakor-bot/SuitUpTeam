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
            this.btnMainPanel1 = new Private.MyUserControls.ButtonPanelControl();
            this.grpPaymentMas = new System.Windows.Forms.GroupBox();
            this.grdPaymentMas = new System.Windows.Forms.DataGridView();
            this.grpPaymentMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentMas)).BeginInit();
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
            this.btnMainPanel1.Location = new System.Drawing.Point(0, 690);
            this.btnMainPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMainPanel1.MessageText = "";
            this.btnMainPanel1.Name = "btnMainPanel1";
            this.btnMainPanel1.SetColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.SetDuration = 0;
            this.btnMainPanel1.SetLightColor = System.Drawing.Color.Empty;
            this.btnMainPanel1.Size = new System.Drawing.Size(1295, 106);
            this.btnMainPanel1.StartTime = new System.DateTime(((long)(0)));
            this.btnMainPanel1.TabIndex = 7;
            // 
            // grpPaymentMas
            // 
            this.grpPaymentMas.Controls.Add(this.grdPaymentMas);
            this.grpPaymentMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPaymentMas.Location = new System.Drawing.Point(0, 0);
            this.grpPaymentMas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grpPaymentMas.Name = "grpPaymentMas";
            this.grpPaymentMas.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grpPaymentMas.Size = new System.Drawing.Size(1295, 823);
            this.grpPaymentMas.TabIndex = 6;
            this.grpPaymentMas.TabStop = false;
            this.grpPaymentMas.Tag = "PaymentMaster";
            this.grpPaymentMas.Text = "Payment Master";
            // 
            // grdPaymentMas
            // 
            this.grdPaymentMas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPaymentMas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaymentMas.Location = new System.Drawing.Point(3, 23);
            this.grdPaymentMas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdPaymentMas.Name = "grdPaymentMas";
            this.grdPaymentMas.Size = new System.Drawing.Size(1289, 795);
            this.grdPaymentMas.TabIndex = 0;
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
            this.grpPaymentMas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentMas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Private.MyUserControls.ButtonPanelControl btnMainPanel1;
        private System.Windows.Forms.GroupBox grpPaymentMas;
        private System.Windows.Forms.DataGridView grdPaymentMas;
    }
}